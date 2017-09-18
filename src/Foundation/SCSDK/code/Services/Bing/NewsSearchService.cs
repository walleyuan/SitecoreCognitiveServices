using System;
using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.NewsSearch;
using MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Bing;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing
{
    public class NewsSearchService : INewsSearchService {

        protected INewsSearchRepository NewsSearchRepository;
        protected ILogWrapper Logger;

        public NewsSearchService(
            INewsSearchRepository newsSearchRepository,
            ILogWrapper logger) {
            NewsSearchRepository = newsSearchRepository;
            Logger = logger;
        }
        
        public virtual NewsSearchCategoryResponse CategorySearch(NewsCategoryOptions category) {
            try {
                var result = NewsSearchRepository.CategorySearch(category);
                
                return result;
            } catch (Exception ex) {
                Logger.Error("AutoSuggestService.CategorySearch failed", this, ex);
            }

            return null;
        }

        public virtual NewsSearchTrendResponse TrendingSearch() {
            try {
                var result = NewsSearchRepository.TrendingSearch();
                
                return result;
            } catch (Exception ex) {
                Logger.Error("AutoSuggestService.CategorySearch failed", this, ex);
            }

            return null;
        }

        public virtual NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off) {
            try {
                var result = NewsSearchRepository.NewsSearch(text, countOffset, languageCode, safeSearch);

                return result;
            } catch (Exception ex) {
                Logger.Error("AutoSuggestService.CategorySearch failed", this, ex);
            }

            return null;
        }
    }
}