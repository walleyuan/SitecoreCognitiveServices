using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Sentiment;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
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

    public class SentimentDocumentResult
    {
        [JsonProperty("keyPhrases")]
        public string[] KeyPhrases { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}