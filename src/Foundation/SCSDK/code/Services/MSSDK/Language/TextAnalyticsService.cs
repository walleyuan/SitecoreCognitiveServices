using System;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language
{
    public class TextAnalyticsService : ITextAnalyticsService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ITextAnalyticsRepository TextAnalyticsRepository;
        protected readonly ILogWrapper Logger;

        public TextAnalyticsService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ITextAnalyticsRepository textAnalyticsRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            TextAnalyticsRepository = textAnalyticsRepository;
            Logger = logger;
        }

        public virtual LanguageResponse GetLanguages(LanguageRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "TextAnalyticsService.GetLanguages",
                ApiKeys.TextAnalyticsRetryInSeconds,
                () =>
                {
                    var result = TextAnalyticsRepository.GetLanguages(request);
                    return result;
                },
                null);
        }

        public virtual SentimentResponse GetSentiment(SentimentRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "TextAnalyticsService.GetSentiment",
                ApiKeys.TextAnalyticsRetryInSeconds,
                () =>
                {
                    var result = TextAnalyticsRepository.GetSentiment(request);
                    return result;
                },
                null);
        }

        public virtual KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "TextAnalyticsService.GetKeyPhrases",
                ApiKeys.TextAnalyticsRetryInSeconds,
                () =>
                {
                    var result = TextAnalyticsRepository.GetKeyPhrases(request);
                    return result;
                },
                null);
        }

        public virtual string GetTopics(TopicRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "TextAnalyticsService.GetTopics",
                ApiKeys.TextAnalyticsRetryInSeconds,
                () =>
                {
                    var result = TextAnalyticsRepository.GetTopics(request);
                    return result;
                },
                null);
        }

        public virtual OperationResult GetOperation(string operationLocationUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "TextAnalyticsService.GetOperation",
                ApiKeys.TextAnalyticsRetryInSeconds,
                () =>
                {
                    var result = TextAnalyticsRepository.GetOperation(operationLocationUrl);
                    return result;
                },
                null);
        }
    }
}