using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Security;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public class CognitiveSearchContext : ICognitiveSearchContext
    {
        protected static readonly string IndexName = "cognitive_master_index";
        
        public ICognitiveSearchResult GetAnalysis(string itemId, string languageCode)
        {
            var index = ContentSearchManager.GetIndex(IndexName);
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveSearchResult>()
                    .Where(a => a.UniqueID.Contains(itemId) && a.Language == languageCode)
                    .FirstOrDefault();
            }
        }
    }
}