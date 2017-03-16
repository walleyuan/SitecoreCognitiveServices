using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge {
    public class AcademicReturn {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        public string Name { get; set; }
    }
}