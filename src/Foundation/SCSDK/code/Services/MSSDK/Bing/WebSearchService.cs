using System;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public class WebSearchService : IWebSearchService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IWebSearchRepository WebSearchRepository;
        protected readonly ILogWrapper Logger;

        public WebSearchService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IWebSearchRepository webSearchRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            WebSearchRepository = webSearchRepository;
            Logger = logger;
        }

        public virtual WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "WebSearchService.WebSearch",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = WebSearchRepository.WebSearch(text, countOffset, languageCode, safeSearch);
                    return result;
                },
                null);
        }
    }
}