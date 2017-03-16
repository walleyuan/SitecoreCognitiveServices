using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge {
    public class AcademicPaper {
        [JsonProperty(PropertyName = "type")]

        public string Type { get; set; }
        public string NormalizedTitle { get; set; }
        [JsonProperty(PropertyName = "select")]
        public List<string> Select { get; set; }
    }
}