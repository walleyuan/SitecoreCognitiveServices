using System;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.SpellCheck;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing
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