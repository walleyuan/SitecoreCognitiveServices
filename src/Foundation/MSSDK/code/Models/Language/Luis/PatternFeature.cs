using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class PatternFeature {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pattern { get; set; }
        public bool IsActive { get; set; }
    }
}