using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class ImageSearchSuggestion
    {
        public string Pivot { get; set; }
        public List<ImageSearchShortResult> Suggestions { get; set; }
    }
}