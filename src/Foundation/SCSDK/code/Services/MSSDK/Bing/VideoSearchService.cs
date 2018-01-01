using System;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing {
    public class VideoSearchService : IVideoSearchService {

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IVideoSearchRepository VideoSearchRepository;
        protected readonly ILogWrapper Logger;

        public VideoSearchService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IVideoSearchRepository videoSearchRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            VideoSearchRepository = videoSearchRepository;
            Logger = logger;
        }

        public VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoSearchService.VideoSearch",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = VideoSearchRepository.VideoSearch(text, countOffset, languageCode, safeSearch);
                    return result;
                },
                null);
        }
        
        public VideoSearchTrendResponse TrendingSearch()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoSearchService.TrendingSearch",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = VideoSearchRepository.TrendingSearch();
                    return result;
                },
                null);
        }

        public VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoSearchService.VideoDetailsSearch",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = VideoSearchRepository.VideoDetailsSearch(id, modulesRequested);
                    return result;
                },
                null);
        }
    }
}