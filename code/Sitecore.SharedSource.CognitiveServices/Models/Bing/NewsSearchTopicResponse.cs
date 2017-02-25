using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing {
    public class NewsSearchTopicResponse {
        public string _type { get; set; }
        public NewsSearchInstrumentation Instrumentation { get; set; }
        public List<NewsSearchTopicResult> Value { get; set; }
    }
}