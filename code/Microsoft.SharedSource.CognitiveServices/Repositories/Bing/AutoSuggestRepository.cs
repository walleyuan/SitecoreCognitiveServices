using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.AutoSuggest;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing
{
    public class AutoSuggestRepository : IAutoSuggestRepository
    {
        public static readonly string suggestUrl = "https://api.cognitive.microsoft.com/bing/v5.0/suggestions/";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public AutoSuggestRepository(
            IApiKeys apiKeys,
            IRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual AutoSuggestResponse GetSuggestions(string text)
        {
            return Task.Run(async () => await GetSuggestionsAsync(text)).Result;
        }

        public virtual async Task<AutoSuggestResponse> GetSuggestionsAsync(string text)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingAutosuggest, $"{suggestUrl}?q={text}");

            return JsonConvert.DeserializeObject<AutoSuggestResponse>(response);
        }
    }
}