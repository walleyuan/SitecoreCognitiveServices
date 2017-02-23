using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language
{
    public class ResultSet {
        [JsonProperty("Len")]
        public string Len { get; set; }
        [JsonProperty("Offset")]
        public int Offset { get; set; }
        [JsonProperty("Tokens")]
        public List<TokenResult> Tokens { get; set; }
    }
}