using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision
{
    public interface IVideoRepository
    {
        VideoOperation FaceDetectionAndTracking(string videoUrl);
        Task<VideoOperation> FaceDetectionAndTrackingAsync(string videoUrl);
        VideoOperation FaceDetectionAndTracking(Stream videoStream);
        Task<VideoOperation> FaceDetectionAndTrackingAsync(Stream videoStream);
        VideoOperationResult GetOperationResult(VideoOperation operation);
        Task<VideoOperationResult> GetOperationResultAsync(VideoOperation operation);
        Stream GetResultVideo(string url);
        Task<Stream> GetResultVideoAsync(string url);
        string DetectMotionQS(SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        VideoOperation MotionDetection(string videoUrl, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Task<VideoOperation> MotionDetectionAsync(string videoUrl, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        VideoOperation MotionDetection(Stream videoStream, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Task<VideoOperation> MotionDetectionAsync(Stream videoStream, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        VideoOperation Stabilization(string videoUrl);
        Task<VideoOperation> StabilizationAsync(string videoUrl);
        VideoOperation Stabilization(Stream videoStream);
        Task<VideoOperation> StabilizationAsync(Stream videoStream);
        VideoOperation Thumbnail(string videoUrl, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
        Task<VideoOperation> ThumbnailAsync(string videoUrl, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeIFadeOut);
        VideoOperation Thumbnail(Stream videoStream, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
        Task<VideoOperation> ThumbnailAsync(Stream videoStream, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
    }
}
