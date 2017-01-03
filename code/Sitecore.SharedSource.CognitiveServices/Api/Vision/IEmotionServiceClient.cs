using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Common;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Api.Vision
{
    /// <summary>
    /// Stubs out the internal interface that Microsoft.ProjectOxford.Emotion.IEmotionServiceClient implements
    /// </summary>
    public interface IEmotionServiceClient
    {
        Task<Microsoft.ProjectOxford.Emotion.Contract.Emotion[]> RecognizeAsync(string imageUrl);

        Task<Microsoft.ProjectOxford.Emotion.Contract.Emotion[]> RecognizeAsync(string imageUrl, Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles);

        Task<Microsoft.ProjectOxford.Emotion.Contract.Emotion[]> RecognizeAsync(Stream imageStream);

        Task<Microsoft.ProjectOxford.Emotion.Contract.Emotion[]> RecognizeAsync(Stream imageStream, Microsoft.ProjectOxford.Common.Rectangle[] faceRectangles);

        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(Stream videoStream);

        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(byte[] videoBytes);

        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(string videoUrl);

        Task<VideoOperationResult> GetOperationResultAsync(VideoEmotionRecognitionOperation operation);
    }
}
