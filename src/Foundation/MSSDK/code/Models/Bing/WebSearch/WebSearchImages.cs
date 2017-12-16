using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.ImageSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchImages
    {
        public string Id { get; set; }
        public string ReadLink { get; set; }
        public string WebSearchUrl { get; set; }
        public bool IsFamilyFriendly { get; set; }
        public List<ImageSearchResult> Value { get; set; }
        public bool DisplayShoppingSourcesBadges { get; set; }
        public bool DisplayRecipeSourcesBadges { get; set; }
    }
}