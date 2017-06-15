using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.ImageSearch;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing
{
    public class ImageSearchRepository : IImageSearchRepository
    {
        public static readonly string imageSearchUrl = "https://api.cognitive.microsoft.com/bing/v5.0/images/search";
        public static readonly string imageTrendUrl = "https://api.cognitive.microsoft.com/bing/v5.0/images/trending";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public ImageSearchRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        #region Image Search

        public virtual ImageSearchResponse GetImages(string query, int count = 10, int offset = 0, string languageCode = "en-us", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            string searchUrl = $"{imageSearchUrl}?q={query}&count={count}&offset={offset}&mkt={languageCode}&safeSearch={Enum.GetName(typeof(SafeSearchOptions), safeSearch)}";
            var response = RepositoryClient.SendGet(ApiKeys.BingSearch, searchUrl);

            return JsonConvert.DeserializeObject<ImageSearchResponse>(response);
        }

        public virtual async Task<ImageSearchResponse> GetImagesAsync(string query, int count = 10, int offset = 0, string languageCode = "en-us", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            string searchUrl = $"{imageSearchUrl}?q={query}&count={count}&offset={offset}&mkt={languageCode}&safeSearch={Enum.GetName(typeof(SafeSearchOptions), safeSearch)}";
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, searchUrl);

            return JsonConvert.DeserializeObject<ImageSearchResponse>(response);
        }

        #endregion Image Search

        #region Trending Images

        public virtual TrendSearchResponse GetTrendingImages()
        {
            var response = RepositoryClient.SendGet(ApiKeys.BingSearch, imageTrendUrl);

            return JsonConvert.DeserializeObject<TrendSearchResponse>(response);
        }

        public virtual async Task<TrendSearchResponse> GetTrendingImagesAsync()
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.BingSearch, imageTrendUrl);

            return JsonConvert.DeserializeObject<TrendSearchResponse>(response);
        }

        #endregion Trending Images

        #region Image Insights

        protected virtual string GetImageInsightUrl(
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
            StringBuilder sb = new StringBuilder();
            sb.Append($"{imageSearchUrl}?q={query}");

            if (height > 0)
                sb.Append($"&height={height}");

            if (width > 0)
                sb.Append($"&width={width}");

            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            if (!string.IsNullOrEmpty(languageCode))
                sb.Append($"&mkt={languageCode}");

            var aspectName = Enum.GetName(typeof(AspectOptions), aspect);
            if (aspectName != null && !aspectName.Equals("All"))
                sb.Append($"&aspect={aspectName}");

            var colorName = Enum.GetName(typeof(ColorOptions), color);
            if (colorName != null && !colorName.Equals("All"))
                sb.Append($"&color={colorName}");

            var freshnessName = Enum.GetName(typeof(FreshnessOptions), freshness);
            if (freshnessName != null && !freshnessName.Equals("All"))
                sb.Append($"&freshness={freshnessName}");

            var imageContentName = Enum.GetName(typeof(ImageContentOptions), imageContent);
            if (imageContentName != null && !imageContentName.Equals("All"))
                sb.Append($"&imageContent={imageContentName}");

            var imageTypeName = Enum.GetName(typeof(ImageTypeOptions), imageType);
            if (imageTypeName != null && !imageTypeName.Equals("All"))
                sb.Append($"&imageType={imageTypeName}");

            var licenseName = Enum.GetName(typeof(LicenseOptions), license);
            if (licenseName != null && !licenseName.Equals("All"))
                sb.Append($"&license={licenseName}");

            var sizeName = Enum.GetName(typeof(SizeOptions), size);
            if (sizeName != null && !sizeName.Equals("All"))
                sb.Append($"&size={sizeName}");

            var safeSearchName = Enum.GetName(typeof(SafeSearchOptions), safeSearch);
            if (safeSearchName != null && !safeSearchName.Equals("All"))
                sb.Append($"&safeSearch={safeSearchName}");

            StringBuilder mod = new StringBuilder();
            if (modulesRequested != null) {
                foreach (var m in modulesRequested) {
                    if (mod.Length > 0)
                        mod.Append(",");

                    mod.Append(Enum.GetName(typeof(ModulesRequestedOptions), m));
                }
                sb.Append($"&modulesRequested={mod}");
            }

            if (cab > 0f)
                sb.Append($"&cab={cab}");

            if (cal > 0f)
                sb.Append($"&cal={cal}");

            if (car > 0f)
                sb.Append($"&car={car}");

            if (cat > 0f)
                sb.Append($"&cat={cat}");

            if (ct > 0)
                sb.Append($"&ct={ct}");

            if (!string.IsNullOrEmpty(cc))
                sb.Append($"&cc={cc}");

            if (!string.IsNullOrEmpty(id))
                sb.Append($"&id={id}");

            if (!string.IsNullOrEmpty(imgUrl))
                sb.Append($"&imgUrl={HttpUtility.UrlEncode(imgUrl)}");

            if (!string.IsNullOrEmpty(insightsToken))
                sb.Append($"&insightsToken={insightsToken}");

            return sb.ToString();
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
            var url = GetImageInsightUrl(query, height, width, count, offset, languageCode, aspect, color,
                freshness, imageContent, imageType, license, size, safeSearch, modulesRequested, cab, cal,
                car, cat, ct, cc, id, imgUrl, insightsToken);

            var response = RepositoryClient.SendPostMultiPart(ApiKeys.BingSearch, url, "{}");

            return JsonConvert.DeserializeObject<ImageInsightResponse>(response);
        }

        public virtual async Task<ImageInsightResponse> GetImageInsightsAsync(
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
            var url = GetImageInsightUrl(query, height, width, count, offset, languageCode, aspect, color,
                freshness, imageContent, imageType, license, size, safeSearch, modulesRequested, cab, cal,
                car, cat, ct, cc, id, imgUrl, insightsToken);
            
            var response = await RepositoryClient.SendPostMultiPartAsync(ApiKeys.BingSearch, url, "{}");

            return JsonConvert.DeserializeObject<ImageInsightResponse>(response);
        }
        
        #endregion Image Insights
    }
}