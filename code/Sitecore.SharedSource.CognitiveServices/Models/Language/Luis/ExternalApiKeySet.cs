using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ExternalApiKeySet {
        public string Type { get; set; }
        public List<string> Values { get; set; }
    }
}