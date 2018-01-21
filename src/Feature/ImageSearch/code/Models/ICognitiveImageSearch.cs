
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models
{
    public interface ICognitiveImageSearch
    {
        string Database { get; set; }
        string Language { get; set; }

        List<KeyValuePair<string, int>> Tags { get; set; }
        List<string> Colors { get; set; }
    }
}