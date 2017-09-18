using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface IUnlockItemsIntent : IIntent { }

    public class UnlockItemsIntent : BaseIntent, IUnlockItemsIntent {

        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;
        protected readonly IContentSearchWrapper ContentSearchWrapper;

        public override string Name => "unlock items";

        public override string Description => "Unlock your items";

        public UnlockItemsIntent(
            ITextTranslatorWrapper translator,
            IAuthenticationWrapper authWrapper,
            IContentSearchWrapper searchWrapper,
            IOleSettings settings) : base(settings) {
            Translator = translator;
            AuthenticationWrapper = authWrapper;
            ContentSearchWrapper = searchWrapper;
        }
        
        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var items = GetCurrentUserUnlockedItems(parameters.Database);

            foreach(SearchResultItem sri in items)
            {
                Item i = sri.GetItem();
                using (new SecurityDisabler()) {
                    using (new EditContext(i, false, true))
                    {
                        i.Locking.Unlock();
                    }
                }
            }
            
            return CreateConversationResponse($"I've unlocked {items.Count} for you");
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