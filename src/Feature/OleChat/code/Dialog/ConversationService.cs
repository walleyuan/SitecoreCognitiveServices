using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Intents;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Language;
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

            if (inConversation) { 
                
                // check and request all required parameters of a conversation
                foreach (ConversationParameter p in conversation.Intent.RequiredParameters)
                {
                    if (!TryGetParam(p.ParamName, result, conversation, parameters, p.ParamGetter))
                        return RequestParam(p, conversation, parameters);
                }

                conversation.IsEnded = true;

                return conversation.Intent.Respond(result, parameters, conversation);
            }

            // respond with fallback / default
            var sentiment = GetSentiment(activity.Text);
            var sentimentScore = (sentiment?.Documents != null && sentiment.Documents.Any())
                ? sentiment.Documents.First().Score
                : 1;

            // is a user frustrated or is their intention unclear
            return (sentimentScore <= 0.4)
                ? IntentProvider.GetIntent(AppId, "frustrated user").Respond(null, null, null)
                : IntentProvider.GetDefaultResponse(AppId);
            
        }
        
        public virtual SentimentResponse GetSentiment(string text)
        {
            var sr = new SentimentRequest();
            sr.Documents.Add(new Document() { Text = text, Id = "Ole" });

            return TextAnalyticsService.GetSentiment(sr);
        }

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

        public virtual bool IsParamRequest(string paramName, IConversation c)
        {
            return c.Context.ContainsKey(ReqParam) && c.Context[ReqParam].Equals(paramName);
        }

        public virtual ConversationResponse RequestParam(ConversationParameter param, IConversation c, ItemContextParameters parameters)
        {
            c.Context[ReqParam] = param.ParamName;

            return ConversationResponseFactory.Create(param.ParamMessage, param.ParamOptions?.Invoke(parameters));
        }
    }
}