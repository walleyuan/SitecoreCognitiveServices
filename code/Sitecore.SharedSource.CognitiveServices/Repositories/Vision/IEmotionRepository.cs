extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public interface IEmotionRepository : IEmotionServiceClient
    {
        Task<Emotion[]> RecognizeAsync(MediaItem mediaItem);
        Task<Emotion[]> RecognizeAsync(MediaItem mediaItem, MicrosoftProjectOxfordCommon::Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles);
        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(MediaItem mediaItem);
    }
}
