using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge {
    public class AcademicAuthor {
        [JsonProperty(PropertyName = "return")]
        public AcademicReturn Return { get; set; }
    }
}