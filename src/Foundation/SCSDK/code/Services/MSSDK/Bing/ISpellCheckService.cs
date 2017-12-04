using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.SpellCheck;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public interface ISpellCheckService
    {
        SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "");
    }
}