using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

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
            new ConversationParameter(DBKey, "What database did you want to publish to?", IsDbValid),
            new ConversationParameter(ItemKey, "What was the item path you wanted to publish?", IsPathValid),
            new ConversationParameter(RecursionKey, "Do you want to publish all children?", IsRecursionValid)
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
            IPublishWrapper publishWrapper) : base(settings)
        {
            Translator = translator;
            DataWrapper = dataWrapper;
            PublishWrapper = publishWrapper;
        }
        
        public override string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var toDb = (Database) conversation.Data[DBKey];
            var rootItem = (Item) conversation.Data[ItemKey];
            var recursion = (bool) conversation.Data[RecursionKey];
            PublishWrapper.PublishItem(rootItem, new[] { toDb }, new[] { rootItem.Language }, recursion, false);

            return $"I've published {rootItem.DisplayName} to the {toDb.Name} database in {rootItem.Language.Name} {(recursion ? " with it's children" : string.Empty)}";
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
    }
}