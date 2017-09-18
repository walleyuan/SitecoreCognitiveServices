using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest {   
    public class AutoSuggestResponse
    {
        public string _type { get; set; }
        public AutoSuggestQuery QueryContext { get; set; }
        public List<AutoSuggestGroup> SuggestionGroups { get; set; }
    }
}