using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchNewsResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public WebSearchNewsImage Image { get; set; }
        public string Description { get; set; }
        public List<NewsAbout> About { get; set; }
        public List<NewsProvider> Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
        public List<WebSearchNewsCluster> ClusteredArticles { get; set; }
    }
}