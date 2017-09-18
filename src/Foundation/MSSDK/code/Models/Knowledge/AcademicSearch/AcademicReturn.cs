using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch {
    public class AcademicReturn {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        public string Name { get; set; }
    }
}