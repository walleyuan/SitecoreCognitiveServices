using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Common;
using Microsoft.SharedSource.CognitiveServices.Models.Vision;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;
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
        VideoOperation RecognizeInVideo(Stream videoStream, VideoOutputStyleOptions outputStyle);
        Task<VideoOperation> RecognizeInVideoAsync(Stream videoStream, VideoOutputStyleOptions outputStyle);
        VideoOperation RecognizeInVideo(byte[] videoBytes, VideoOutputStyleOptions outputStyle);
        Task<VideoOperation> RecognizeInVideoAsync(byte[] videoBytes, VideoOutputStyleOptions outputStyle);
        VideoOperation RecognizeInVideo(string videoUrl, VideoOutputStyleOptions outputStyle);
        Task<VideoOperation> RecognizeInVideoAsync(string videoUrl, VideoOutputStyleOptions outputStyle);
        VideoOperationResult GetOperationResult(VideoOperation operation);
        Task<VideoOperationResult> GetOperationResultAsync(VideoOperation operation);
    }
}
