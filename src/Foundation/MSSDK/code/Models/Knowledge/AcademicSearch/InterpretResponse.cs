using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch {
    public class InterpretResponse
    {
        public string Query { get; set; }
        public List<InterpretResult> Interpretations { get; set; }
    }
}