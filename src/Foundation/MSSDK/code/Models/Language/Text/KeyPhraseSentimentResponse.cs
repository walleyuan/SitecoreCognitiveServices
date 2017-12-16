using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class KeyPhraseSentimentResponse
    {
        [JsonProperty("documents")]
        public List<KeyPhraseDocumentResult> Documents { get; set; }

        [JsonProperty("errors")]
        public List<DocumentError> Errors { get; set; }

        public KeyPhraseSentimentResponse()
        {
            this.Documents = new List<KeyPhraseDocumentResult>();
            this.Errors = new List<DocumentError>();
        }
    }
}