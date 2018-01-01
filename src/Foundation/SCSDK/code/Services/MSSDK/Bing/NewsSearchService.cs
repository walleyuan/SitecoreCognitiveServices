using System;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public class NewsSearchService : INewsSearchService {

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly INewsSearchRepository NewsSearchRepository;
        protected readonly ILogWrapper Logger;

        public NewsSearchService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            INewsSearchRepository newsSearchRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            NewsSearchRepository = newsSearchRepository;
            Logger = logger;
        }
        
        public virtual NewsSearchCategoryResponse CategorySearch(NewsCategoryOptions category)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "NewsSearchService.CategorySearch",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = NewsSearchRepository.CategorySearch(category);
                    return result;
                },
                null);
        }

        public virtual NewsSearchTrendResponse TrendingSearch()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "NewsSearchService.TrendingSearch",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = NewsSearchRepository.TrendingSearch();
                    return result;
                },
                null);
        }

        public virtual NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "NewsSearchService.NewsSearch",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = NewsSearchRepository.NewsSearch(text, countOffset, languageCode, safeSearch);
                    return result;
                },
                null);
        }
    }
}