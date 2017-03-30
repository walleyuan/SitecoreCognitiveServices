using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.VideoSearch;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public interface IVideoSearchRepository {
        VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        Task<VideoSearchResponse> VideoSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        VideoSearchTrendResponse TrendingSearch();
        Task<VideoSearchTrendResponse> TrendingSearchAsync();
        VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested);
        Task<VideoSearchDetailsResponse> VideoDetailsSearchAsync(string id, VideoDetailsModulesOptions modulesRequested);
    }
}