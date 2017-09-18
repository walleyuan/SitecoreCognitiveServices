using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class CompositeEntity {
        /// <summary>
        /// Type of parent entity.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "parentType")]
        public string ParentType { get; set; }

        /// <summary>
        /// Value for entity extracted by LUIS.
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary/>
        [JsonProperty(PropertyName = "children")]
        public IList<CompositeChild> Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the CompositeEntity class.
        /// 
        /// </summary>
        public CompositeEntity() {
        }

        public CompositeEntity(string parentType, string value, IList<CompositeChild> children) {
            this.ParentType = parentType;
            this.Value = value;
            this.Children = children;
        }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// 
        /// </summary>
        public virtual void Validate() {
            if (this.ParentType == null)
                throw new Exception("Parent Type Cannot Be Null");
            if (this.Value == null)
                throw new Exception("Value Cannot Be Null");
            if (this.Children == null)
                throw new Exception("Children Cannot Be Null");
            if (this.Children == null)
                return;
            foreach (CompositeChild compositeChild in (IEnumerable<CompositeChild>)this.Children) {
                if (compositeChild != null)
                    compositeChild.Validate();
            }
        }
    }
}
