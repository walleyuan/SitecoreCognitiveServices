using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Bing
{
    public class WebSearchRepository : TextClient, IWebSearchRepository
    {
        public static readonly string webSearchUrl = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/";

        public WebSearchRepository(
            IApiKeys apiKeys)
            : base(apiKeys.BingSearch)
        {
        }

        public WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            return Task.Run(async () => await WebSearchAsync(text, countOffset, languageCode, safeSearch)).Result;
        }

        public async Task<WebSearchResponse> WebSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
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

            var response = await this.SendGetAsync($"{webSearchUrl}?q={text}{sb}");
            
            return JsonConvert.DeserializeObject<WebSearchResponse>(response);
        }
    }
}
 