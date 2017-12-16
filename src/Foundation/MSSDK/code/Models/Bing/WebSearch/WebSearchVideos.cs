using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchVideos
    {
        public string Id { get; set; }
        public string ReadLink { get; set; }
        public string WebSearchUrl { get; set; }
        public bool IsFamilyFriendly { get; set; }
        public List<VideoSearchResult> Value { get; set; }
        public string Scenario { get; set; }
    }
}