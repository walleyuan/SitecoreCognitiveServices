using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class IntentPrediction {
        public string Name { get; set; }
        public float Score { get; set; }
    }
}