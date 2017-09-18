using System;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing {
    public interface IVideoSearchService
    {
        VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        VideoSearchTrendResponse TrendingSearch();
        VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested);
    }
}