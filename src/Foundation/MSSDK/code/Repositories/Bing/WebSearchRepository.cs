using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Bing
{
    public class WebSearchRepository : IWebSearchRepository
    {
        public static readonly string webSearchUrl = "search";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public WebSearchRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        protected virtual string GetWebSearchQuerystring(int countOffset, string languageCode, SafeSearchOptions safeSearch)
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

        public virtual WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            var qs = GetWebSearchQuerystring(countOffset, languageCode, safeSearch);

            var response = RepositoryClient.SendGet(ApiKeys.BingSearch, $"{ApiKeys.BingSearchEndpoint}{webSearchUrl}?q={text}{qs}");

            return JsonConvert.DeserializeObject<WebSearchResponse>(response);
        }

        public virtual async Task<WebSearchResponse> WebSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            var qs = GetWebSearchQuerystring(countOffset, languageCode, safeSearch);

            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, $"{ApiKeys.BingSearchEndpoint}{webSearchUrl}?q={text}{qs}");
            
            return JsonConvert.DeserializeObject<WebSearchResponse>(response);
        }
    }
}
 