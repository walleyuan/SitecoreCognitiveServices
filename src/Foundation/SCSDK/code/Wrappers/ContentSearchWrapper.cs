using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.Jobs;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IContentSearchWrapper
    {
        ISearchIndex GetIndex(string indexName);
        IEnumerable<string> GetIndexNames();
        Job FullRebuild(ISearchIndex searchIndex);
    }

    public class ContentSearchWrapper : IContentSearchWrapper
    {
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