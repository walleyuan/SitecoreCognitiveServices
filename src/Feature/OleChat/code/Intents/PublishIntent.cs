using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using Sitecore.Data;
using Sitecore.Data.Items;
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
            new ConversationParameter(ItemKey, "What was the item path you wanted to publish?", IsPathValid, null),
            new ConversationParameter(DBKey, "What database did you want to publish to?", IsDbValid, DbOptions),
            new ConversationParameter(ItemKey, "What language(s) should I publish to?", IsLanguageValid, LanguageOptions),
            new ConversationParameter(RecursionKey, "Do you want to publish all children?", IsRecursionValid, RecursionOptions)
        };

        #region Local Properties

        protected string DBKey = "Database Name";
        protected string ItemKey = "Item Path";
        protected string RecursionKey = "Recursion";
        
        #endregion
        
        public PublishIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings,
            ISitecoreDataWrapper dataWrapper,
            IConversationResponseFactory responseFactory,
            IPublishWrapper publishWrapper) : base(settings, responseFactory)
        {
            Translator = translator;
            DataWrapper = dataWrapper;
            PublishWrapper = publishWrapper;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var toDb = (Database) conversation.Data[DBKey];
            var rootItem = (Item) conversation.Data[ItemKey];
            var recursion = (bool) conversation.Data[RecursionKey];
            PublishWrapper.PublishItem(rootItem, new[] { toDb }, new[] { rootItem.Language }, recursion, false);

            return ConversationResponseFactory.Create($"I've published {rootItem.DisplayName} to the {toDb.Name} database in {rootItem.Language.Name} {(recursion ? " with it's children" : string.Empty)}");
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

            try { 
                toDb = DataWrapper.GetDatabase(paramValue);
            }
            catch { }

            if (toDb == null)
                return false;

            conversation.Data[DBKey] = toDb;
            return true;
        }

        public virtual Dictionary<string, string> DbOptions(ItemContextParameters parameters)
        {
            return DataWrapper.GetDatabases().ToDictionary(a => a.Name, a => a.Name);
        }

        public virtual bool IsPathValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var rootItem = (conversation.Data.ContainsKey(ItemKey))
                ? (Item)conversation.Data[ItemKey]
                : null;

            if (rootItem != null)
                return true;

            if (string.IsNullOrEmpty(paramValue))
                return false;

            var fromDb = DataWrapper.GetDatabase(parameters.Database);
            rootItem = fromDb.GetItem(paramValue);

            if (rootItem == null)
                return false;

            conversation.Data[ItemKey] = rootItem;
            return true;
        }

        public virtual bool IsRecursionValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            if (conversation.Data.ContainsKey(RecursionKey))
                return true;

            if (string.IsNullOrEmpty(paramValue))
                return false;

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
            
            conversation.Data[RecursionKey] = responses.Contains(paramValue.ToLower());

            return true;
        }

        public virtual Dictionary<string, string> RecursionOptions(ItemContextParameters parameters)
        {
            return new Dictionary<string, string>{ { "Yes", "Yes" }, { "No", "No" } };
        }

        public virtual bool IsLanguageValid(string paramValue, ItemContextParameters parameters, IConversation conversation)
        {
            var langs = LanguageOptions(parameters);

            return (langs.ContainsKey(paramValue));
        }

        public virtual Dictionary<string, string> LanguageOptions(ItemContextParameters parameters)
        {
            var dbName = (!string.IsNullOrEmpty(parameters.Database)) ? parameters.Database : "master";

            var db = DataWrapper.GetDatabase(dbName);
             
            return DataWrapper.GetLanguages(db).ToDictionary(a => a.Name, a => a.Name);
        }
    }
}