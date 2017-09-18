using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface ILockedItemCountIntent : IIntent { }

    public class LockedItemCountIntent : BaseIntent, ILockedItemCountIntent {

        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;
        protected readonly IContentSearchWrapper ContentSearchWrapper;

        public override string Name => "locked item count";

        public override string Description => "Count your locked items";

        public LockedItemCountIntent(
            ITextTranslatorWrapper translator,
            IAuthenticationWrapper authWrapper,
            IContentSearchWrapper searchWrapper,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(settings, responseFactory) {
            Translator = translator;
            AuthenticationWrapper = authWrapper;
            ContentSearchWrapper = searchWrapper;
        }
        
        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var items = GetCurrentUserUnlockedItems(parameters.Database);
            
            return ConversationResponseFactory.Create($"You have {items.Count} locked items");
        }
        
        protected List<SearchResultItem> GetCurrentUserUnlockedItems(string db)
        {
            var userMod = AuthenticationWrapper.GetCurrentUser().DisplayName.Replace("\\", "").ToLower();

            using (var context = ContentSearchWrapper.GetIndex($"sitecore_{db}_index").CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck)) {
                return context
                    .GetQueryable<SearchResultItem>()
                    .Where(a => a.LockOwner.Equals(userMod)).ToList();
            }
        }
    }
}