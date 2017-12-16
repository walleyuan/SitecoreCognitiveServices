using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch {
    public class NewsSearchCategoryResponse {
        public string _type { get; set; }
        public List<WebSearchNewsResult> Value { get; set; } 
    }
}