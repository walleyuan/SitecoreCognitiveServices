using System;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public class AutoSuggestService : IAutoSuggestService
    {
        protected IAutoSuggestRepository AutoSuggestRepository;
        protected ILogWrapper Logger;

        public AutoSuggestService(
            IAutoSuggestRepository autoSuggestRepository,
            ILogWrapper logger)
        {
            AutoSuggestRepository = autoSuggestRepository;
            Logger = logger;
        }

        public virtual AutoSuggestResponse GetSuggestions(string text)
        {
            try
            {
                var result = AutoSuggestRepository.GetSuggestions(text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AutoSuggestService.GetSuggestions failed", this, ex);
            }

            return null;
        }
    }
}