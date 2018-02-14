using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Intents;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Statics;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public class ConversationService : IConversationService
    {
        protected readonly IIntentProvider IntentProvider;
        protected readonly ILuisService LuisService;
        protected readonly IOleSettings OleSettings;
        protected readonly IConversationHistory ConversationHistory;
        protected readonly IConversationFactory ConversationFactory;
        protected readonly IConversationResponseFactory ConversationResponseFactory;
        protected readonly ITextAnalyticsService TextAnalyticsService;

        protected readonly Guid AppId;
        protected string ReqParam = "RequestParam";

        public ConversationService(
            IIntentProvider intentProvider,
            ILuisService luisService,
            IOleSettings oleSettings,
            IConversationHistory convoHistory,
            IConversationFactory convoFactory,
            IConversationResponseFactory responseFactory,
            ITextAnalyticsService textAnalyticsService)
        {
            IntentProvider = intentProvider;
            LuisService = luisService;
            OleSettings = oleSettings;
            ConversationHistory = convoHistory;
            ConversationFactory = convoFactory;
            ConversationResponseFactory = responseFactory;
            TextAnalyticsService = textAnalyticsService;

            AppId = OleSettings.OleApplicationId;
        }

        public ConversationResponse HandleMessage(Activity activity, ItemContextParameters parameters)
        {
            IConversation conversation = (ConversationHistory.Conversations.Any())
                ? ConversationHistory.Conversations.Last()
                : null;
        
            var inConversation = conversation != null && !conversation.IsEnded;
            
            // determine which intent user wants and context
            var result = LuisService.Query(AppId, activity.Text);
            var requestedQuit = 
                result.TopScoringIntent.Intent.ToLower().Equals("quit") && 
                result.TopScoringIntent.Score > 0.4;

            var intent = IntentProvider.GetIntent(AppId, result.TopScoringIntent.Intent);

            // if the user is trying to end or finish a conversation 
            if (inConversation && requestedQuit) { 
                conversation.IsEnded = true;
                return intent.Respond(null, null, null);
            }
            
            // start a new conversation if not in one
            if (!inConversation && intent != null && result.TopScoringIntent.Score > 0.4)
            {
                conversation = ConversationFactory.Create(result, intent);
                ConversationHistory.Conversations.Add(conversation);
                inConversation = true;
            }

            if (inConversation)
            {
                if (activity.Text.StartsWith($"{Translator.Text("Chat.Clear")} "))
                {
                    var clearParam = activity.Text.Replace($"{Translator.Text("Chat.Clear")} ", "");
                    if (conversation.Context.ContainsKey(clearParam))
                        conversation.Context.Remove(clearParam);
                    if(conversation.Data.ContainsKey(clearParam))
                        conversation.Data.Remove(clearParam);
                }

                // check and request all required parameters of a conversation
                foreach (ConversationParameter p in conversation.Intent.RequiredParameters)
                {
                    if (!TryGetParam(p.ParamName, result, conversation, parameters, p.ParamGetter))
                        return RequestParam(p, conversation, parameters);
                }

                // save confirmation
                if (conversation.Intent.RequiresConfirmation && activity.Text.Equals($"{Translator.Text("Chat.Continue")} "))
                    conversation.IsConfirmed = true;

                // confirm selected options with user 
                if (conversation.Intent.RequiresConfirmation && !conversation.IsConfirmed)
                    return ConversationResponseFactory.Create(Translator.Text("Chat.ConfirmMessage"), "confirm", conversation.Context);
                
                conversation.IsEnded = true;

                return conversation.Intent.Respond(result, parameters, conversation);
            }

            // determine mood of comment
            var sentiment = GetSentiment(activity.Text);
            var sentimentScore = (sentiment?.Documents != null && sentiment.Documents.Any())
                ? sentiment.Documents.First().Score
                : 1;

            // is a user frustrated or is their intention unclear
            return (sentimentScore <= 0.4)
                ? IntentProvider.GetIntent(AppId, "frustrated user").Respond(null, null, null)
                : IntentProvider.GetDefaultResponse(AppId);
        }
        
        /// <summary>
        /// Api call to determine the sentiment of the user input
        /// </summary>
        /// <param name="text">user input</param>
        public virtual SentimentResponse GetSentiment(string text)
        {
            var sr = new SentimentRequest();
            sr.Documents.Add(new Document() { Text = text, Id = "Ole" });

            return TextAnalyticsService.GetSentiment(sr);
        }

        /// <summary>
        /// get a valid parameter object by checking for it in the previously retrieved data store or by finding it based on the information provided by the user
        /// </summary>
        /// <param name="paramName">the parameter to retrieve</param>
        /// <param name="result">the luis response that provides intent and entity information provided by the user</param>
        /// <param name="c">the current conversation</param>
        /// <param name="parameters">the context paramters</param>
        /// <param name="GetValidParameter">the method that can retrieve the valid parameters for a valid user input</param>
        /// <returns></returns>
        public virtual bool TryGetParam(string paramName, LuisResult result, IConversation c, ItemContextParameters parameters, Func<string, ItemContextParameters, IConversation, object> GetValidParameter)
        {
            var storedValue = c.Data.ContainsKey(paramName)
                ? c.Data[paramName]
                : null;

            if (storedValue != null)
                return true;

            string value = GetValue(paramName, result, c);
            if (string.IsNullOrEmpty(value))
                return false;

            var validParam = GetValidParameter(value, parameters, c);
            if (validParam == null)
                return false;
            
            if (IsParamRequest(paramName, c)) // clear any request for this property
                c.Context.Remove(ReqParam);

            c.Context[paramName] = value;
            c.Data[paramName] = validParam;
            return true;
        }

        /// <summary>
        /// tries to determine a value for the requested parameter from a number of possible locations; current response entities, current response, previously provided information (context), or previously provided entities
        /// </summary>
        /// <param name="paramName">the parameter to be searching for</param>
        /// <param name="result">the luis query result that identities the intent and entities</param>
        /// <param name="c">the current conversation</param>
        /// <returns></returns>
        public virtual string GetValue(string paramName, LuisResult result, IConversation c)
        {
            var currentEntity = result?.Entities?.FirstOrDefault(x => x.Type.Equals(paramName))?.Entity;
            if (currentEntity != null) // check the current request entities
                return currentEntity;

            if (IsParamRequest(paramName, c)) // was the user responding to a specific request
                return result.Query;

            if (c.Context.ContainsKey(paramName)) // check the context data
                return c.Context[paramName];

            var initialEntity = c.Result?.Entities?.FirstOrDefault(x => x.Type.Equals(paramName))?.Entity;
            if (initialEntity != null) // check the initial request entities
                return initialEntity;

            return string.Empty;
        }

        /// <summary>
        /// Is the currently requested parameter the one I'm checking
        /// </summary>
        /// <param name="paramName">the parameter to check</param>
        /// <param name="c">the conversation it's occurring in</param>
        /// <returns></returns>
        public virtual bool IsParamRequest(string paramName, IConversation c)
        {
            return c.Context.ContainsKey(ReqParam) && c.Context[ReqParam].Equals(paramName);
        }

        /// <summary>
        /// Create a response to the user requesting a specific parameter
        /// </summary>
        /// <param name="param">the parameter details</param>
        /// <param name="c">the conversation it occurs in</param>
        /// <param name="parameters">context parameters</param>
        /// <returns></returns>
        public virtual ConversationResponse RequestParam(ConversationParameter param, IConversation c, ItemContextParameters parameters)
        {
            c.Context[ReqParam] = param.ParamName;

            return ConversationResponseFactory.Create(param.ParamMessage, param.ParamOptions?.Invoke(parameters));
        }
    }
}