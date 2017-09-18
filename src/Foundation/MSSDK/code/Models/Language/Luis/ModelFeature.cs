using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class ModelFeature {
        public string Name { get; set; }
        public bool Mode { get; set; }
        public string Words { get; set; }
        public bool Activated { get; set; }
    }
}