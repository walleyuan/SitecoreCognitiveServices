
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Models
{
    public interface ICognitiveImageSearch
    {
        string Database { get; set; }
        string Language { get; set; }

        List<KeyValuePair<string, int>> Tags { get; set; }
    }
}