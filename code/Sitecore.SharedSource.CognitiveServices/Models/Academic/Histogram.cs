using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Academic {
    public class Histogram {
        public int Value { get; set; }
        public double Prob { get; set; }
        public int Count { get; set; }
    }
}