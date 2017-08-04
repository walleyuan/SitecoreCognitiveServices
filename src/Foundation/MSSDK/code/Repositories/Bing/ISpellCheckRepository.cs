using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.SpellCheck;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public interface ISpellCheckRepository
    {
        SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "");
        Task<SpellCheckResponse> SpellCheckAsync(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "");
    }
}