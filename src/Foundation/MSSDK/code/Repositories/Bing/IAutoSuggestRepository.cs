using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.AutoSuggest;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing {
    public interface IAutoSuggestRepository
    {
        AutoSuggestResponse GetSuggestions(string text);
        Task<AutoSuggestResponse> GetSuggestionsAsync(string text);
    }
}