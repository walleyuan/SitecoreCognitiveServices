using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.NewsSearch;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public interface INewsSearchService
    {
        NewsSearchCategoryResponse CategorySearch(NewsCategoryOptions category);
        NewsSearchTrendResponse TrendingSearch();
        NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}