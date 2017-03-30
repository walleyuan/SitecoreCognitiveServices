using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.WebLanguageModel {
    public class ConditionalProbablity
    {
        public string Words { get; set; }
        public string Word { get; set; }
        public double Probability { get; set; }
    }
}