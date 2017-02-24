using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class SpellCheckResponse
    {
        public string _type { get; set; }
        public List<SpellCheckToken> FlaggedTokens { get; set; }
    }
}