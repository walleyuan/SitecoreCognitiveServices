using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Emotion.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public interface IEmotionService
    {
        Task<Emotion[]> RecognizeAsync(MediaItem mediaItem);
        Task<Emotion[]> RecognizeAsync(MediaItem mediaItem, Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles);
        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(MediaItem mediaItem);
    }
}