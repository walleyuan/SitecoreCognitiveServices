using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.VideoSearch;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public class VideoSearchRepository : IVideoSearchRepository {

        public static readonly string videoUrl = "https://api.cognitive.microsoft.com/bing/v5.0/videos/search";
        public static readonly string trendingUrl = "https://api.cognitive.microsoft.com/bing/v5.0/videos/trending";
        public static readonly string detailsUrl = "https://api.cognitive.microsoft.com/bing/v5.0/videos/details";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public VideoSearchRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        #region Video Search

        protected virtual string GetVideoSearchQuerystring(int countOffset, string languageCode, SafeSearchOptions safeSearch)
        {
            StringBuilder sb = new StringBuilder();

            if (countOffset > 0)
                sb.Append($"?countoffset={countOffset}");

            if (!string.IsNullOrEmpty(languageCode)) {
                var concat = (sb.Length > 0) ? "?" : "&";
                sb.Append($"{concat}mkt={languageCode}");
            }

            if (safeSearch != SafeSearchOptions.Off) {
                var concat = (sb.Length > 0) ? "?" : "&";
                sb.Append($"{concat}safeSearch={Enum.GetName(typeof(SafeSearchOptions), safeSearch)}");
            }

            return sb.ToString();
        }

        public virtual VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off) {
            var qs = GetVideoSearchQuerystring(countOffset, languageCode, safeSearch);

            var response = RepositoryClient.SendGet(ApiKeys.BingSearch, $"{videoUrl}?q={text}{qs}");

            return JsonConvert.DeserializeObject<VideoSearchResponse>(response);
        }

        public virtual async Task<VideoSearchResponse> VideoSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            var qs = GetVideoSearchQuerystring(countOffset, languageCode, safeSearch);

            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, $"{videoUrl}?q={text}{qs}");

            return JsonConvert.DeserializeObject<VideoSearchResponse>(response);
        }

        #endregion Video Search

        #region Trending Videos Search

        public virtual VideoSearchTrendResponse TrendingSearch() {
            var response = RepositoryClient.SendGet(ApiKeys.BingSearch, trendingUrl);

            return JsonConvert.DeserializeObject<VideoSearchTrendResponse>(response);
        }

        public virtual async Task<VideoSearchTrendResponse> TrendingSearchAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, trendingUrl);

            return JsonConvert.DeserializeObject<VideoSearchTrendResponse>(response);
        }

        #endregion Trending Videos Search

        #region Video Details Search

        public virtual VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested) {
            var response = RepositoryClient.SendGet(ApiKeys.BingSearch, $"{detailsUrl}?id={id}&modulesRequested={Enum.GetName(typeof(VideoDetailsModulesOptions), modulesRequested)}");

            return JsonConvert.DeserializeObject<VideoSearchDetailsResponse>(response);
        }

        public virtual async Task<VideoSearchDetailsResponse> VideoDetailsSearchAsync(string id, VideoDetailsModulesOptions modulesRequested) {
            
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, $"{detailsUrl}?id={id}&modulesRequested={Enum.GetName(typeof(VideoDetailsModulesOptions), modulesRequested)}");

            return JsonConvert.DeserializeObject<VideoSearchDetailsResponse>(response);
        }

        #endregion Video Details Search
    }
}