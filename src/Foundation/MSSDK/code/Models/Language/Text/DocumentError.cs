using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public class DocumentError {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
