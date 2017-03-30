using Microsoft.ProjectOxford.Emotion;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public class EmotionRepository : EmotionServiceClient, IEmotionRepository
    {
        public EmotionRepository(
            IApiKeys apiKeys) : base(apiKeys.Emotion)
        {
        }
    }
}
