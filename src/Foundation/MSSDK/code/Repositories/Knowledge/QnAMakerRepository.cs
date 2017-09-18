using System;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.QnAMaker;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge {
    public class QnAMakerRepository : IQnAMakerRepository 
    {
        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public QnAMakerRepository(
            IApiKeys apiKeys,
            IRepositoryClient repositoryClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual KnowledgeBaseExtractionDetails CreateKnowledgeBase(KnowledgeBaseDetails request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}create", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<KnowledgeBaseExtractionDetails>(response);
        }

        public virtual async Task<KnowledgeBaseExtractionDetails> CreateKnowledgeBaseAsync(KnowledgeBaseDetails request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}create", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<KnowledgeBaseExtractionDetails>(response);
        }

        public virtual void DeleteKnowledgeBase(Guid knowledgeBaseId) {
            RepositoryClient.SendJsonDelete(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}");
        }

        public virtual async Task DeleteKnowledgeBaseAsync(Guid knowledgeBaseId) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}");
        }

        public virtual string DownloadKnowledgeBase(Guid knowledgeBaseId) {
            var response = RepositoryClient.SendGet(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}");

            return response;
        }

        public virtual async Task<string> DownloadKnowledgeBaseAsync(Guid knowledgeBaseId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}");

            return response;
        }

        public virtual GenerateAnswerResponse GenerateAnswer(Guid knowledgeBaseId, GenerateAnswerRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}/generateAnswer", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<GenerateAnswerResponse>(response);
        }

        public virtual async Task<GenerateAnswerResponse> GenerateAnswerAsync(Guid knowledgeBaseId, GenerateAnswerRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}/generateAnswer", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<GenerateAnswerResponse>(response);
        }

        public virtual void PublishKnowledgeBase(Guid knowledgeBaseId) {
            RepositoryClient.SendJsonPut(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}", "");
        }

        public virtual async Task PublishKnowledgeBaseAsync(Guid knowledgeBaseId) {
            await RepositoryClient.SendJsonPutAsync(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}", "");
        }

        public virtual void UpdateKnowledgeBase(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request) {
            RepositoryClient.SendJsonPatch(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateKnowledgeBaseAsync(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request) {
            await RepositoryClient.SendJsonPatchAsync(ApiKeys.QnA, $"{ApiKeys.QnAEndpoint}{knowledgeBaseId}", JsonConvert.SerializeObject(request));
        }
    }
}
