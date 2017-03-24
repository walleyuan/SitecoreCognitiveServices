using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Language;
using Sitecore.SharedSource.CognitiveServices.Models.Language.WebLanguageModel;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language {
    public class WebLanguageModelRepository : TextClient, IWebLanguageModelRepository {
        
        protected static readonly string weblmUrl = "https://westus.api.cognitive.microsoft.com/text/weblm/v1.0/";

        protected readonly IRepositoryClient RepositoryClient;

        public WebLanguageModelRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
            : base(apiKeys.WebLM)
        {
            RepositoryClient = repoClient;
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="text">The line of text to break into words. If spaces are present, they will be interpreted as hard breaks and maintained, except for leading or trailing spaces, which will be trimmed.</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <param name="maxNumOfCandidatesReturned">Max number of candidates would be returned.If not specified, use default value 5.</param>
        /// <returns></returns>
        public virtual async Task<BreakIntoWordsResponse> BreakIntoWordsAsync(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKey, $"{weblmUrl}breakIntoWords?model={model}&text={text}&order={order}&maxNumOfCandidatesReturned={maxNumOfCandidatesReturned}", "");

            return JsonConvert.DeserializeObject<BreakIntoWordsResponse>(response);
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="request">Request object that specifies the queries</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <returns></returns>
        public virtual async Task<ConditionalProbabilityResponse> CalculateConditionalProbabilityAsync(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKey, $"{weblmUrl}calculateConditionalProbability?model={model}&order={order}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<ConditionalProbabilityResponse>(response);
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="request">Request object that specifies the queries</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <returns></returns>
        public virtual async Task<JointProbabilityResponse> CalculateJointProbabilityAsync(WebLMModelOptions model, JointProbabilityRequest request, int order = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKey, $"{weblmUrl}calculateJointProbability?model={model}&order={order}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<JointProbabilityResponse>(response);
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="words">A string containing a sequence of words from which to generate the list of words likely to follow. The words should be separated by spaces.</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <param name="maxNumOfCandidatesReturned">Max number of candidates would be returned.If not specified, use default value 5.</param>
        /// <returns></returns>
        public virtual async Task<GenerateNextWordsResponse> GenerateNextWordsAsync(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKey, $"{weblmUrl}generateNextWords?model={model}&words={words}&order={order}&maxNumOfCandidatesReturned={maxNumOfCandidatesReturned}", "");

            return JsonConvert.DeserializeObject<GenerateNextWordsResponse>(response);
        }

        public virtual async Task<WebLMModelResponse> ListAvailableModelsAsync()
        {
            var response = await SendGetAsync($"{weblmUrl}models");

            return JsonConvert.DeserializeObject<WebLMModelResponse>(response);
        }
    }
}