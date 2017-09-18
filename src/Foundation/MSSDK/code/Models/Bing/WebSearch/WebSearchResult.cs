using System;
using System.Collections.Generic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<NameValue> About { get; set; }
        public string DisplayUrl { get; set; }
        public string Snippet { get; set; }
        public List<WebSearchDeepLink> DeepLinks { get; set; }
        public DateTime DateLastCrawled { get; set; }
    }
}