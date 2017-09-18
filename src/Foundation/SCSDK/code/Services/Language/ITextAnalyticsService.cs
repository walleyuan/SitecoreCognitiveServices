using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Language
{
    public interface ITextAnalyticsService
    {
        LanguageResponse GetLanguages(LanguageRequest request);
        SentimentResponse GetSentiment(SentimentRequest request);
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
        string GetTopics(TopicRequest request);
        OperationResult GetOperation(string operationLocationUrl);
    }
}