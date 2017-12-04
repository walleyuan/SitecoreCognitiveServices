using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing
{
    public class AutoSuggestRepository : IAutoSuggestRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public AutoSuggestRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repositoryClient)
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