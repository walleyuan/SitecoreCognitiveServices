using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector {
    public class Attachment : IEquatable<Attachment> {
        /// <summary>
        /// Extension data for overflow of properties
        /// 
        /// </summary>
        [JsonExtensionData(ReadData = true, WriteData = true)]
        public JObject Properties { get; set; } = new JObject();

        /// <summary>
        /// mimetype/Contenttype for the file
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// Content Url
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "contentUrl")]
        public string ContentUrl { get; set; }

        /// <summary>
        /// Embedded content
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public object Content { get; set; }

        /// <summary>
        /// (OPTIONAL) The name of the attachment
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// (OPTIONAL) Thumbnail associated with attachment
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Initializes a new instance of the Attachment class.
        /// 
        /// </summary>
        public Attachment() {
        }

        /// <summary>
        /// Initializes a new instance of the Attachment class.
        /// 
        /// </summary>
        public Attachment(string contentType = null, string contentUrl = null, object content = null, string name = null, string thumbnailUrl = null) {
            this.ContentType = contentType;
            this.ContentUrl = contentUrl;
            this.Content = content;
            this.Name = name;
            this.ThumbnailUrl = thumbnailUrl;
        }

        public bool Equals(Attachment other) {
            if (other != null && this.ContentType == other.ContentType && (this.ContentUrl == other.ContentUrl && object.Equals(this.Content, other.Content)) && object.Equals((object)this.Name, (object)other.Name))
                return object.Equals((object)this.ThumbnailUrl, (object)other.ThumbnailUrl);
            return false;
        }

        public override bool Equals(object other) {
            return this.Equals(other as Attachment);
        }

        public override int GetHashCode() {
            return this.ContentType.GetHashCode() ^ this.ContentUrl.GetHashCode() ^ (this.Content == null ? 13 : this.Content.GetHashCode()) ^ (this.Name == null ? 17 : this.Name.GetHashCode()) ^ (this.ThumbnailUrl == null ? 23 : this.ThumbnailUrl.GetHashCode());
        }
    }
}
