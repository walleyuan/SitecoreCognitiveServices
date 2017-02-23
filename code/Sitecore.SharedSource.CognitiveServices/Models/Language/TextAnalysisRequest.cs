using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class TextAnalysisRequest
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("analyzerIds")]
        public string[] AnalyzerIds { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}