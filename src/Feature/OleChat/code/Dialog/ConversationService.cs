using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Intents;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.Language;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public class ConversationService : IConversationService
    {
        protected readonly IIntentProvider IntentProvider;
        protected readonly ILuisService LuisService;
        protected readonly IOleSettings OleSettings;
        protected readonly IConversationHistory ConversationHistory;
        protected readonly IConversationFactory ConversationFactory;
        
        protected readonly Guid AppId;

        public ConversationService(
            IIntentProvider intentProvider,
            ILuisService luisService,
            IOleSettings oleSettings,
            IConversationHistory convoHistory,
            IConversationFactory convoFactory)
        {
            IntentProvider = intentProvider;
            LuisService = luisService;
            OleSettings = oleSettings;
            ConversationHistory = convoHistory;
            ConversationFactory = convoFactory;

            AppId = OleSettings.OleApplicationId;
        }

        public ConversationResponse HandleMessage(Activity activity, ItemContextParameters parameters)
        {
            IConversation conversation = (ConversationHistory.Conversations.Any())
                ? ConversationHistory.Conversations.Last()
                : null;

            // determine which intent user wants and context
            var result = LuisService.Query(AppId, activity.Text);
            var intent = IntentProvider.GetIntent(AppId, result.TopScoringIntent.Intent);
            var requestedQuit = intent != null && intent.Name.Equals("quit");
            var inConversation = conversation != null && !conversation.IsEnded;

            // if the user is trying to end or finish a conversation 
            if (inConversation && requestedQuit)
                conversation.IsEnded = true;
            else if (inConversation)
                return conversation.Intent.Respond(result, parameters, conversation);

            // start a new conversation
            if (intent != null)
            {
                var newConversation = ConversationFactory.Create(result, intent);
                ConversationHistory.Conversations.Add(newConversation);

                return intent.Respond(result, parameters, newConversation);
            }

            // respond with fallback / default
            return IntentProvider.GetDefaultResponse(AppId);
        }
    }
}