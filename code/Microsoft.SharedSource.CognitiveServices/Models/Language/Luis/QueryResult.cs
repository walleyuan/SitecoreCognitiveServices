using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    public class QueryResult {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "topScoringIntent")]
        public IntentRecommendation TopScoringIntent { get; set; }

        [JsonProperty(PropertyName = "intents")]
        public IList<IntentRecommendation> Intents { get; set; }

        [JsonProperty(PropertyName = "entities")]
        public IList<EntityRecommendation> Entities { get; set; }

        [JsonProperty(PropertyName = "compositeEntities")]
        public IList<CompositeEntity> CompositeEntities { get; set; }

        [JsonProperty(PropertyName = "dialog")]
        public DialogResponse Dialog { get; set; }

        [JsonProperty(PropertyName = "alteredQuery")]
        public string AlteredQuery { get; set; }
    }
}