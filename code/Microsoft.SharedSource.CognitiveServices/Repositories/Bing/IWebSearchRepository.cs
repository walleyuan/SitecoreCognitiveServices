using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.WebSearch;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public interface IWebSearchRepository
    {
        WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        Task<WebSearchResponse> WebSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}