using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Models.Bing.NewsSearch;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public interface INewsSearchService
    {
        NewsSearchCategoryResponse CategorySearch(NewsCategoryOptions category);
        NewsSearchTrendResponse TrendingSearch();
        NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}