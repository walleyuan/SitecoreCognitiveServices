using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing
{
    public interface INewsSearchService
    {
        NewsSearchCategoryResponse CategorySearch(NewsCategoryOptions category);
        NewsSearchTrendResponse TrendingSearch();
        NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}