using System.Collections.Generic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.NewsSearch {
    public class NewsSearchTrendResponse {
        public string _type { get; set; }
        public MediaInstrumentation Instrumentation { get; set; }
        public List<NewsSearchTopicResult> Value { get; set; }
    }
}