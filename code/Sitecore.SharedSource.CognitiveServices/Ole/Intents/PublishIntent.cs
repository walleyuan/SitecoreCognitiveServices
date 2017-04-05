using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Publishing;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {

    public interface IPublishIntent : IIntent { }

    public class PublishIntent : IPublishIntent {
        public string Name => "publish";

        public string Respond(ITextTranslator translator, QueryResult result, Dictionary<string, string> parameters) {
            
            var entities = result?.Entities;
            if (entities == null)
                return "You need to tell me more about what to publish. For example, the 'to' database name, the item path and optionally if you want it recursively.";

            var dbName = entities.FirstOrDefault(x => x.Type.Equals("Database Name"))?.Entity;
            if (string.IsNullOrEmpty(dbName))
                return "Sorry, I think you forgot to mention the database name you wanted to publish to.";

            var db = Sitecore.Configuration.Factory.GetDatabase("dbName");
            if (db == null)
                return "Sorry, I couldn't find that database.";

            var itemPath = entities.FirstOrDefault(x => x.Type.Equals("Item Path"))?.Entity;
            if (string.IsNullOrEmpty(itemPath))
                return "Sorry, I think you forgot to mention the root item path.";

            var recursively = entities.FirstOrDefault(x => x.Type.Equals("Recursion"))?.Entity;
            var isRecursive = string.IsNullOrEmpty(recursively);

            ILogWrapper log = new LogWrapper();
            ISitecoreDataService ds = new SitecoreDataService(log);
            Item item = Sitecore.Context.Database.GetItem(itemPath);
            if (item == null)
                return $"Sorry, I couldn't find the item at {itemPath}. Are you sure that's the right path?";

            var IndexNameFormat = Sitecore.Configuration.Settings.GetSetting("CognitiveService.Search.IndexNameFormat");
            var indexName = string.Format(IndexNameFormat, dbName);
            var index = ContentSearchManager.GetIndex(indexName);
            if (index == null)
                return $"Sorry, I couldn't find the search index for the {dbName} database.";

            var tempItem = (SitecoreIndexableItem)item;

            PublishManager.PublishItem(item, new[] {db}, new[] { item.Language }, isRecursive, false);

            return $"I've published {item.DisplayName} to the {dbName} database in {item.Language} {(isRecursive ? " with it's children" : string.Empty)}";
        }
    }
}