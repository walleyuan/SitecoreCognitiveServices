using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public class CognitiveSearchResult : SearchResultItem, ICognitiveSearchResult
    {
        #region properties
        
        [IndexField("emotionAnalysis")]
        public string EmotionAnalysis { get; set; }
        [IndexField("facialAnalysis")]
        public string FacialAnalysis { get; set; }
        [IndexField("TextAnalysis")]
        public string TextAnalysis { get; set; }
        [IndexField("VisionAnalysis")]
        public string VisionAnalysis { get; set; }
        [IndexField("LanguageAnalysis")]
        public string LanguageAnalysis { get; set; }
        [IndexField("LinkAnalysis")]
        public string LinkAnalysis { get; set; }
        [IndexField("SentimentAnalysis")]
        public string SentimentAnalysis { get; set; }
        [IndexField("_uniqueid")]
        public string UniqueId { get; set; }

        #endregion properties
    }
}