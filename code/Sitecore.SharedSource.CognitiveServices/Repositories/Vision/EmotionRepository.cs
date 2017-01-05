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
        
        #region RecognizeAsync

        public virtual async Task<Emotion[]> RecognizeAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return await RecognizeAsync(stream);
            }
        }
        
        public virtual async Task<Emotion[]> RecognizeAsync(MediaItem mediaItem, MicrosoftProjectOxfordCommon::Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return await RecognizeAsync(stream, faceRectangles);
            }
        }

        #endregion RecognizeAsync

        #region RecognizeInVideoAsync

        public virtual async Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return await RecognizeInVideoAsync(stream);
            }
        }
        
        #endregion #region RecognizeInVideoAsync
    }
}
