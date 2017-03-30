using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Bing;
using Microsoft.SharedSource.CognitiveServices.Models.Bing.AutoSuggest;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Bing {
    public interface IAutoSuggestRepository
    {
        AutoSuggestResponse GetSuggestions(string text);
        Task<AutoSuggestResponse> GetSuggestionsAsync(string text);
    }
}