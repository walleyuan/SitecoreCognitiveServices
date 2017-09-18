using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic {
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
 