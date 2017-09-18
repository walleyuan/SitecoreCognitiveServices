using Newtonsoft.Json;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic {
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