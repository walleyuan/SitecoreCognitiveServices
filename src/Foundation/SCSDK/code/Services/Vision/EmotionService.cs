using System;
using System.IO;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Vision
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