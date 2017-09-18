using System.Collections.Generic;
using Newtonsoft.Json;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text {
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