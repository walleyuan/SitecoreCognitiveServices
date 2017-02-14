
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public interface ISentimentRepository
    {
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
        Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request);

        #region Client Methods
        /// <summary>
        /// Stubs out an interface that Microsoft.ProjectOxford.Text.Sentiment.SentimentClient should implements
        /// </summary>
        SentimentResponse GetSentiment(SentimentRequest request);
        Task<SentimentResponse> GetSentimentAsync(SentimentRequest request);
        #endregion Client Methods
    }
}
