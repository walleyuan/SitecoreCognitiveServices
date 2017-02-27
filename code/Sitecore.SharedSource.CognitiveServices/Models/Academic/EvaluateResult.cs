using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Academic {
    public class EvaluateResult {
        public double Prob { get; set; }
        public string Ti { get; set; }
        public int Y { get; set; }
        public int CC { get; set; }
        public List<AA> AA { get; set; }
    }
}