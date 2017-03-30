using System;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Sentiment;
using Microsoft.SharedSource.CognitiveServices.Repositories.Language;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public class SentimentService : ISentimentService
    {
        protected ISentimentRepository SentimentRepository;
        protected ILogWrapper Logger;

        public SentimentService(
            ISentimentRepository sentimentRepository,
            ILogWrapper logger)
        {
            SentimentRepository = sentimentRepository;
            Logger = logger;
        }

        public virtual SentimentResponse GetSentiment(SentimentRequest request)
        {
            try
            {
                var result = Task.Run(async () => await SentimentRepository.GetSentimentAsync(request)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentService.GetSentiment failed", this, ex);
            }

            return null;
        }

        public virtual KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request)
        {
            try
            {
                var result = Task.Run(async () => await SentimentRepository.GetKeyPhrasesAsync(request)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentService.GetKeyPhrasesAsync failed", this, ex);
            }

            return null;
        }
    }
}