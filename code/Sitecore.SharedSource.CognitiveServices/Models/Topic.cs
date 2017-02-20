using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models {
    public class Topic {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("keyPhrase")]
        public string KeyPhrase { get; set; }
    }
}