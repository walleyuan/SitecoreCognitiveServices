using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Emotion.Contract;
using Sitecore.SharedSource.CognitiveServices.Repository.Vision;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System.IO;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class EmotionService : IEmotionService
    {
        public IEmotionApi EmotionApi;
        public IApiService ApiService;

        public EmotionService(
            IEmotionApi emotionApi,
            IApiService apiService)
        {
            EmotionApi = emotionApi;
            ApiService = apiService;
        }

        #region RecognizeAsync

        public virtual Task<Emotion[]> RecognizeAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return EmotionApi.RecognizeAsync(stream);
            }
        }

        public virtual Task<Emotion[]> RecognizeAsync(MediaItem mediaItem, Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return EmotionApi.RecognizeAsync(stream, faceRectangles);
            }
        }

        #endregion RecognizeAsync

        #region RecognizeInVideoAsync

        public virtual Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return EmotionApi.RecognizeInVideoAsync(stream);
            }
        }

        #endregion #region RecognizeInVideoAsync
    }
}