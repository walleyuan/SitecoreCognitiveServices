using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.QnAMaker;
using Newtonsoft.Json;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge {
    public class QnAMakerRepository : IQnAMakerRepository 
    {
        public static readonly string qnaUrl = "https://westus.api.cognitive.microsoft.com/qnamaker/v2.0/knowledgebases/";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public QnAMakerRepository(
            IApiKeys apiKeys,
            IRepositoryClient repositoryClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual async Task<KnowledgeBaseExtractionDetails> CreateKnowledgeBaseAsync(KnowledgeBaseDetails request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.QnA, $"{qnaUrl}create", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<KnowledgeBaseExtractionDetails>(response);
        }

        public virtual async Task DeleteKnowledgeBaseAsync(Guid knowledgeBaseId) {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.QnA, $"{qnaUrl}{knowledgeBaseId}");
        }

        public virtual async Task<string> DownloadKnowledgeBaseAsync(Guid knowledgeBaseId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.QnA, $"{qnaUrl}{knowledgeBaseId}");

            return response;
        }
        public virtual async Task<GenerateAnswerResponse> GenerateAnswerAsync(Guid knowledgeBaseId, GenerateAnswerRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.QnA, $"{qnaUrl}{knowledgeBaseId}/generateAnswer", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<GenerateAnswerResponse>(response);
        }

        public virtual async Task PublishKnowledgeBaseAsync(Guid knowledgeBaseId) {
            await RepositoryClient.SendJsonPutAsync(ApiKeys.QnA, $"{qnaUrl}{knowledgeBaseId}", "");
        }

        public virtual async Task UpdateKnowledgeBaseAsync(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request) {
            await RepositoryClient.SendJsonPatchAsync(ApiKeys.QnA, $"{qnaUrl}{knowledgeBaseId}", JsonConvert.SerializeObject(request));
        }
    }
}
