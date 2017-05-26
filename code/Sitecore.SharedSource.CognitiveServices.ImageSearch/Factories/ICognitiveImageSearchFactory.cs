using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories
{
    public interface ICognitiveImageSearchFactory
    {
        ICognitiveImageSearch Create();
        ICognitiveImageSearch Create(string db, string language, ICognitiveImageSearchContext searcher);
        ICognitiveImageSearchJsonResult CreateMediaSearchJsonResult(ISitecoreDataWrapper dataWrapper, ICognitiveImageSearchResult searchResult);
    }
}