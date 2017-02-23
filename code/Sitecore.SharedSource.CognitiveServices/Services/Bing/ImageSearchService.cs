using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Repositories.Bing;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Enums;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public class ImageSearchService : IImageSearchService
    {
        protected IImageSearchRepository ImageSearchRepository;
        protected ILogWrapper Logger;

        public ImageSearchService(
            IImageSearchRepository imageSearchRepository,
            ILogWrapper logger)
        {
            ImageSearchRepository = imageSearchRepository;
            Logger = logger;
        }

        public virtual ImageSearchResponse GetImages(string query, int count = 10, int offset = 0, string languageCode = "en-us", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            try
            {
                var result = Task.Run(async () => await ImageSearchRepository.GetImagesAsync(query, count, offset, languageCode, safeSearch)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ImageSearchService.GetImages failed", this, ex);
            }

            return null;
        }

        public virtual TrendSearchResponse GetTrendingImages()
        {
            try
            {
                var result = Task.Run(async () => await ImageSearchRepository.GetTrendingImagesAsync()).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ImageSearchService.GetTrendingImages failed", this, ex);
            }

            return null;
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
            try
            {
                var result = Task.Run(async () => await ImageSearchRepository.GetImageInsightsAsync(query, height, width, count, offset, languageCode, aspect, color, freshness, imageContent, imageType, license, size, safeSearch, modulesRequested, cab, cal, car, cat, ct, cc, id, imgUrl, insightsToken)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ImageSearchService.GetImageInsights failed", this, ex);
            }

            return null;
        }
    }
}