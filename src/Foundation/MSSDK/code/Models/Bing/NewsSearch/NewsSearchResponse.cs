using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch {
    public class NewsSearchResponse {
        public string _type { get; set; }
        public MediaInstrumentation MediaInstrumentation { get; set; }
        public string ReadLink { get; set; }
        public long TotalEstimatedMatches { get; set; }
        public List<NewsSearchResult> Value { get; set; } 
    }
}