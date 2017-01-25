using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class EmotionService : IEmotionService
    {
        public IEmotionRepository EmotionRepository;

        public EmotionService(IEmotionRepository emotionRepository)
        {
            EmotionRepository = emotionRepository;
        }

        
    }
}