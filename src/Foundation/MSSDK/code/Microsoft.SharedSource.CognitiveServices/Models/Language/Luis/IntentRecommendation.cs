using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis {
    [Serializable]
    public class IntentRecommendation {
        /// <summary>
        /// The LUIS intent detected by LUIS service in response to a query.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "intent")]
        public string Intent { get; set; }

        /// <summary>
        /// The score for the detected intent.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public double? Score { get; set; }

        /// <summary>
        /// The action associated with this Luis intent.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "actions")]
        public IList<Action> Actions { get; set; }

        /// <summary>
        /// Initializes a new instance of the IntentRecommendation class.
        /// 
        /// </summary>
        public IntentRecommendation() {
        }

        public IntentRecommendation(string intent = null, double? score = null, IList<Action> actions = null) {
            this.Intent = intent;
            this.Score = score;
            this.Actions = actions;
        }
    }
}
