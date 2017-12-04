using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text;
using SitecoreCognitiveServices.Foundation.MSSDK.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language
{
    public class TextAnalyticsRepository : ITextAnalyticsRepository
    {
        protected static readonly string languageUrl = "languages";
        protected static readonly string keyPhraseUrl = "keyPhrases";
        protected static readonly string topicUrl = "topics";
        protected static readonly string sentimentUrl = "sentiment";

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public TextAnalyticsRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        #region Language

        public virtual string GetLanguageUrl(LanguageRequest request) {
            return (request.NumberOfLanguagesToDetect > 1)
                 ? $"{ApiKeys.TextAnalyticsEndpoint}{languageUrl}?numberOfLanguagesToDetect={request.NumberOfLanguagesToDetect}"
                 : $"{ApiKeys.TextAnalyticsEndpoint}{languageUrl}";
        }

        public virtual LanguageResponse GetLanguages(LanguageRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.TextAnalytics, GetLanguageUrl(request), JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<LanguageResponse>(response);
        }

        public virtual async Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.TextAnalytics, GetLanguageUrl(request), JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<LanguageResponse>(response);
        }

        #endregion Language

        #region Sentiment

        public virtual SentimentResponse GetSentiment(SentimentRequest request)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{sentimentUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<SentimentResponse>(response);
        }

        public virtual async Task<SentimentResponse> GetSentimentAsync(SentimentRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{sentimentUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<SentimentResponse>(response);
        }

        #endregion Sentiment

        #region Key Phrase

        public virtual KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{keyPhraseUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<KeyPhraseSentimentResponse>(response);
        }

        public virtual async Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{keyPhraseUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<KeyPhraseSentimentResponse>(response);
        }

        #endregion Key Phrase

        #region Topics

        public virtual string GetTopics(TopicRequest request) 
        {
            return RepositoryClient.SendOperationPost(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{topicUrl}", JsonConvert.SerializeObject((object)request));
        }

        /// <summary>
        /// This takes in at least 100 documents and returns a url to the operation where you check for the status of the result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual async Task<string> GetTopicsAsync(TopicRequest request) {
            return await RepositoryClient.SendOperationPostAsync(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{topicUrl}", JsonConvert.SerializeObject((object)request));
        }

        #endregion Topics

        #region Operation

        public virtual OperationResult GetOperation(string operationLocationUrl)
        {
            var response = RepositoryClient.SendJsonPost(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{operationLocationUrl}", "{}");

            return JsonConvert.DeserializeObject<OperationResult>(response);
        }

        /// <summary>
        /// This will return the status and result of the GetTopics operation
        /// </summary>
        /// <param name="operationLocationUrl"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> GetOperationAsync(string operationLocationUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.TextAnalytics, $"{ApiKeys.TextAnalyticsEndpoint}{operationLocationUrl}", "{}");

            return JsonConvert.DeserializeObject<OperationResult>(response);
        }

        #endregion Operation
    }
}
