using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    [Serializable]
    public class EntityRecommendation {
        /// <summary>
        /// Role of the entity.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        /// <summary>
        /// Entity extracted by LUIS.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "entity")]
        public string Entity { get; set; }

        /// <summary>
        /// Type of the entity.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Start index of the entity in the LUIS query string.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "startIndex")]
        public int? StartIndex { get; set; }

        /// <summary>
        /// End index of the entity in the LUIS query string.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "endIndex")]
        public int? EndIndex { get; set; }

        /// <summary>
        /// Score assigned by LUIS to detected entity.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public double? Score { get; set; }

        /// <summary>
        /// A machine interpretable resolution of the entity.  For example the
        ///             string "one thousand" would have the resolution "1000".  The
        ///             exact form of the resolution is defined by the entity type and is
        ///             documented here: https://www.luis.ai/Help#PreBuiltEntities.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "resolution")]
        public IDictionary<string, object> Resolution { get; set; }

        /// <summary>
        /// Initializes a new instance of the EntityRecommendation class.
        /// 
        /// </summary>
        public EntityRecommendation() {
        }

        public EntityRecommendation(string type, string role = null, string entity = null, int? startIndex = null, int? endIndex = null, double? score = null, IDictionary<string, object> resolution = null) {
            this.Role = role;
            this.Entity = entity;
            this.Type = type;
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;
            this.Score = score;
            this.Resolution = resolution;
        }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// 
        /// </summary>
        public virtual void Validate() {
            if (this.Type == null)
                throw new Exception("Type Cannot Be Null");
        }
    }
}
