using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class OperationProcessingResult {
        [JsonProperty("topics")]
        public List<Topic> Topics { get; set; }
        [JsonProperty("topicAssignments")]
        public List<TopicAssignment> TopicAssignments { get; set; }
    }
}