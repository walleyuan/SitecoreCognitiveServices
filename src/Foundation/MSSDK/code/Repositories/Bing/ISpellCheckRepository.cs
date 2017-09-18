using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.SpellCheck;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing {
    public interface ISpellCheckRepository
    {
        SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "");
        Task<SpellCheckResponse> SpellCheckAsync(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "");
    }
}