using Microsoft.ProjectOxford.Common;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.SharedSource.CognitiveServices.Enums;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public interface IEmotionRepository
    {
        Emotion[] Recognize(string imageUrl);
        Task<Emotion[]> RecognizeAsync(string imageUrl);
        Emotion[] Recognize(string imageUrl, Rectangle[] faceRectangles);
        Task<Emotion[]> RecognizeAsync(string imageUrl, Rectangle[] faceRectangles);
        Emotion[] Recognize(Stream imageStream);
        Task<Emotion[]> RecognizeAsync(Stream imageStream);
        Emotion[] Recognize(Stream imageStream, Rectangle[] faceRectangles);
        Task<Emotion[]> RecognizeAsync(Stream imageStream, Rectangle[] faceRectangles);
        VideoEmotionRecognitionOperation RecognizeInVideo(Stream videoStream, VideoOutputStyleOptions outputStyle);
        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(Stream videoStream, VideoOutputStyleOptions outputStyle);
        VideoEmotionRecognitionOperation RecognizeInVideo(byte[] videoBytes, VideoOutputStyleOptions outputStyle);
        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(byte[] videoBytes, VideoOutputStyleOptions outputStyle);
        VideoEmotionRecognitionOperation RecognizeInVideo(string videoUrl, VideoOutputStyleOptions outputStyle);
        Task<VideoEmotionRecognitionOperation> RecognizeInVideoAsync(string videoUrl, VideoOutputStyleOptions outputStyle);
        VideoOperationResult GetOperationResult(VideoEmotionRecognitionOperation operation);
        Task<VideoOperationResult> GetOperationResultAsync(VideoEmotionRecognitionOperation operation);
    }
}
