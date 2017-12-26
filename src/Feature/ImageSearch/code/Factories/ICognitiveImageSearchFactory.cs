using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Feature.ImageSearch.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface ICognitiveImageSearchFactory
    {
        ICognitiveImageSearch Create();
        ICognitiveImageSearch Create(string db, string language, IImageSearchService searchService);
        ICognitiveImageSearchJsonResult CreateMediaSearchJsonResult(ISitecoreDataWrapper dataWrapper, ICognitiveImageSearchResult searchResult);
    }
}