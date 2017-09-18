using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text {
    public class SentimentResponse {
        [JsonProperty("documents")]
        public List<SentimentDocumentResult> Documents { get; set; }

        [JsonProperty("errors")]
        public List<DocumentError> Errors { get; set; }

        public SentimentResponse() {
            this.Documents = new List<SentimentDocumentResult>();
            this.Errors = new List<DocumentError>();
        }
    }
}
