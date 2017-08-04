using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.AutoSuggest;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public interface IAutoSuggestService
    {
        AutoSuggestResponse GetSuggestions(string text);
    }
}