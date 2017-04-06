using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.WebSearch;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing
{
    public class WebSearchRepository : IWebSearchRepository
    {
        public static readonly string webSearchUrl = "https://api.cognitive.microsoft.com/bing/v5.0/search";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public WebSearchRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }
        
        public virtual WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            return Task.Run(async () => await WebSearchAsync(text, countOffset, languageCode, safeSearch)).Result;
        }

        public virtual async Task<WebSearchResponse> WebSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            StringBuilder sb = new StringBuilder();

            if (countOffset > 0)
                sb.Append($"?countoffset={countOffset}");
            
            if (!string.IsNullOrEmpty(languageCode))
            {
                var concat = (sb.Length > 0) ? "?" : "&";
                sb.Append($"{concat}mkt={languageCode}");
            }

            if (safeSearch != SafeSearchOptions.Off)
            {
                var concat = (sb.Length > 0) ? "?" : "&";
                sb.Append($"{concat}safeSearch={Enum.GetName(typeof(SafeSearchOptions), safeSearch)}");
            }

            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, $"{webSearchUrl}?q={text}{sb}");
            
            return JsonConvert.DeserializeObject<WebSearchResponse>(response);
        }
    }
}
 