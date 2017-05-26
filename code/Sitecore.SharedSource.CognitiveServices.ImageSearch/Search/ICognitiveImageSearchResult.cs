using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public interface ICognitiveImageSearchResult : ICognitiveSearchResult
    {
        int Gender { get; set; }
        int Size { get; set; }
        List<int> Glasses { get; set; }
        string[] Tags { get; set; }
        double AgeMin { get; set; }
        double AgeMax { get; set; }
    }
}