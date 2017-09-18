using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Bing
{
    public interface IAutoSuggestService
    {
        AutoSuggestResponse GetSuggestions(string text);
    }
}