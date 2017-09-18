using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic {
    public class TokensTextAnalysisResponse {
        [JsonProperty("analyzerId")]
        public string AnalyzerId { get; set; }

        [JsonProperty("result")]
        public List<ResultSet> Result { get; set; }
        /*
        "analyzerId":"08ea174b-bfdb-4e64-987e-602f85da7f72",
	    "result":[{"Len":4,"Offset":0,"Tokens":[{"Len":4,"NormalizedToken":"Home","Offset":0,"RawToken":"Home"}]}] 
        */

        public TokensTextAnalysisResponse() {
            this.AnalyzerId = string.Empty;
            this.Result = new List<ResultSet>();
        }
    }
}