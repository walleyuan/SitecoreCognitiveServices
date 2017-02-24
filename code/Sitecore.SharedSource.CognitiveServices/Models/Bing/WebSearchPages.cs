using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class WebSearchPages
    {
        public string WebSearchUrl { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public List<WebSearchResult> Value { get; set; }
    }
}