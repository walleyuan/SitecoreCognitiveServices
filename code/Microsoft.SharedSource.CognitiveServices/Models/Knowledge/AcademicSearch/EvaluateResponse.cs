using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.AcademicSearch {
    public class EvaluateResponse {
        public string Expr { get; set; }
        public List<EvaluateResult> Entities { get; set; } 
    }
}