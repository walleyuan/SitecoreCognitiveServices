﻿using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class UnlockItemsIntent : BaseOleIntent
    {
        protected readonly IAuthenticationWrapper AuthenticationWrapper;
        protected readonly IContentSearchWrapper ContentSearchWrapper;

        public override string Name => "unlock items";

        public override string Description => Translator.Text("Chat.Intents.UnlockItems.Name");

        public override bool RequiresConfirmation => false;

        public UnlockItemsIntent(
            IAuthenticationWrapper authWrapper,
            IContentSearchWrapper searchWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            AuthenticationWrapper = authWrapper;
            ContentSearchWrapper = searchWrapper;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
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
            
            return ConversationResponseFactory.Create(string.Format(Translator.Text("Chat.Intents.UnlockItems.Response"), items.Count));
        }

        protected List<SearchResultItem> GetCurrentUserUnlockedItems(string db)
        {
            var userMod = AuthenticationWrapper.GetCurrentUser().DisplayName.Replace("\\", "").ToLower();

            using (var context = ContentSearchWrapper.GetIndex(ContentSearchWrapper.GetSitecoreIndexName(db)).CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck)) {
                return context
                    .GetQueryable<SearchResultItem>()
                    .Where(a => a.LockOwner.Equals(userMod)).ToList();
            }
        }
    }
}