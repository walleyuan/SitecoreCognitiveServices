using System.Collections.Generic;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.SpellCheck
{
    public class SpellCheckResponse
    {
        public string _type { get; set; }
        public List<SpellCheckToken> FlaggedTokens { get; set; }
    }
}