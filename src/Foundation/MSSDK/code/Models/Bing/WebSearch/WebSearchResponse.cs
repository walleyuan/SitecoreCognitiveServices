using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchResponse
    {
        public string _type { get; set; }
        public WebSearchPages WebPages { get; set; }
        public WebSearchImages Images { get; set; }
        public WebSearchNews News { get; set; }
        public WebSearchRelated RelatedSearches { get; set; }
        public WebSearchVideos Videos { get; set; }
        public WebSearchRanking RankingResponse { get; set; }
    }
}