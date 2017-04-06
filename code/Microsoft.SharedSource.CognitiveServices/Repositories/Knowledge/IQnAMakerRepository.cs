using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.QnAMaker;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge {
    public interface IQnAMakerRepository
    {
        Task<KnowledgeBaseExtractionDetails> CreateKnowledgeBaseAsync(KnowledgeBaseDetails request);
        Task DeleteKnowledgeBaseAsync(Guid knowledgeBaseId);
        Task<string> DownloadKnowledgeBaseAsync(Guid knowledgeBaseId);
        Task<GenerateAnswerResponse> GenerateAnswerAsync(Guid knowledgeBaseId, GenerateAnswerRequest request);
        Task PublishKnowledgeBaseAsync(Guid knowledgeBaseId);
        Task UpdateKnowledgeBaseAsync(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request);
    }
}