using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing
{
    public interface IWebSearchService
    {
        WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}