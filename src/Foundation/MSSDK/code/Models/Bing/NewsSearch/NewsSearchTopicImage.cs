using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch {
    public class NewsSearchTopicImage {
        public string Url { get; set; }
        public List<NewsProvider> Provider { get; set; }
    }
}