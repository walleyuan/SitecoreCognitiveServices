using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Academic {
    public class GraphSearchRequest {
        public string Path { get; set; }
        public AcademicPaper Paper { get; set; }      
        public AcademicAuthor Author { get; set; }
    }
}