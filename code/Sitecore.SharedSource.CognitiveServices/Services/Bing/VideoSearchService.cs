using System;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.VideoSearch;
using Microsoft.SharedSource.CognitiveServices.Repositories.Bing;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing {
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