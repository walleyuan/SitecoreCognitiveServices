using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ComplexEntityRequest {
        public string Name { get; set; }
        public string[] Children { get; set; }
    }
}