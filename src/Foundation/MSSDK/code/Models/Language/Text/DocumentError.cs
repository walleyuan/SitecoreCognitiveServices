using Newtonsoft.Json;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class DocumentError {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
