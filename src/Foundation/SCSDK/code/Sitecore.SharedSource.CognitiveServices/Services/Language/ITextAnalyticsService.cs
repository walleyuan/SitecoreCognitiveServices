using Microsoft.SharedSource.CognitiveServices.Models.Common;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Text;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
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