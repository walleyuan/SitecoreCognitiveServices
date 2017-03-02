
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Models.Search
{
    public interface ICognitiveMediaSearch
    {
        string Database { get; set; }
        string Language { get; set; }

        List<KeyValuePair<string, int>> Tags { get; set; }
    }
}