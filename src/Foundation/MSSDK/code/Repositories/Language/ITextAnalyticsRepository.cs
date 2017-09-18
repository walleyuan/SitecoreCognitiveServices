using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Text;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Language
{
    public interface ITextAnalyticsRepository
    {
        LanguageResponse GetLanguages(LanguageRequest request);
        Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request);
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
        Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request);
        string GetTopics(TopicRequest request);
        Task<string> GetTopicsAsync(TopicRequest request);
        OperationResult GetOperation(string operationLocationUrl);
        Task<OperationResult> GetOperationAsync(string operationLocationUrl);
        SentimentResponse GetSentiment(SentimentRequest request);
        Task<SentimentResponse> GetSentimentAsync(SentimentRequest request);
    }
}
