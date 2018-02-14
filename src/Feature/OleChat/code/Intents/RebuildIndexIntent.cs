using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class RebuildIndexIntent : BaseOleIntent
    {
        protected readonly IContentSearchWrapper ContentSearchWrapper;
        
        public override string Name => "rebuild index";

        public override string Description => Translator.Text("Chat.Intents.RebuildIndex.Name");

        public override bool RequiresConfirmation => false;

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(IndexKey, Translator.Text("Chat.Intents.RebuildIndex.IndexParameterRequest"), GetValidIndex, IndexOptions)
        };

        #region Local Properties

        protected string IndexKey = "Index Name";
        protected string AllOption = Translator.Text("Chat.Intents.RebuildIndex.All");

        #endregion

        public RebuildIndexIntent(
            IContentSearchWrapper searchWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings)
        {
            ContentSearchWrapper = searchWrapper;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var message = "";
            var index = (string)conversation.Data[IndexKey];
            if (index == AllOption)
            {
                IndexCustodian.RebuildAll(new [] { IndexGroup.Experience });
                message = Translator.Text("Chat.Intents.RebuildIndex.AllRebuiltMessage");
            }
            else
            {
                var searchIndex = ContentSearchWrapper.GetIndex(index);
                IndexCustodian.FullRebuild(searchIndex);
                message = string.Format(Translator.Text("Chat.Intents.RebuildIndex.RebuildIndexMessage"), index);
            }

            return ConversationResponseFactory.Create(message);
        }

        public virtual string GetValidIndex(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            try
            {
                var searchIndex = ContentSearchManager.GetIndex(paramValue);
                if (searchIndex == null)
                    return null;
            }
            catch {
                return null;
            }

            return paramValue;
        }

        public virtual IntentOptionSet IndexOptions(ItemContextParameters parameters)
        {
            var indexes = ContentSearchWrapper.GetIndexNames().Concat(new [] { AllOption });
            
            return IntentOptionSetFactory.Create(IntentOptionType.Link, indexes.ToList());
        }
    }
}