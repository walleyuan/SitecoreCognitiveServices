using System.Collections.Generic;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch {
    public class NewsSearchCategoryResponse {
        public string _type { get; set; }
        public List<WebSearchNewsResult> Value { get; set; } 
    }
}