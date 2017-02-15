using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ICognitiveMediaSearchFactory
    {
        ICognitiveMediaSearch CreateMediaSearch();
        ICognitiveMediaSearch CreateMediaSearch(string db, string language);
        ICognitiveMediaSearchJsonResult CreateMediaSearchJsonResult(ISitecoreDataService dataService, ICognitiveSearchResult searchResult);
    }
}