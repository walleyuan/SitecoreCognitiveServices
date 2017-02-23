
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Language;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public interface ISentimentService
    {
        SentimentResponse GetSentiment(SentimentRequest request);
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
    }
}