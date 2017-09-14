using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Security;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Search
{
    public class SearchContext : ISearchContext
    {
        public virtual IEnumerable<ISearchResult> Search(Database db, string scope, TemplateItem template, string fieldName, SearchModifier modifier, string searchValue, string language)
        {
            var index = ContentSearchManager.GetIndex($"sitecore_{db}_index");
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<SearchResult>()
                    .Where(a =>
                        a.UniqueId.Contains(itemId.ToLower())
                        && a.Language == languageCode)
                    .Take(1)
                    .FirstOrDefault();
            }
        }
    }
}