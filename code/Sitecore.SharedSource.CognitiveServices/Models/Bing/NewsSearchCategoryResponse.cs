using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing {
    public class NewsSearchCategoryResponse {
        public string _type { get; set; }
        public List<WebSearchNewsResult> Value { get; set; } 
    }
}