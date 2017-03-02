
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Search
{
    public class CognitiveMediaSearch : ICognitiveMediaSearch
    {
        public string Database { get; set; }
        public string Language { get; set; }
        public List<KeyValuePair<string, int>> Tags { get; set; }
    }
}