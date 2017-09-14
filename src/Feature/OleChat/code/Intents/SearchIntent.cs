using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.SharedSource.CognitiveServices.OleChat.Search;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents
{
    public interface ISearchIntent : IIntent { }

    public class SearchIntent : BaseIntent, ISearchIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ISearchContext SearchContext;

        public override string Name => "search";

        public override string Description => "Search for Content";

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(DBKey, "What database did you want to search?", IsDbValid),
            new ConversationParameter(ScopeKey, "Which or how many were you looking for?", IsScopeValid),
            new ConversationParameter(TemplateKey, "What item type did you want to check?", IsTemplateValid),
            new ConversationParameter(FieldKey, "What field should I look in?", IsFieldValid),
            new ConversationParameter(ModifierKey, "Where in the field should I look?", IsModifierValid),
            new ConversationParameter(ValueKey, "What value were you looking for?", IsValueValid),
            new ConversationParameter(LanguageKey, "What language did you want to search in?", IsLanguageValid)
        };

        #region Local Properties

        protected string DBKey = "Search Database";
        protected string ScopeKey = "Search Scope";
        protected string TemplateKey = "Search Template";
        protected string FieldKey = "Search Field";
        protected string ModifierKey = "Search Modifier";
        protected string ValueKey = "Search Value";
        protected string LanguageKey = "Language Value";

        #endregion

        public SearchIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings,
            ISitecoreDataWrapper dataWrapper,
            ISearchContext searchContext) : base(settings)
        {
            Translator = translator;
            DataWrapper = dataWrapper;
            SearchContext = searchContext;
        }
        
        public override string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var toDb = (Database) conversation.Data[DBKey];
            var scope = (string) conversation.Data[ScopeKey];
            var templateFilter = (TemplateItem) conversation.Data[TemplateKey];
            var fieldName = (string) conversation.Data[FieldKey];
            var modifier = (SearchModifier) conversation.Data[ModifierKey];
            var searchValue = (string) conversation.Data[ValueKey];
            var language = (string) conversation.Data[LanguageKey];

            var results = SearchContext.Search(toDb, scope, templateFilter, fieldName, modifier, searchValue, language);
            
            return "Default Search Response";
        }

        public virtual bool IsDbValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var toDb = (conversation.Data.ContainsKey(DBKey))
                ? (Database)conversation.Data[DBKey]
                : null;

            if (toDb != null)
                return true;

            if (string.IsNullOrEmpty(paramValue))
                return false;

            toDb = DataWrapper.GetDatabase(paramValue);

            if (toDb == null)
                return false;

            conversation.Data[DBKey] = toDb;
            return true;
        }

        public virtual bool IsScopeValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            return true;
        }

        public virtual bool IsTemplateValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            return true;
        }

        public virtual bool IsFieldValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            return true;
        }

        public virtual bool IsModifierValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            return true;
        }

        public virtual bool IsValueValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            return true;
        }

        public virtual bool IsLanguageValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            return true;
        }
    }
}