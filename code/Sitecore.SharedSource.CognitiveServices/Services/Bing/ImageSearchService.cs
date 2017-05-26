using System;
using System.Collections.Generic;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Bing;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.ImageSearch;

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
                var result = ImageSearchRepository.GetImages(query, count, offset, languageCode, safeSearch);

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
                var result = ImageSearchRepository.GetTrendingImages();

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
                var result = ImageSearchRepository.GetImageInsights(query, height, width, count, offset, languageCode, aspect, color, freshness, imageContent, imageType, license, size, safeSearch, modulesRequested, cab, cal, car, cat, ct, cc, id, imgUrl, insightsToken);

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