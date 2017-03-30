using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.WebSearch;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.NewsSearch {
    public class NewsSearchCategoryResponse {
        public string _type { get; set; }
        public List<WebSearchNewsResult> Value { get; set; } 
    }
}