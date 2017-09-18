using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.QnAMaker;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Knowledge {
    public interface IQnAMakerRepository
    {
        KnowledgeBaseExtractionDetails CreateKnowledgeBase(KnowledgeBaseDetails request);
        Task<KnowledgeBaseExtractionDetails> CreateKnowledgeBaseAsync(KnowledgeBaseDetails request);
        void DeleteKnowledgeBase(Guid knowledgeBaseId);
        Task DeleteKnowledgeBaseAsync(Guid knowledgeBaseId);
        string DownloadKnowledgeBase(Guid knowledgeBaseId);
        Task<string> DownloadKnowledgeBaseAsync(Guid knowledgeBaseId);
        GenerateAnswerResponse GenerateAnswer(Guid knowledgeBaseId, GenerateAnswerRequest request);
        Task<GenerateAnswerResponse> GenerateAnswerAsync(Guid knowledgeBaseId, GenerateAnswerRequest request);
        void PublishKnowledgeBase(Guid knowledgeBaseId);
        Task PublishKnowledgeBaseAsync(Guid knowledgeBaseId);
        void UpdateKnowledgeBase(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request);
        Task UpdateKnowledgeBaseAsync(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request);
    }
}