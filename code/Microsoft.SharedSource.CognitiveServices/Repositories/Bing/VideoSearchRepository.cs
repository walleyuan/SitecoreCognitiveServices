using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.VideoSearch;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public class VideoSearchRepository : TextClient, IVideoSearchRepository {

        public static readonly string videoUrl = "https://api.cognitive.microsoft.com/bing/v5.0/videos/search";
        public static readonly string trendingUrl = "https://api.cognitive.microsoft.com/bing/v5.0/videos/trending";
        public static readonly string detailsUrl = "https://api.cognitive.microsoft.com/bing/v5.0/videos/details";

        public VideoSearchRepository(
            IApiKeys apiKeys)
            : base(apiKeys.BingSearch)
        {
        }

        #region Video Search

        public virtual VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off) {
            return Task.Run(async () => await VideoSearchAsync(text, countOffset, languageCode, safeSearch)).Result;
        }

        public virtual async Task<VideoSearchResponse> VideoSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off) {

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

            var response = await SendGetAsync($"{videoUrl}?q={text}{sb}");

            return JsonConvert.DeserializeObject<VideoSearchResponse>(response);
        }

        #endregion Video Search

        #region Trending Videos Search

        public virtual VideoSearchTrendResponse TrendingSearch() {
            return Task.Run(async () => await TrendingSearchAsync()).Result;
        }

        public virtual async Task<VideoSearchTrendResponse> TrendingSearchAsync() {
            var response = await SendGetAsync(trendingUrl);

            return JsonConvert.DeserializeObject<VideoSearchTrendResponse>(response);
        }

        #endregion Trending Videos Search

        #region Video Details Search

        public virtual VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested) {
            return Task.Run(async () => await VideoDetailsSearchAsync(id, modulesRequested)).Result;
        }

        public virtual async Task<VideoSearchDetailsResponse> VideoDetailsSearchAsync(string id, VideoDetailsModulesOptions modulesRequested) {
            
            var response = await SendGetAsync($"{detailsUrl}?id={id}&modulesRequested={Enum.GetName(typeof(VideoDetailsModulesOptions), modulesRequested)}");

            return JsonConvert.DeserializeObject<VideoSearchDetailsResponse>(response);
        }

        #endregion Video Details Search
    }
}