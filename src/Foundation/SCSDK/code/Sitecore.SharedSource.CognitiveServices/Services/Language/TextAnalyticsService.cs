using System;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Text;
using Microsoft.SharedSource.CognitiveServices.Models.Common;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public class TextAnalyticsService : ITextAnalyticsService
    {
        protected ITextAnalyticsRepository TextAnalyticsRepository;
        protected ILogWrapper Logger;

        public TextAnalyticsService(
            ITextAnalyticsRepository textAnalyticsRepository,
            ILogWrapper logger)
        {
            TextAnalyticsRepository = textAnalyticsRepository;
            Logger = logger;
        }

        public virtual LanguageResponse GetLanguages(LanguageRequest request) {
            try {
                var result = TextAnalyticsRepository.GetLanguages(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LanguageService.GetLanguages failed", this, ex);
            }

            return null;
        }

        public virtual SentimentResponse GetSentiment(SentimentRequest request)
        {
            try
            {
                var result = TextAnalyticsRepository.GetSentiment(request);

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
                var result = TextAnalyticsRepository.GetKeyPhrases(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentService.GetKeyPhrasesAsync failed", this, ex);
            }

            return null;
        }

        public virtual string GetTopics(TopicRequest request)
        {
            try {
                var result = TextAnalyticsRepository.GetTopics(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("SentimentService.GetTopics failed", this, ex);
            }

            return null;
        }

        public virtual OperationResult GetOperation(string operationLocationUrl)
        {
            try {
                var result = TextAnalyticsRepository.GetOperation(operationLocationUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("SentimentService.GetOperation failed", this, ex);
            }

            return null;
        }
    }
}