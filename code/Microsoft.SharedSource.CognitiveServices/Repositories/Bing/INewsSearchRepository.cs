using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.NewsSearch;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public interface INewsSearchRepository
    {
        NewsSearchCategoryResponse CategorySearch(NewsCategoryOptions category);
        Task<NewsSearchCategoryResponse> CategorySearchAsync(NewsCategoryOptions category);
        NewsSearchTrendResponse TrendingSearch();
        Task<NewsSearchTrendResponse> TrendingSearchAsync();
        NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
        Task<NewsSearchResponse> NewsSearchAsync(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off);
    }
}