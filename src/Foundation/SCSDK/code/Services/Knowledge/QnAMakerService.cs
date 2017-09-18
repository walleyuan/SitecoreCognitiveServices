using System;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.QnAMaker;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Knowledge {
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
                var result = QnAMakerRepository.CreateKnowledgeBase(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.CreateKnowledgeBase failed", this, ex);
            }

            return null;
        }

        public virtual bool DeleteKnowledgeBase(Guid knowledgeBaseId) {
            try {
                QnAMakerRepository.DeleteKnowledgeBase(knowledgeBaseId);

                return true;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.DeleteKnowledgeBase failed", this, ex);
            }

            return false;
        }

        public virtual string DownloadKnowledgeBase(Guid knowledgeBaseId) {
            try {
                var result = QnAMakerRepository.DownloadKnowledgeBase(knowledgeBaseId);

                return result;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.DownloadKnowledgeBase failed", this, ex);
            }

            return null;
        }

        public virtual GenerateAnswerResponse GenerateAnswer(Guid knowledgeBaseId, GenerateAnswerRequest request) {
            try {
                var result = QnAMakerRepository.GenerateAnswer(knowledgeBaseId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.GenerateAnswer failed", this, ex);
            }

            return null;
        }

        public virtual bool PublishKnowledgeBase(Guid knowledgeBaseId) {
            try {
                QnAMakerRepository.PublishKnowledgeBase(knowledgeBaseId);

                return true;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.PublishKnowledgeBase failed", this, ex);
            }

            return false;
        }

        public virtual bool UpdateKnowledgeBase(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request) {
            try {
                QnAMakerRepository.UpdateKnowledgeBase(knowledgeBaseId, request);

                return true;
            } catch (Exception ex) {
                Logger.Error("QnAMakerService.UpdateKnowledgeBase failed", this, ex);
            }

            return false;
        }
    }
}