using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Search;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ICognitiveMediaSearchFactory
    {
        ICognitiveMediaSearch Create();
        ICognitiveMediaSearch Create(string db, string language, ICognitiveSearchContext searcher);
        ICognitiveMediaSearchJsonResult CreateMediaSearchJsonResult(ISitecoreDataService dataService, ICognitiveSearchResult searchResult);
    }
}