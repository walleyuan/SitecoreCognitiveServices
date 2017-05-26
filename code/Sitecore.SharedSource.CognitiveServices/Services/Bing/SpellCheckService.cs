using System;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Bing;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.SpellCheck;

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
                var result = SpellCheckRepository.SpellCheck(text, mode, languageCode);

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