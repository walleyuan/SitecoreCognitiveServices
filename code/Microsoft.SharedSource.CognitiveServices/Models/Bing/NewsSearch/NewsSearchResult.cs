using System;
using System.Collections.Generic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.NewsSearch {
    public class NewsSearchResult {
        public string Name { get; set; }
        public string Url { get; set; }
        public string UrlPingSuffix { get; set; }
        public NewsSearchImage Image { get; set; }
        public string Description { get; set; }
        public List<NewsAbout> About { get; set; }
        public List<NewsProvider> Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
    }
}