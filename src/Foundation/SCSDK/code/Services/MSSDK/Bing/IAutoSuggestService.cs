using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public interface IAutoSuggestService
    {
        AutoSuggestResponse GetSuggestions(string text);
    }
}