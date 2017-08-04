using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.AcademicSearch {
    public class CalcHistogramResponse {
        public string Expr { get; set; }
        public int Num_Entities { get; set; }
        public List<CalcHistogramResult> Histograms { get; set; } 
    }
}