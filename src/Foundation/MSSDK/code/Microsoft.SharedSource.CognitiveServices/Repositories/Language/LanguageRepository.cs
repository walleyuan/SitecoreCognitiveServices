using Microsoft.ProjectOxford.Text.Language;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language
{
    public class LanguageRepository : ILanguageRepository
    {
        protected static readonly string languageUrl = "languages";
        protected readonly IRepositoryClient RepositoryClient;
        protected readonly IApiKeys ApiKeys;

        public LanguageRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        public virtual string GetLanguageUrl(LanguageRequest request)
        {
            return (request.NumberOfLanguagesToDetect > 1)
                 ? $"{ApiKeys.TextAnalyticsEndpoint}{languageUrl}?numberOfLanguagesToDetect={request.NumberOfLanguagesToDetect}"
                 : $"{ApiKeys.TextAnalyticsEndpoint}{languageUrl}";
        }

        public virtual LanguageResponse GetLanguages(LanguageRequest request)
        {   
            var response = RepositoryClient.SendJsonPost(ApiKeys.TextAnalytics, GetLanguageUrl(request), JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<LanguageResponse>(response);
        }

        public virtual async Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.TextAnalytics, GetLanguageUrl(request), JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<LanguageResponse>(response);
        }
    }
}
