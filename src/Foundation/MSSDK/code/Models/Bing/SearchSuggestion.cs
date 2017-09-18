using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing
{
    public class SearchSuggestion<T>
    {
        public string Pivot { get; set; }
        public List<T> Suggestions { get; set; }
    }
}