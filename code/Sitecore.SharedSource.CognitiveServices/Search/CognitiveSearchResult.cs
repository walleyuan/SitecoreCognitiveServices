using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch.Abstractions;
using Sitecore.ContentSearch;
using Sitecore.Data;
using Sitecore.ContentSearch.SearchTypes;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public class CognitiveSearchResult : SearchResultItem, ICognitiveSearchResult
    {
        #region properties
        
        [IndexField("imageItemAnalysis")]
        public string ImageItemAnalysis { get; set; }
        [IndexField("cumulativeTextFieldAnalysis")]
        public string TextFieldAnalysis { get; set; }
        [IndexField("_uniqueid")]
        public string UniqueID { get; set; }

        #endregion properties
    }
}