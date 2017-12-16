using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch {
    public class WebSearchRelated
    {
        public string Id { get; set; }
        public List<SimpleSearchResult> Value { get; set; }
    }
}