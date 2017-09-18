using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch {
    public class CalcHistogram {
        public string Value { get; set; }
        public double Prob { get; set; }
        public int Count { get; set; }
    }
}