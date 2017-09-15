using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface ILockedItemCountIntent : IIntent { }

    public class LockedItemCountIntent : BaseIntent, ILockedItemCountIntent {

        protected readonly ITextTranslatorWrapper Translator;
        
        public override string Name => "locked item count";

        public override string Description => "Count your locked items";

        public LockedItemCountIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) : base(settings) {
            Translator = translator;
            }
        
        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var items = GetCurrentUserUnlockedItems(parameters.Database);
            
            return CreateConversationResponse($"You have {items.Count} locked items");
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