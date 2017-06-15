using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.ImageSearch
{
    public class BestRepresentativeQuery
    {
        public string Text { get; set; }
        public string DisplayText { get; set; }
        public string WebSearchQuery { get; set; }
    }
}