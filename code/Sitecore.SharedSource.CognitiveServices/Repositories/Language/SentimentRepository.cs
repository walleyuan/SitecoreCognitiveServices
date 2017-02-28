using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Video.Contract;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models.Language;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class SentimentRepository : SentimentClient, ISentimentRepository
    {
        protected static readonly string keyPhraseUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";
        protected static readonly string topicUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/topics";

        protected readonly IRepositoryClient RepositoryClient;

        public SentimentRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
            : base(apiKeys.TextAnalytics)
        {
            RepositoryClient = repoClient;
        }

        public KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request)
        {
            return Task.Run(async () => await GetKeyPhrasesAsync(request)).Result;
        }

        public async Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request)
        {
            request.Validate();
            return JsonConvert.DeserializeObject<KeyPhraseSentimentResponse>(await this.SendPostAsync(keyPhraseUrl, JsonConvert.SerializeObject((object)request)));
        }
        
        /// <summary>
        /// This takes in at least 100 documents and returns a url to the operation where you check for the status of the result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetTopics(TopicRequest request) 
        {
            return Task.Run(async () => await RepositoryClient.SendOperationPostAsync(ApiKey, topicUrl, JsonConvert.SerializeObject((object)request))).Result;
        }
        
        public OperationResult GetOperation(string operationLocationUrl)
        {
            return Task.Run(async () => await GetOperationAsync(operationLocationUrl)).Result;
        }

        /// <summary>
        /// This will return the status and result of the GetTopics operation
        /// </summary>
        /// <param name="operationLocationUrl"></param>
        /// <returns></returns>
        public async Task<OperationResult> GetOperationAsync(string operationLocationUrl)
        {
            return JsonConvert.DeserializeObject<OperationResult>(await this.SendPostAsync(operationLocationUrl, "{}"));
        }
    }
}
