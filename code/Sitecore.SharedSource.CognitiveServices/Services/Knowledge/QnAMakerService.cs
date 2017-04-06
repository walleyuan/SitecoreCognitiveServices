using System;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.QnAMaker;
using Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Services.Knowledge {
    public class QnAMakerService : IQnAMakerService 
    {
        protected IQnAMakerRepository QnAMakerRepository;
        protected ILogWrapper Logger;

        public QnAMakerService(
            IQnAMakerRepository qnAMakerRepository,
            ILogWrapper logger) {
            QnAMakerRepository = qnAMakerRepository;
            Logger = logger;
        }

        public virtual KnowledgeBaseExtractionDetails CreateKnowledgeBase(KnowledgeBaseDetails request) {
            try {
                var result = Task.Run(async () => await QnAMakerRepository.CreateKnowledgeBaseAsync(request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.CreateKnowledgeBase failed", this, ex);
            }

            return null;
        }

        public virtual bool DeleteKnowledgeBase(Guid knowledgeBaseId) {
            try {
                Task.Run(async () => await QnAMakerRepository.DeleteKnowledgeBaseAsync(knowledgeBaseId));

                return true;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.DeleteKnowledgeBase failed", this, ex);
            }

            return false;
        }

        public virtual string DownloadKnowledgeBase(Guid knowledgeBaseId) {
            try {
                var result = Task.Run(async () => await QnAMakerRepository.DownloadKnowledgeBaseAsync(knowledgeBaseId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.DownloadKnowledgeBase failed", this, ex);
            }

            return null;
        }

        public virtual GenerateAnswerResponse GenerateAnswer(Guid knowledgeBaseId, GenerateAnswerRequest request) {
            try {
                var result = Task.Run(async () => await QnAMakerRepository.GenerateAnswerAsync(knowledgeBaseId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.GenerateAnswer failed", this, ex);
            }

            return null;
        }

        public virtual bool PublishKnowledgeBase(Guid knowledgeBaseId) {
            try {
                Task.Run(async () => await QnAMakerRepository.PublishKnowledgeBaseAsync(knowledgeBaseId));

                return true;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.PublishKnowledgeBase failed", this, ex);
            }

            return false;
        }

        public virtual bool UpdateKnowledgeBase(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request) {
            try {
                Task.Run(async () => await QnAMakerRepository.UpdateKnowledgeBaseAsync(knowledgeBaseId, request));

                return true;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.UpdateKnowledgeBase failed", this, ex);
            }

            return false;
        }
    }
}