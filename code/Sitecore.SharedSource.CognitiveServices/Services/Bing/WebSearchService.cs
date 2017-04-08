using System;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Repositories.Bing;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.WebSearch;

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
                var result = WebSearchRepository.WebSearch(text, countOffset, languageCode, safeSearch);

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