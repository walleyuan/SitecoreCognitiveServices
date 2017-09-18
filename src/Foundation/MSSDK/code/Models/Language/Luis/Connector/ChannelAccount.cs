using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector {
    public class ChannelAccount : IEquatable<ChannelAccount> {
        /// <summary>
        /// Extension data for overflow of properties
        /// 
        /// </summary>
        [JsonExtensionData(ReadData = true, WriteData = true)]
        public JObject Properties { get; set; } = new JObject();

        /// <summary>
        /// Channel id for the user or bot on this channel (Example:
        ///             joe@smith.com, or @joesmith or 123456)
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Display friendly name
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the ChannelAccount class.
        /// 
        /// </summary>
        public ChannelAccount() {
        }

        /// <summary>
        /// Initializes a new instance of the ChannelAccount class.
        /// 
        /// </summary>
        public ChannelAccount(string id = null, string name = null) {
            this.Id = id;
            this.Name = name;
        }

        public bool Equals(ChannelAccount other) {
            if (other != null && this.Id == other.Id)
                return this.Name == other.Name;
            return false;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as ChannelAccount);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode() ^ this.Name.GetHashCode();
        }
    }
}
