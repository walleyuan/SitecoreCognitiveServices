using Sitecore.SharedSource.CognitiveServices.Models.Bing;

namespace Sitecore.SharedSource.CognitiveServices.Services.Bing
{
    public interface IAutoSuggestService
    {
        AutoSuggestResponse GetSuggestions(string text);
    }
}