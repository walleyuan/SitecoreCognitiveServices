using System;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Models.Bing.NewsSearch;
using Sitecore.SharedSource.CognitiveServices.Repositories.Bing;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
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
                var result = Task.Run(async () => await NewsSearchRepository.CategorySearchAsync(category)).Result;
                
                return result;
            } catch (Exception ex) {
                Logger.Error("AutoSuggestService.CategorySearch failed", this, ex);
            }

            return null;
        }

        public virtual NewsSearchTrendResponse TrendingSearch() {
            try {
                var result = Task.Run(async () => await NewsSearchRepository.TrendingSearchAsync()).Result;
                
                return result;
            } catch (Exception ex) {
                Logger.Error("AutoSuggestService.CategorySearch failed", this, ex);
            }

            return null;
        }

        public virtual NewsSearchResponse NewsSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off) {
            try {
                var result = Task.Run(async () => await NewsSearchRepository.NewsSearchAsync(text, countOffset, languageCode, safeSearch)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("AutoSuggestService.CategorySearch failed", this, ex);
            }

            return null;
        }
    }
}