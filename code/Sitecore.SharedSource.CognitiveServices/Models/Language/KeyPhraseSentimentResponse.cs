using System.Collections.Generic;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
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