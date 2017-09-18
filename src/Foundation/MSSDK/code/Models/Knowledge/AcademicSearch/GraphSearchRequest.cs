using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch {
    public class GraphSearchRequest {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
        [JsonProperty(PropertyName = "paper")]
        public AcademicPaper Paper { get; set; }
        [JsonProperty(PropertyName = "author")]
        public AcademicAuthor Author { get; set; }
    }
}