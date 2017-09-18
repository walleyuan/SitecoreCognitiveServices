using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.WebLanguageModel {
    public class JointProbability
    {
        public string Words { get; set; }
        public double Probability { get; set; }
    }
}