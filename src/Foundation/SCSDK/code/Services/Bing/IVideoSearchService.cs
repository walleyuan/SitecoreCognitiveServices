using System;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing {
    public interface IVideoSearchService
    {
        VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        VideoSearchTrendResponse TrendingSearch();
        VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested);
    }
}