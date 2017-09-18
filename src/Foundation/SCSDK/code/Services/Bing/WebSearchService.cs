using System;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.WebSearch;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing
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