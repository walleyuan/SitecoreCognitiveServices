using System.Collections.Generic;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Sentiment {
    public class TopicRequest : TextRequest
    {
        public TopicRequest() {
            Documents = new List<IDocument>();
            StopWords = new List<string>();
            TopicsToExclude = new List<string>();
        }

        [JsonProperty("stopWords")]
        public List<string> StopWords { get; set; }

        [JsonProperty("topicsToExclude")]
        public List<string> TopicsToExclude { get; set; }
    }
}