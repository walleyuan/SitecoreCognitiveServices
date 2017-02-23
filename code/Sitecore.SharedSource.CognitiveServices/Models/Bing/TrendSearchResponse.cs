using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class TrendSearchResponse
    {
        public string _type { get; set; }
        public ImageSearchInstrumentation Instrumentation { get; set; }
        public List<ImageSearchCategory> Categories { get; set; }
    }
}