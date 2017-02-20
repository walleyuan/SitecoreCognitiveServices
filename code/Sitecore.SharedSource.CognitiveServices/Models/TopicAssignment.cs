using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models {
    public class TopicAssignment {
        [JsonProperty("topicId")]
        public Guid TopicId { get; set; }
        [JsonProperty("documentId")]
        public int DocumentId { get; set; }
        [JsonProperty("distance")]
        public double Distance { get; set; }
    }
}