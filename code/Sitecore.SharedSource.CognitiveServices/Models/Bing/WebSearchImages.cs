using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
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