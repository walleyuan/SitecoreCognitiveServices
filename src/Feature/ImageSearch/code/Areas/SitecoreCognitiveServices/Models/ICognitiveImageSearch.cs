
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models
{
    public interface ICognitiveImageSearch
    {
        string Database { get; set; }
        string Language { get; set; }

        List<KeyValuePair<string, int>> Tags { get; set; }
        List<KeyValuePair<string, string>> Colors { get; set; }
    }
}