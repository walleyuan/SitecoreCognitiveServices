using System;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Repositories.Bing;

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
                var result = Task.Run(async () => await VideoSearchRepository.VideoSearchAsync(text, countOffset, languageCode, safeSearch)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoSearchService.VideoSearch failed", this, ex);
            }

            return null;
        }
        
        public VideoSearchTrendResponse TrendingSearch() {
            try {
                var result = Task.Run(async () => await VideoSearchRepository.TrendingSearchAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoSearchService.TrendingSearch failed", this, ex);
            }

            return null;
        }

        public VideoSearchDetailsResponse VideoDetailsSearch(string id, VideoDetailsModulesOptions modulesRequested) {
            try {
                var result = Task.Run(async () => await VideoSearchRepository.VideoDetailsSearchAsync(id, modulesRequested)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoSearchService.VideoDetailsSearch failed", this, ex);
            }

            return null;
        }
    }
}