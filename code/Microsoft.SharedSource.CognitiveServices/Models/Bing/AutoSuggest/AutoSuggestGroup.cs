using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.AutoSuggest {
    public class AutoSuggestGroup
    {
        public string Name { get; set; }
        public List<AutoSuggestEntry> SearchSuggestions { get; set; }
    }
}