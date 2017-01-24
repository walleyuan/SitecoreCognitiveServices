extern alias MicrosoftProjectOxfordCommon;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using MicrosoftProjectOxfordCommon::Microsoft.ProjectOxford.Common.Contract;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Services;
using System;

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
