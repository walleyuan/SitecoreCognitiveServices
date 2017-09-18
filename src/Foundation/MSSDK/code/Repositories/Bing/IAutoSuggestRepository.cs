using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Bing {
    public interface IAutoSuggestRepository
    {
        AutoSuggestResponse GetSuggestions(string text);
        Task<AutoSuggestResponse> GetSuggestionsAsync(string text);
    }
}