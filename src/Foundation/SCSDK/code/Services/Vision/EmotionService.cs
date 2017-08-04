using System;
using System.IO;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Vision;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class EmotionService : IEmotionService
    {
        protected IEmotionRepository EmotionRepository;
        protected ILogWrapper Logger;

        public EmotionService(
            IEmotionRepository emotionRepository,
            ILogWrapper logger)
        {
            EmotionRepository = emotionRepository;
            Logger = logger;
        }

        public virtual Emotion[] Recognize(Stream stream) {
            try {
                var result = EmotionRepository.Recognize(stream);

                return result;
            } catch (Exception ex) {
                Logger.Error("EmotionService.Recognize failed", this, ex);
            }

            return null;
        }
        public virtual Emotion[] Recognize(string imageUrl) {
            try {
                var result = EmotionRepository.Recognize(imageUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("EmotionService.Recognize failed", this, ex);
            }

            return null;
        }
    }
}