using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch {
    public class CalcHistogram {
        public string Value { get; set; }
        public double Prob { get; set; }
        public int Count { get; set; }
    }
}