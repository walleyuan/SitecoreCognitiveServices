using System;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.WebLanguageModel;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language
{
    public class WebLanguageModelService : IWebLanguageModelService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IWebLanguageModelRepository WebLanguageModelRepository;
        protected readonly ILogWrapper Logger;

        public WebLanguageModelService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IWebLanguageModelRepository webLanguageModelRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            WebLanguageModelRepository = webLanguageModelRepository;
            Logger = logger;
        }

        public virtual BreakIntoWordsResponse BreakIntoWords(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "WebLanguageModelService.BreakIntoWords",
                ApiKeys.WebLMRetryInSeconds,
                () =>
                {
                    var result = WebLanguageModelRepository.BreakIntoWords(model, text, order, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual ConditionalProbabilityResponse CalculateConditionalProbability(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "WebLanguageModelService.CalculateConditionalProbability",
                ApiKeys.WebLMRetryInSeconds,
                () =>
                {
                    var result = WebLanguageModelRepository.CalculateConditionalProbability(model, request, order);
                    return result;
                },
                null);
        }

        public virtual JointProbabilityResponse CalculateJointProbability(WebLMModelOptions model, JointProbabilityRequest request, int order = 5)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "WebLanguageModelService.CalculateJointProbability",
                ApiKeys.WebLMRetryInSeconds,
                () =>
                {
                    var result = WebLanguageModelRepository.CalculateJointProbability(model, request, order);
                    return result;
                },
                null);
        }

        public virtual GenerateNextWordsResponse GenerateNextWords(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "WebLanguageModelService.GenerateNextWords",
                ApiKeys.WebLMRetryInSeconds,
                () =>
                {
                    var result = WebLanguageModelRepository.GenerateNextWords(model, words, order, maxNumOfCandidatesReturned);
                    return result;
                },
                null);
        }

        public virtual WebLMModelResponse ListAvailableModels()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "WebLanguageModelService.ListAvailableModels",
                ApiKeys.WebLMRetryInSeconds,
                () =>
                {
                    var result = WebLanguageModelRepository.ListAvailableModels();
                    return result;
                },
                null);
        }
    }
}