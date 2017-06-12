using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.AutoSuggest;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing
{
    public class AutoSuggestRepository : IAutoSuggestRepository
    {
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
            var response = RepositoryClient.SendGet(ApiKeys.BingAutosuggest, $"{ApiKeys.BingAutosuggestEndpoint}?q={text}");

            return JsonConvert.DeserializeObject<AutoSuggestResponse>(response);
        }

        public virtual async Task<AutoSuggestResponse> GetSuggestionsAsync(string text)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingAutosuggest, $"{ApiKeys.BingAutosuggestEndpoint}?q={text}");

            return JsonConvert.DeserializeObject<AutoSuggestResponse>(response);
        }
    }
}