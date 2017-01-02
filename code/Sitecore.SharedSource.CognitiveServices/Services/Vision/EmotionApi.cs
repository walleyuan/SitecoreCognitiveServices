using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Services.Common;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class EmotionApi : EmotionServiceClient, IEmotionApi
    {
        public IServiceUtil ServiceUtil;
        
        public EmotionApi(
            IApiKeys apiKeys,
            IServiceUtil serviceUtil)
            : base(apiKeys.Emotion)
        {
            ServiceUtil = serviceUtil;
        }

        #region RecognizeAsync

        public virtual Task<Emotion[]> RecognizeAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ServiceUtil.GetStream(mediaItem))
            {
                return RecognizeAsync(stream);
            }
        }

        public virtual Task<Emotion[]> RecognizeAsync(MediaItem mediaItem, Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ServiceUtil.GetStream(mediaItem))
            {
                return RecognizeAsync(stream, faceRectangles);
            }
        }

        #endregion RecognizeAsync

        #region RecognizeInVideoAsync

        public virtual Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ServiceUtil.GetStream(mediaItem))
            {
                return RecognizeInVideoAsync(stream);
            }
        }
        
        #endregion #region RecognizeInVideoAsync
    }
}
