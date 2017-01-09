using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Security;
using Sitecore.Data;
using Sitecore.Data.Items;

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