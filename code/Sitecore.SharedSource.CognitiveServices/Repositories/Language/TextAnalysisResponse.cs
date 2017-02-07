using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class POSTagsTextAnalysisResponse
    {
        [JsonProperty("analyzerId")]
        public string AnalyzerId { get; set; }

        [JsonProperty("result")]
        public List<string[]> Result { get; set; }
        /*
        "analyzerId":"4fa79af1-f22c-408d-98bb-b7d7aeef7f04",
	    "result":[["NNP"]]
        */


        public POSTagsTextAnalysisResponse()
        {
            this.AnalyzerId = string.Empty;
            this.Result = new List<string[]>();
        }
    }

    public class ConstituencyTreeTextAnalysisResponse
    {
        [JsonProperty("analyzerId")]
        public string AnalyzerId { get; set; }

        [JsonProperty("result")]
        public string[] Result { get; set; }
        /*
        "analyzerId":"22a6b758-420f-4745-8a3c-46835a67c0d2",
	    "result":["(NNP (NNP Home))"]
        */ 
        
        public ConstituencyTreeTextAnalysisResponse()
        {
            this.AnalyzerId = string.Empty;
            this.Result = new string[0];
        }
    }

    public class TokensTextAnalysisResponse
    {
        [JsonProperty("analyzerId")]
        public string AnalyzerId { get; set; }

        [JsonProperty("result")]
        public List<ResultSet> Result { get; set; }
        /*
        "analyzerId":"08ea174b-bfdb-4e64-987e-602f85da7f72",
	    "result":[{"Len":4,"Offset":0,"Tokens":[{"Len":4,"NormalizedToken":"Home","Offset":0,"RawToken":"Home"}]}] 
        */

        public TokensTextAnalysisResponse()
        {
            this.AnalyzerId = string.Empty;
            this.Result = new List<ResultSet>();
        }
    }

    public class ResultSet
    {
        [JsonProperty("Len")]
        public string Len { get; set; }
        [JsonProperty("Offset")]
        public int Offset { get; set; }
        [JsonProperty("Tokens")]
        public List<TokenResult> Tokens { get; set; }
    }

    public class TokenResult
    {
        [JsonProperty("Len")]
        public string Len { get; set; }
        [JsonProperty("NormalizedToken")]
        public string NormalizedToken { get; set; }
        [JsonProperty("Offset")]
        public int Offset { get; set; }
        [JsonProperty("RawToken")]
        public string RawToken { get; set; }
    }
}
 