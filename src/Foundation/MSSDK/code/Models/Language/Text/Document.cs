using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class Document : IDocument {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonIgnore]
        public int Size
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Text))
                    return 0;
                return Encoding.UTF8.GetByteCount(this.Text);
            }
        }

        [JsonProperty("text")]
        public string Text { get; set; }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context) {
            this.Text = this.Text.Replace("\"", "");
        }

        public override string ToString() {
            return this.Text;
        }
    }
}
