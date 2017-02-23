using System;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Repositories.Bing;
using System.Threading.Tasks;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
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
                var result = Task.Run(async () => await AutoSuggestRepository.GetSuggestionsAsync(text)).Result;

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