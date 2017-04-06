using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.SpellCheck;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public class SpellCheckRepository : ISpellCheckRepository
    {
        public static readonly string spellCheckUrl = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public SpellCheckRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        public virtual SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            return Task.Run(async () => await SpellCheckAsync(text, mode, languageCode)).Result;
        }

        public virtual async Task<SpellCheckResponse> SpellCheckAsync(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            StringBuilder sb = new StringBuilder();
            if (mode != SpellCheckModeOptions.None)
                sb.Append($"?mode={Enum.GetName(typeof(SpellCheckModeOptions), mode)}");

            if (!string.IsNullOrEmpty(languageCode))
            {
                var concat = (sb.Length > 0) ? "?" : "&";
                sb.Append($"{concat}mkt={languageCode}");
            }
                    
            var response = await RepositoryClient.SendEncodedFormPostAsync(ApiKeys.BingSpellCheck, $"{spellCheckUrl}{sb}", $"Text={text}");

            return JsonConvert.DeserializeObject<SpellCheckResponse>(response);
        }
    }
}