using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector {
    public class ConversationAccount : IEquatable<ConversationAccount> {
        /// <summary>
        /// Extension data for overflow of properties
        /// 
        /// </summary>
        [JsonExtensionData(ReadData = true, WriteData = true)]
        public JObject Properties { get; set; } = new JObject();

        /// <summary>
        /// Is this a reference to a group
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "isGroup")]
        public bool? IsGroup { get; set; }

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
        /// Initializes a new instance of the ConversationAccount class.
        /// 
        /// </summary>
        public ConversationAccount() {
        }

        public ConversationAccount(bool? isGroup = null, string id = null, string name = null) {
            this.IsGroup = isGroup;
            this.Id = id;
            this.Name = name;
        }

        public bool Equals(ConversationAccount other) {
            if (other == null || !(this.Id == other.Id) || !(this.Name == other.Name))
                return false;
            bool? isGroup1 = this.IsGroup;
            bool? isGroup2 = other.IsGroup;
            if (isGroup1.GetValueOrDefault() != isGroup2.GetValueOrDefault())
                return false;
            return isGroup1.HasValue == isGroup2.HasValue;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as ConversationAccount);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode() ^ this.Name.GetHashCode() ^ this.IsGroup.GetHashCode();
        }
    }
}
