using System;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
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