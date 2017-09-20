using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface IPublishIntent : IIntent { }

    public class PublishIntent : BaseIntent, IPublishIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IPublishWrapper PublishWrapper;
        
        public override string Name => "publish";

        public override string Description => "Publish content";

        public override List<ConversationParameter> RequiredParameters => new List<ConversationParameter>()
        {
            new ConversationParameter(ItemKey, "What was the item path you wanted to publish?", GetValidPath, null),
            new ConversationParameter(DBKey, "What database did you want to publish to?", GetValidDb, DbOptions),
            new ConversationParameter(LangKey, "What language(s) should I publish to?", GetValidLanguage, LanguageOptions),
            new ConversationParameter(RecursionKey, "Do you want to publish all children?", GetValidRecursion, RecursionOptions)
        };

        #region Local Properties

        protected string DBKey = "Database Name";
        protected string ItemKey = "Item Path";
        protected string LangKey = "Language";
        protected string RecursionKey = "Recursion";
        
        #endregion
        
        public PublishIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings,
            ISitecoreDataWrapper dataWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IPublishWrapper publishWrapper) : base(optionSetFactory, responseFactory, settings)
        {
            Translator = translator;
            DataWrapper = dataWrapper;
            PublishWrapper = publishWrapper;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var toDb = (Database) conversation.Data[DBKey];
            var rootItem = (Item) conversation.Data[ItemKey];
            var langItem = (Language) conversation.Data[LangKey];
            var recursion = (string) conversation.Data[RecursionKey];
            PublishWrapper.PublishItem(rootItem, new[] { toDb }, new[] { langItem }, recursion.Equals("y"), false);

            return ConversationResponseFactory.Create($"I've published {rootItem.DisplayName} to the {toDb.Name} database in {rootItem.Language.GetDisplayName()} {(recursion.Equals("y") ? " with it's children" : string.Empty)}");
        }

        #region DB

        public virtual Database GetValidDb(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            try { 
                return DataWrapper.GetDatabase(paramValue);
            }
            catch { }

            return null;
        }

        public virtual IntentOptionSet DbOptions(ItemContextParameters parameters)
        {
            var dbName = (!string.IsNullOrEmpty(parameters.Database)) ? parameters.Database : "master";
            var publishingTargets = PublishWrapper.GetPublishingTargets(dbName);
            
            var options = publishingTargets.ToDictionary(a => a, a => a);

            return IntentOptionSetFactory.Create(IntentOptionType.Link, options);
        }

        #endregion

        #region Path

        public virtual Item GetValidPath(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var fromDb = DataWrapper.GetDatabase(parameters.Database);
            return fromDb.GetItem(paramValue);
        }

        #endregion

        #region Recursion

        public virtual string GetValidRecursion(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            List<string> responses = new List<string>()
            {
                "recursive",
                "recursively",
                "uh huh",
                "yeah",
                "yes",
                "ok",
                "yep",
                "true",
                "y"
            };
            
            return responses.Contains(paramValue.ToLower()) ? "y" : "n";
        }

        public virtual IntentOptionSet RecursionOptions(ItemContextParameters parameters)
        {
            var options = new Dictionary<string, string>{ { "Yes", "Yes" }, { "No", "No" } };

            return IntentOptionSetFactory.Create(IntentOptionType.Link, options);
        }

        #endregion

        #region Language

        public virtual Language GetValidLanguage(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var dbName = (!string.IsNullOrEmpty(parameters.Database)) ? parameters.Database : "master";
            var db = DataWrapper.GetDatabase(dbName);
            var langs = DataWrapper.GetLanguages(db).Where(a => a.Name.Equals(paramValue)).ToList();

            return langs.Any() ? langs.First() : null;
        }

        public virtual IntentOptionSet LanguageOptions(ItemContextParameters parameters)
        {
            var dbName = (!string.IsNullOrEmpty(parameters.Database)) ? parameters.Database : "master";
            var db = DataWrapper.GetDatabase(dbName);
             
            var options = DataWrapper.GetLanguages(db).ToDictionary(a => a.GetDisplayName(), a => a.Name);

            return IntentOptionSetFactory.Create(IntentOptionType.Link, options);
        }

        #endregion
    }
}