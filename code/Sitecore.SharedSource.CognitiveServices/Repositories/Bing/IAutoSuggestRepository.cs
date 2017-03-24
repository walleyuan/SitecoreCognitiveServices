using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Models.Bing;
using Sitecore.SharedSource.CognitiveServices.Models.Bing.AutoSuggest;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Bing {
    public interface IAutoSuggestRepository
    {
        AutoSuggestResponse GetSuggestions(string text);
        Task<AutoSuggestResponse> GetSuggestionsAsync(string text);
    }
}