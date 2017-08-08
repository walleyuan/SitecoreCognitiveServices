using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IUnlockItemsIntent : IIntent { }

    public class UnlockItemsIntent : BaseIntent, IUnlockItemsIntent {

        protected readonly ITextTranslatorWrapper Translator;
        
        public override string Name => "unlock items";

        public override string Description => "Unlock your items";

        public UnlockItemsIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) : base(settings) {
            Translator = translator;
            }
        
        public override string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
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
            
            return $"I've unlocked {items.Count} for you";
        }

        protected List<SearchResultItem> GetCurrentUserUnlockedItems(string db)
        {
            var userMod = Sitecore.Context.User.DisplayName.Replace("\\", "").ToLower();

            using (var context = ContentSearchManager.GetIndex($"sitecore_{db}_index").CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck)) {
                return context
                    .GetQueryable<SearchResultItem>()
                    .Where(a => a.LockOwner.Equals(userMod)).ToList();
            }
        }
    }
}