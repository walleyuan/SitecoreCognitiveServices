using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public class SentimentDocumentResult {
        [JsonProperty("keyPhrases")]
        public string[] KeyPhrases { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}