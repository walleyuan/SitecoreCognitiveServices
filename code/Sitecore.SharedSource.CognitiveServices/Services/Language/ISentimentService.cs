
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Video.Contract;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public interface ISentimentService
    {
        SentimentResponse GetSentiment(SentimentRequest request);
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
        string GetTopics(TopicRequest request);
        OperationResult GetOperation(string operationLocationUrl);
    }
}