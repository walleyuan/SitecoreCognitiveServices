using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class EntityExtractorSublist {
        public string CanonicalForm { get; set; }
        public string[] List { get; set; }
    }
}