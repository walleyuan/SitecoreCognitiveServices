using System;
using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.VideoSearch;
using MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Bing;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing {
    public class VideoSearchService : IVideoSearchService {

        protected IVideoSearchRepository VideoSearchRepository;
        protected ILogWrapper Logger;

        public VideoSearchService(
            IVideoSearchRepository videoSearchRepository,
            ILogWrapper logger) {
            VideoSearchRepository = videoSearchRepository;
            Logger = logger;
        }

        public VideoSearchResponse VideoSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off) {
            try {
                var result = VideoSearchRepository.VideoSearch(text, countOffset, languageCode, safeSearch);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoSearchService.VideoSearch failed", this, ex);
            }

            return null;
        }
        
        public VideoSearchTrendResponse TrendingSearch() {
            try {
                var result = VideoSearchRepository.TrendingSearch();

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoSearchService.TrendingSearch failed", this, ex);
            }

            return null;
        }

        public VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested) {
            try {
                var result = VideoSearchRepository.VideoDetailsSearch(id, modulesRequested);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoSearchService.VideoDetailsSearch failed", this, ex);
            }

            return null;
        }
    }
}