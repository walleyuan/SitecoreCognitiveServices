using System;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public class AutoSuggestService : IAutoSuggestService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IAutoSuggestRepository AutoSuggestRepository;
        protected readonly ILogWrapper Logger;

        public AutoSuggestService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IAutoSuggestRepository autoSuggestRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            AutoSuggestRepository = autoSuggestRepository;
            Logger = logger;
        }

        public virtual AutoSuggestResponse GetSuggestions(string text)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "AutoSuggestService.GetSuggestions",
                ApiKeys.BingAutosuggestRetryInSeconds,
                () =>
                {
                    var result = AutoSuggestRepository.GetSuggestions(text);
                    return result;
                },
                null);
        }
    }
}