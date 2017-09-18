using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing {
    public interface IVideoSearchRepository {
        VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        Task<VideoSearchResponse> VideoSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        VideoSearchTrendResponse TrendingSearch();
        Task<VideoSearchTrendResponse> TrendingSearchAsync();
        VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested);
        Task<VideoSearchDetailsResponse> VideoDetailsSearchAsync(string id, VideoDetailsModulesOptions modulesRequested);
    }
}