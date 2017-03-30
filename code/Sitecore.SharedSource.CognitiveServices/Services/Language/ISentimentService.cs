
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.SharedSource.CognitiveServices.Models;
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public interface ISentimentService
    {
        SentimentResponse GetSentiment(SentimentRequest request);
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
    }
}