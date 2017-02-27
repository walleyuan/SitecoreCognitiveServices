using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Academic {
    public class HistogramResult {
        public string Attribute { get; set; }
        public int Distinct_Values { get; set; }
        public int Total_Count { get; set; }
        public List<Histogram> Histogram { get; set; }
    }
}