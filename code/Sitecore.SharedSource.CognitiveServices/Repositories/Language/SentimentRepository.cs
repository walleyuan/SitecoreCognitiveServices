using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class SentimentRepository : SentimentClient, ISentimentRepository
    {
        public SentimentRepository(
            IApiKeys apiKeys)
            : base(apiKeys.TextAnalytics)
        {
        }
    }
}
