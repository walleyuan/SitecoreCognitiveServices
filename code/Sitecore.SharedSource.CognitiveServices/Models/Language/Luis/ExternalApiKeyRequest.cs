using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ExternalApiKeyRequest {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}