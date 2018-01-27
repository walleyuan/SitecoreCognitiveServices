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

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface IRebuildIndexIntent : IIntent { }

    public class RebuildIndexIntent : BaseIntent, IRebuildIndexIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IContentSearchWrapper ContentSearchWrapper;
        
        public override string Name => "rebuild index";

        public override string Description => "Rebuild an Index";

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(IndexKey, "What index do you want to rebuild?", GetValidIndex, IndexOptions)
        };

        #region Local Properties

        protected string IndexKey = "Index Name";
        
        #endregion
        
        public RebuildIndexIntent(
            ITextTranslatorWrapper translator,
            IContentSearchWrapper searchWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings)
        {
            Translator = translator;
            ContentSearchWrapper = searchWrapper;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var message = "";
            var index = (string)conversation.Data[IndexKey];
            if (index == "All")
            {
                IndexCustodian.RebuildAll(new [] { IndexGroup.Experience });
                message = "All indexes are being rebuilt";
            }
            else
            {
                var searchIndex = ContentSearchWrapper.GetIndex(index);
                IndexCustodian.FullRebuild(searchIndex);
                message = $"The {index} index is being rebuilt";
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
            var indexes = ContentSearchWrapper.GetIndexNames().Concat(new [] { "All" });
            
            return IntentOptionSetFactory.Create(IntentOptionType.Link, indexes.ToList());
        }
    }
}