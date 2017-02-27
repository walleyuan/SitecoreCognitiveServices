using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Academic {
    public class AcademicPaper {
        public string Type { get; set; }
        public string NormalizedTitle { get; set; }
        public List<string> Select { get; set; }
    }
}