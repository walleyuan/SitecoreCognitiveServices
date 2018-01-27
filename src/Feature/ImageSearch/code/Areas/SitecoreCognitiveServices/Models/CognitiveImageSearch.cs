
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models
{
    public class CognitiveImageSearch : ICognitiveImageSearch
    {
        public string Database { get; set; }
        public string Language { get; set; }
        public List<KeyValuePair<string, int>> Tags { get; set; }
        public List<KeyValuePair<string, string>> Colors { get; set; }
    }
}