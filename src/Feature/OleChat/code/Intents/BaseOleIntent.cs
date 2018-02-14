using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public abstract class BaseOleIntent : IOleIntent
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        
        public abstract ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation);

        #region Base Intent

        protected readonly IOleSettings Settings;
        protected readonly IConversationResponseFactory ConversationResponseFactory;
        protected readonly IIntentOptionSetFactory IntentOptionSetFactory;

        public virtual Guid ApplicationId => Settings.OleApplicationId;

        public virtual List<ConversationParameter> RequiredParameters => new List<ConversationParameter>();
        
        protected BaseOleIntent(
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings)
        {
            Settings = settings;
            ConversationResponseFactory = responseFactory;
            IntentOptionSetFactory = optionSetFactory;
        }
        
        #endregion
    }
}