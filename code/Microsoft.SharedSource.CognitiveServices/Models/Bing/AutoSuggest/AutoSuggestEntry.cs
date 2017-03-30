using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.AutoSuggest
{
    public class AutoSuggestEntry
    {
        public string Url { get; set; }
        public string DisplayText { get; set; }
        public string Query { get; set; }
        public string SearchKind { get; set; }
    }
}