using Newtonsoft.Json;
using System;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class CompositeChild {
        /// <summary>
        /// Type of child entity.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Value extracted by Luis.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the CompositeChild class.
        /// 
        /// </summary>
        public CompositeChild() {
        }

        /// <summary>
        /// Initializes a new instance of the CompositeChild class.
        /// 
        /// </summary>
        public CompositeChild(string type, string value) {
            this.Type = type;
            this.Value = value;
        }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// 
        /// </summary>
        public virtual void Validate() {
            if (this.Type == null)
                throw new Exception("Type Cannot Be Null");
            if (this.Value == null)
                throw new Exception("Value Cannot Be Null");
        }
    }
}
