using System;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.QnAMaker;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge {
    public class QnAMakerService : IQnAMakerService 
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IQnAMakerRepository QnAMakerRepository;
        protected readonly ILogWrapper Logger;

        public QnAMakerService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IQnAMakerRepository qnAMakerRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            QnAMakerRepository = qnAMakerRepository;
            Logger = logger;
        }

        public virtual KnowledgeBaseExtractionDetails CreateKnowledgeBase(KnowledgeBaseDetails request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "QnAMakerService.CreateKnowledgeBase",
                ApiKeys.QnARetryInSeconds,
                () =>
                {
                    var result = QnAMakerRepository.CreateKnowledgeBase(request);
                    return result;
                },
                null);
        }

        public virtual bool DeleteKnowledgeBase(Guid knowledgeBaseId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "QnAMakerService.DeleteKnowledgeBase",
                ApiKeys.QnARetryInSeconds,
                () =>
                {
                    QnAMakerRepository.DeleteKnowledgeBase(knowledgeBaseId);
                    return true;
                },
                false);
        }

        public virtual string DownloadKnowledgeBase(Guid knowledgeBaseId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "QnAMakerService.DownloadKnowledgeBase",
                ApiKeys.QnARetryInSeconds,
                () =>
                {
                    var result = QnAMakerRepository.DownloadKnowledgeBase(knowledgeBaseId);
                    return result;
                },
                null);
        }

        public virtual GenerateAnswerResponse GenerateAnswer(Guid knowledgeBaseId, GenerateAnswerRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "QnAMakerService.GenerateAnswer",
                ApiKeys.QnARetryInSeconds,
                () =>
                {
                    var result = QnAMakerRepository.GenerateAnswer(knowledgeBaseId, request);
                    return result;
                },
                null);
        }

        public virtual bool PublishKnowledgeBase(Guid knowledgeBaseId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "QnAMakerService.PublishKnowledgeBase",
                ApiKeys.QnARetryInSeconds,
                () =>
                {
                    QnAMakerRepository.PublishKnowledgeBase(knowledgeBaseId);
                    return true;
                },
                false);
        }

        public virtual bool UpdateKnowledgeBase(Guid knowledgeBaseId, PatchKnowledgeBaseRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "QnAMakerService.UpdateKnowledgeBase",
                ApiKeys.QnARetryInSeconds,
                () =>
                {
                    QnAMakerRepository.UpdateKnowledgeBase(knowledgeBaseId, request);
                    return true;
                },
                false);
        }
    }
}