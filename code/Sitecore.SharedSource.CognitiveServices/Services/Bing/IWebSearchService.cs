using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.WebSearch;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public interface IWebSearchService
    {
        WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}