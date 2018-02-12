using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Jobs;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IContentSearchWrapper
    {
        void AddItemToIndex(string itemId, string dbName, string indexName);
        void AddItemToIndex(Item item, string indexName);
        void UpdateItemInIndex(string itemId, string dbName, string indexName);
        void UpdateItemInIndex(Item item, string indexName);
        int UpdateItemInIndexRecursively(Item item, string indexName);
        List<Item> GetAllAncestors(string folderPath, string languageCode, string indexName);
        string GetSitecoreIndexName(string dbName);
        ISearchIndex GetIndex(string indexName);
        IEnumerable<string> GetIndexNames();
        Job FullRebuild(ISearchIndex searchIndex);
    }

    public class ContentSearchWrapper : IContentSearchWrapper
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IApplicationSettings ApplicationSettings;

        public ContentSearchWrapper(
            ISitecoreDataWrapper dataWrapper,
            IApplicationSettings applicationSettings)
        {
            DataWrapper = dataWrapper;
            ApplicationSettings = applicationSettings;
        }

        #endregion

        #region Indexing

        public virtual void AddItemToIndex(string itemId, string dbName, string indexName)
        {
            ID id = DataWrapper.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataWrapper.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            AddItemToIndex(i, indexName);
        }

        public virtual void AddItemToIndex(Item item, string indexName)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;
            GetIndex(indexName).Refresh(tempItem);
        }

        public virtual void UpdateItemInIndex(string itemId, string dbName, string indexName)
        {
            ID id = DataWrapper.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataWrapper.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            UpdateItemInIndex(i, indexName);
        }

        public virtual void UpdateItemInIndex(Item item, string indexName)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;

            var index = GetIndex(indexName);

            index.Update(tempItem.UniqueId);
        }

        public virtual int UpdateItemInIndexRecursively(Item item, string indexName)
        {
            var list = GetAllAncestors(item.Paths.FullPath, item.Language.Name, indexName);

            list.ForEach(b => UpdateItemInIndex(b, indexName));

            return list.Count;
        }

        #endregion

        #region Querying

        public virtual List<Item> GetAllAncestors(string folderPath, string languageCode, string indexName)
        {
            var index = GetIndex(indexName);
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<SearchResultItem>()
                    .Where(a => a.Language == languageCode)
                    .Select(b => b.GetItem())
                    .ToList()
                    .Where(a => a.Paths.FullPath.StartsWith(folderPath))
                    .ToList();
            }
        }

        #endregion

        public virtual string GetSitecoreIndexName(string dbName)
        {
            return string.Format(ApplicationSettings.SitecoreIndexNameFormat, dbName ?? "master");
        }

        public virtual ISearchIndex GetIndex(string indexName)
        {
            return ContentSearchManager.GetIndex(indexName);
        }

        public virtual IEnumerable<string> GetIndexNames()
        {
            return ContentSearchManager.SearchConfiguration.Indexes.Select(a => a.Key);
        }

        public virtual Job FullRebuild(ISearchIndex searchIndex)
        {
            return IndexCustodian.FullRebuild(searchIndex);
        }
    }
}