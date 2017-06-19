using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Text {
    public class KeyPhraseSentimentResponse
    {
        [JsonProperty("documents")]
        public List<SentimentDocumentResult> Documents { get; set; }

        [JsonProperty("errors")]
        public List<DocumentError> Errors { get; set; }

        public KeyPhraseSentimentResponse()
        {
            this.Documents = new List<SentimentDocumentResult>();
            this.Errors = new List<DocumentError>();
        }
    }
}