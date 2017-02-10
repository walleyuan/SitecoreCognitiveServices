using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class CognitiveMediaSearch : ICognitiveMediaSearch
    {
        public string Database { get; set; }
        public string Language { get; set; }
    }
}