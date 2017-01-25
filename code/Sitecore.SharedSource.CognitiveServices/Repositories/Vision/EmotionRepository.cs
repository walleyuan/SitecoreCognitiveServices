extern alias MicrosoftProjectOxfordCommon;
using Microsoft.ProjectOxford.Emotion;
using Sitecore.SharedSource.CognitiveServices.Services;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public class EmotionRepository : EmotionServiceClient, IEmotionRepository
    {
        public IApiService ApiService;

        public EmotionRepository(
            IApiKeys apiKeys,
            IApiService apiService) : base(apiKeys.Emotion)
        {
            ApiService = apiService;
        }
    }
}
