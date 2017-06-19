using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Luis.Connector {
    public class Entity {
        /// <summary>
        /// Extension data for overflow of properties
        /// 
        /// </summary>
        [JsonExtensionData(ReadData = true, WriteData = true)]
        public JObject Properties { get; set; } = new JObject();

        /// <summary>
        /// Entity Type (typically from schema.org types)
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the Entity class.
        /// 
        /// </summary>
        public Entity() {
        }

        /// <summary>
        /// Initializes a new instance of the Entity class.
        /// 
        /// </summary>
        public Entity(string type = null) {
            this.Type = type;
        }

        /// <summary>
        /// Retrieve internal payload.
        /// 
        /// </summary>
        /// <typeparam name="T"/>
        /// <returns/>
        public T GetAs<T>() {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject((object)this));
        }

        /// <summary>
        /// Set internal payload.
        /// 
        /// </summary>
        /// <typeparam name="T"/><param name="obj"/>
        public void SetAs<T>(T obj) {
            Entity entity = JsonConvert.DeserializeObject<Entity>(JsonConvert.SerializeObject((object)obj));
            this.Type = entity.Type;
            this.Properties = entity.Properties;
        }
    }
}
