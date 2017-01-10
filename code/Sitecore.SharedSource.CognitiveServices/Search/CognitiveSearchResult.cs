using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public class CognitiveSearchResult : SearchResultItem, ICognitiveSearchResult
    {
        #region properties
        
        [IndexField("imageItemAnalysis")]
        public string ImageItemAnalysis { get; set; }
        [IndexField("textFieldAnalysis")]
        public string TextFieldAnalysis { get; set; }
        [IndexField("_uniqueid")]
        public string UniqueID { get; set; }

        #endregion properties
    }
}