using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public interface INewsSearchService
    {
        NewsSearchCategoryResponse CategorySearch(NewsCategoryOptions category);
        NewsSearchTopicResponse TrendingSearch();
        NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}