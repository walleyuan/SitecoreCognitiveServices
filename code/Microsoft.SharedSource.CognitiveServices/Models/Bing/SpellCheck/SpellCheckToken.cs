using System.Collections.Generic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.SpellCheck {
    public class SpellCheckToken
    {
        public int Offset { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public List<SpellCheckSuggestion> Suggestions { get; set; }
    }
}