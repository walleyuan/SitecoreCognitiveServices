using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Bing {
    public class SpellCheckRepository : TextClient, ISpellCheckRepository
    {
        public static readonly string spellCheckUrl = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/";

        protected readonly IRepositoryClient RepositoryClient;

        public SpellCheckRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
            : base(apiKeys.BingSpellCheck)
        {
            RepositoryClient = repoClient;
        }

        public SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            return Task.Run(async () => await SpellCheckAsync(text, mode, languageCode)).Result;
        }

        public async Task<SpellCheckResponse> SpellCheckAsync(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            StringBuilder sb = new StringBuilder();
            if (mode != SpellCheckModeOptions.None)
                sb.Append($"?mode={Enum.GetName(typeof(SpellCheckModeOptions), mode)}");

            if (!string.IsNullOrEmpty(languageCode))
            {
                var concat = (sb.Length > 0) ? "?" : "&";
                sb.Append($"{concat}mkt={languageCode}");
            }
                    
            var response = await RepositoryClient.SendEncodedFormPostAsync(this.ApiKey, $"{spellCheckUrl}{sb}", $"Text={text}");

            return JsonConvert.DeserializeObject<SpellCheckResponse>(response);
        }
    }
}