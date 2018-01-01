using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.ImageSearch;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public class ImageSearchService : IImageSearchService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IImageSearchRepository ImageSearchRepository;
        protected readonly ILogWrapper Logger;

        public ImageSearchService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IImageSearchRepository imageSearchRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            ImageSearchRepository = imageSearchRepository;
            Logger = logger;
        }

        public virtual ImageSearchResponse GetImages(string query, int count = 10, int offset = 0, string languageCode = "en-us", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ImageSearchService.GetImages",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = ImageSearchRepository.GetImages(query, count, offset, languageCode, safeSearch);
                    return result;
                },
                null);
        }

        public virtual TrendSearchResponse GetTrendingImages()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ImageSearchService.GetTrendingImages",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = ImageSearchRepository.GetTrendingImages();
                    return result;
                },
                null);
        }

        public virtual ImageInsightResponse GetImageInsights(
            string query = "",
            int height = 0,
            int width = 0,
            int count = 0,
            int offset = 0,
            string languageCode = "",
            AspectOptions aspect = AspectOptions.All,
            ColorOptions color = ColorOptions.All,
            FreshnessOptions freshness = FreshnessOptions.All,
            ImageContentOptions imageContent = ImageContentOptions.All,
            ImageTypeOptions imageType = ImageTypeOptions.All,
            LicenseOptions license = LicenseOptions.All,
            SizeOptions size = SizeOptions.All,
            SafeSearchOptions safeSearch = SafeSearchOptions.Off,
            List<ModulesRequestedOptions> modulesRequested = null,
            float cab = 0f,
            float cal = 0f,
            float car = 0f,
            float cat = 0f,
            int ct = 0,
            string cc = "",
            string id = "",
            string imgUrl = "",
            string insightsToken = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ImageSearchService.GetImageInsights",
                ApiKeys.BingSearchRetryInSeconds,
                () =>
                {
                    var result = ImageSearchRepository.GetImageInsights(query, height, width, count, offset, languageCode, aspect, color, freshness, imageContent, imageType, license, size, safeSearch, modulesRequested, cab, cal, car, cat, ct, cc, id, imgUrl, insightsToken);
                    return result;
                },
                null);
        }
    }
}