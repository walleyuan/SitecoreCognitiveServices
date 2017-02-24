using System;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Repositories.Bing;
using System.Threading.Tasks;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public class WebSearchService : IWebSearchService
    {
        protected IWebSearchRepository WebSearchRepository;
        protected ILogWrapper Logger;

        public WebSearchService(
            IWebSearchRepository webSearchRepository,
            ILogWrapper logger)
        {
            WebSearchRepository = webSearchRepository;
            Logger = logger;
        }

        public virtual WebSearchResponse WebSearch(string text, int countOffset = 0, string languageCode = "", SafeSearchOptions safeSearch = SafeSearchOptions.Off)
        {
            try
            {
                var result = Task.Run(async () => await WebSearchRepository.WebSearchAsync(text, countOffset, languageCode, safeSearch)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("WebSearchService.WebSearch failed", this, ex);
            }

            return null;
        }
    }
}