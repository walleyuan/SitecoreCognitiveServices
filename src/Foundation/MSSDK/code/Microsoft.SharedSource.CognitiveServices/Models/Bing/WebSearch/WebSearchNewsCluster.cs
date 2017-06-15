using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.NewsSearch;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.WebSearch {
    public class WebSearchNewsCluster
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public List<NewsProvider> Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
    }
}