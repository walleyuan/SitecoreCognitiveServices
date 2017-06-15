
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Video.Contract;
using Microsoft.SharedSource.CognitiveServices.Models;
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Sentiment;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language
{
    public interface ISentimentRepository
    {
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
        Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request);

        string GetTopics(TopicRequest request);
        Task<string> GetTopicsAsync(TopicRequest request);

        OperationResult GetOperation(string operationLocationUrl);
        Task<OperationResult> GetOperationAsync(string operationLocationUrl);

        #region Client Methods
        /// <summary>
        /// Stubs out an interface that Microsoft.ProjectOxford.Text.Sentiment.SentimentClient should implement
        /// </summary>
        SentimentResponse GetSentiment(SentimentRequest request);
        Task<SentimentResponse> GetSentimentAsync(SentimentRequest request);
        #endregion Client Methods
    }
}
