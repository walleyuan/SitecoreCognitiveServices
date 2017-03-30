using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic {
    public class NextWordCandidate
    {
        public string Word { get; set; }
        public double Probability { get; set; }
    }
}