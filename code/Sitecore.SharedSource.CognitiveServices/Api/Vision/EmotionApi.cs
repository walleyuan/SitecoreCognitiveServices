using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Api.Common;

namespace Sitecore.SharedSource.CognitiveServices.Api.Vision
{
    public class EmotionApi : EmotionServiceClient, IEmotionApi
    {
        public IApiService ApiService;
        
        public EmotionApi(
            IApiKeys apiKeys,
            IApiService apiService)
            : base(apiKeys.Emotion)
        {
            ApiService = apiService;
        }

        #region RecognizeAsync

        public virtual Task<Emotion[]> RecognizeAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return RecognizeAsync(stream);
            }
        }

        public virtual Task<Emotion[]> RecognizeAsync(MediaItem mediaItem, Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return RecognizeAsync(stream, faceRectangles);
            }
        }

        #endregion RecognizeAsync

        #region RecognizeInVideoAsync

        public virtual Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return RecognizeInVideoAsync(stream);
            }
        }
        
        #endregion #region RecognizeInVideoAsync
    }
}
