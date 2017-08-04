using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic {
    public class ConstituencyTreeTextAnalysisResponse {
        [JsonProperty("analyzerId")]
        public string AnalyzerId { get; set; }

        [JsonProperty("result")]
        public string[] Result { get; set; }
        /*
        "analyzerId":"22a6b758-420f-4745-8a3c-46835a67c0d2",
	    "result":["(NNP (NNP Home))"]
        */

        public ConstituencyTreeTextAnalysisResponse() {
            this.AnalyzerId = string.Empty;
            this.Result = new string[0];
        }
    }
}