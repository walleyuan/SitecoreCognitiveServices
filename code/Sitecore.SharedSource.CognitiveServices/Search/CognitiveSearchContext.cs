using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Security;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public class CognitiveSearchContext : ICognitiveSearchContext
    {
        protected readonly ISitecoreContextDatabase ContextDatabase;

        protected static readonly string IndexNameFormat = "cognitive_{0}_index";
        
        public CognitiveSearchContext(
            ISitecoreContextDatabase contextDatabase)
        {
            Assert.IsNotNull(contextDatabase, typeof(ISitecoreContextDatabase));

            ContextDatabase = contextDatabase;
        }

        public ICognitiveSearchResult GetAnalysis(string itemId, string languageCode)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName());
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                var results = context.GetQueryable<CognitiveSearchResult>().ToList();

                var result = results.First();

                return context.GetQueryable<CognitiveSearchResult>()
                    .FirstOrDefault(a => 
                        a.UniqueID.Contains(itemId) 
                        && a.Language == languageCode);
            }
        }
        
        public void AddItemToIndex(string itemId)
        {
            AddItemToIndex(ContextDatabase.GetItemById(itemId));
        }

        public void AddItemToIndex(Item item)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;
            ContentSearchManager.GetIndex(GetIndexName()).Refresh(tempItem);
        }

        public void UpdateItemInIndex(string itemId)
        {
            UpdateItemInIndex(ContextDatabase.GetItemById(itemId));
        }

        public void UpdateItemInIndex(Item item)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;
            ContentSearchManager.GetIndex(GetIndexName()).Update(tempItem.UniqueId);
        }

        protected string GetIndexName()
        {
            return string.Format(IndexNameFormat, ContextDatabase.Name());
        }
    }
}