using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class POSTagsTextAnalysisResponse {
        [JsonProperty("analyzerId")]
        public string AnalyzerId { get; set; }

        [JsonProperty("result")]
        public List<string[]> Result { get; set; }
        /*
        "analyzerId":"4fa79af1-f22c-408d-98bb-b7d7aeef7f04",
	    "result":[["NNP"]]
        */
        
        public POSTagsTextAnalysisResponse() {
            this.AnalyzerId = string.Empty;
            this.Result = new List<string[]>();
        }
    }
}