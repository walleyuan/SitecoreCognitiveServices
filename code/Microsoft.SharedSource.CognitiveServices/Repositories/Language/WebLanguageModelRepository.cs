using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Language.WebLanguageModel;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language {
    public class WebLanguageModelRepository : IWebLanguageModelRepository {
        
        protected static readonly string weblmUrl = "https://westus.api.cognitive.microsoft.com/text/weblm/v1.0/";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public WebLanguageModelRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        public virtual BreakIntoWordsResponse BreakIntoWords(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.WebLM, $"{weblmUrl}breakIntoWords?model={model}&text={text}&order={order}&maxNumOfCandidatesReturned={maxNumOfCandidatesReturned}", "");

            return JsonConvert.DeserializeObject<BreakIntoWordsResponse>(response);
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="text">The line of text to break into words. If spaces are present, they will be interpreted as hard breaks and maintained, except for leading or trailing spaces, which will be trimmed.</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <param name="maxNumOfCandidatesReturned">Max number of candidates would be returned.If not specified, use default value 5.</param>
        /// <returns></returns>
        public virtual async Task<BreakIntoWordsResponse> BreakIntoWordsAsync(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.WebLM, $"{weblmUrl}breakIntoWords?model={model}&text={text}&order={order}&maxNumOfCandidatesReturned={maxNumOfCandidatesReturned}", "");

            return JsonConvert.DeserializeObject<BreakIntoWordsResponse>(response);
        }

        public virtual ConditionalProbabilityResponse CalculateConditionalProbability(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.WebLM, $"{weblmUrl}calculateConditionalProbability?model={model}&order={order}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<ConditionalProbabilityResponse>(response);
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="request">Request object that specifies the queries</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <returns></returns>
        public virtual async Task<ConditionalProbabilityResponse> CalculateConditionalProbabilityAsync(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.WebLM, $"{weblmUrl}calculateConditionalProbability?model={model}&order={order}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<ConditionalProbabilityResponse>(response);
        }

        public virtual JointProbabilityResponse CalculateJointProbability(WebLMModelOptions model, JointProbabilityRequest request, int order = 5) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.WebLM, $"{weblmUrl}calculateJointProbability?model={model}&order={order}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<JointProbabilityResponse>(response);
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="request">Request object that specifies the queries</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <returns></returns>
        public virtual async Task<JointProbabilityResponse> CalculateJointProbabilityAsync(WebLMModelOptions model, JointProbabilityRequest request, int order = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.WebLM, $"{weblmUrl}calculateJointProbability?model={model}&order={order}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<JointProbabilityResponse>(response);
        }

        public virtual GenerateNextWordsResponse GenerateNextWords(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.WebLM, $"{weblmUrl}generateNextWords?model={model}&words={words}&order={order}&maxNumOfCandidatesReturned={maxNumOfCandidatesReturned}", "");

            return JsonConvert.DeserializeObject<GenerateNextWordsResponse>(response);
        }

        /// <param name="model">Which model to use, supported value: title/anchor/query/body</param>
        /// <param name="words">A string containing a sequence of words from which to generate the list of words likely to follow. The words should be separated by spaces.</param>
        /// <param name="order">The order of N-gram. If not specified, use default value 5 .Supported value: 1, 2, 3, 4, 5.</param>
        /// <param name="maxNumOfCandidatesReturned">Max number of candidates would be returned.If not specified, use default value 5.</param>
        /// <returns></returns>
        public virtual async Task<GenerateNextWordsResponse> GenerateNextWordsAsync(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.WebLM, $"{weblmUrl}generateNextWords?model={model}&words={words}&order={order}&maxNumOfCandidatesReturned={maxNumOfCandidatesReturned}", "");

            return JsonConvert.DeserializeObject<GenerateNextWordsResponse>(response);
        }

        public virtual WebLMModelResponse ListAvailableModels() {
            var response = RepositoryClient.SendGet(ApiKeys.WebLM, $"{weblmUrl}models");

            return JsonConvert.DeserializeObject<WebLMModelResponse>(response);
        }

        public virtual async Task<WebLMModelResponse> ListAvailableModelsAsync()
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.WebLM, $"{weblmUrl}models");

            return JsonConvert.DeserializeObject<WebLMModelResponse>(response);
        }
    }
}