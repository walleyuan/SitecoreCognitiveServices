using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch {
    public class AcademicAuthor {
        [JsonProperty(PropertyName = "return")]
        public AcademicReturn Return { get; set; }
    }
}