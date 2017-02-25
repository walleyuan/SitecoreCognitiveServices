using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing {
    public class NewsSearchResponse {
        public string _type { get; set; }
        public NewsSearchInstrumentation Instrumentation { get; set; }
        public string ReadLink { get; set; }
        public long TotalEstimatedMatches { get; set; }
        public List<NewsSearchResult> Value { get; set; } 
    }
}