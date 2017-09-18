using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.ImageSearch;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing
{
    public interface IImageSearchService
    {
        ImageSearchResponse GetImages(string query, int count = 10, int offset = 0, string languageCode = "en-us",
            SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        TrendSearchResponse GetTrendingImages();
        ImageInsightResponse GetImageInsights(
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
            string insightsToken = "");
    }
}