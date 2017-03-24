using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.Models.Bing.WebSearch;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing.NewsSearch {
    public class NewsSearchCategoryResponse {
        public string _type { get; set; }
        public List<WebSearchNewsResult> Value { get; set; } 
    }
}