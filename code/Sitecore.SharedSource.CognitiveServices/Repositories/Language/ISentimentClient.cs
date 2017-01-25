using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    /// <summary>
    /// Stubs out an interface that Microsoft.ProjectOxford.Text.Sentiment.SentimentClient should implements
    /// </summary>
    public interface ISentimentClient
    {
        SentimentResponse GetSentiment(SentimentRequest request);
        Task<SentimentResponse> GetSentimentAsync(SentimentRequest request);
    }
}
