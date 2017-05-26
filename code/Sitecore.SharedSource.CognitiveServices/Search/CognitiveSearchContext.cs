using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Security;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public class CognitiveSearchContext : ICognitiveSearchContext
    {
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IApplicationSettings ApplicationSettings;
        
        public CognitiveSearchContext(
            ISitecoreDataWrapper dataWrapper,
            IApplicationSettings applicationSettings)
        {
            DataWrapper = dataWrapper;
            ApplicationSettings = applicationSettings;
        }

        public virtual ICognitiveSearchResult GetAnalysis(string itemId, string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveSearchResult>()
                    .Where(a => 
                        a.UniqueId.Contains(itemId.ToLower()) 
                        && a.Language == languageCode)
                    .Take(1)
                    .FirstOrDefault();
            }
        }
        
        public virtual void AddItemToIndex(string itemId, string dbName)
        {
            ID id = DataWrapper.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataWrapper.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            AddItemToIndex(i, dbName);
        }

        public virtual void AddItemToIndex(Item item, string dbName)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;
            ContentSearchManager.GetIndex(GetIndexName(dbName)).Refresh(tempItem);
        }

        public virtual void UpdateItemInIndex(string itemId, string dbName)
        {
            ID id = DataWrapper.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataWrapper.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            UpdateItemInIndex(i, dbName);
        }

        public virtual void UpdateItemInIndex(Item item, string dbName)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;

            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
                
            index.Update(tempItem.UniqueId);
        }

        protected virtual string GetIndexName(string dbName)
        {
            if (dbName == null)
            {
                dbName = "master";
            }
            return string.Format(ApplicationSettings.IndexNameFormat, dbName);
        }
    }
}