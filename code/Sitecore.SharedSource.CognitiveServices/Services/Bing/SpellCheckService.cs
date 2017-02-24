using System;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Repositories.Bing;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Enums;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public class SpellCheckService : ISpellCheckService
    {
        protected ISpellCheckRepository SpellCheckRepository;
        protected ILogWrapper Logger;

        public SpellCheckService(
            ISpellCheckRepository spellCheckRepository,
            ILogWrapper logger)
        {
            SpellCheckRepository = spellCheckRepository;
            Logger = logger;
        }

        public virtual SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            try
            {
                var result = Task.Run(async () => await SpellCheckRepository.SpellCheckAsync(text, mode, languageCode)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SpellCheckService.SpellCheck failed", this, ex);
            }

            return null;
        }
    }
}