using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class ModelFeature {
        public string Name { get; set; }
        public bool Mode { get; set; }
        public string Words { get; set; }
        public bool Activated { get; set; }
    }
}