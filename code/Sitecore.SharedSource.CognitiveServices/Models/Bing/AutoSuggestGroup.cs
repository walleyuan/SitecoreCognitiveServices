using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class AutoSuggestGroup
    {
        public string Name { get; set; }
        public List<AutoSuggestEntry> SearchSuggestions { get; set; }
    }
}