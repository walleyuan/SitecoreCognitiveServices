extern alias MicrosoftProjectOxfordCommon;
using Microsoft.ProjectOxford.Emotion;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public class EmotionRepository : EmotionServiceClient, IEmotionRepository
    {
        public EmotionRepository(
            IApiKeys apiKeys) : base(apiKeys.Emotion)
        {
        }
    }
}
