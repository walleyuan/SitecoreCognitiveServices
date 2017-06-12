using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Video.Contract;
using Microsoft.SharedSource.CognitiveServices.Enums;
using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public interface IVideoRepository
    {
        Operation FaceDetectionAndTracking(string videoUrl);
        Task<Operation> FaceDetectionAndTrackingAsync(string videoUrl);
        Operation FaceDetectionAndTracking(Stream videoStream);
        Task<Operation> FaceDetectionAndTrackingAsync(Stream videoStream);
        OperationResult GetOperationResult(Operation operation);
        Task<OperationResult> GetOperationResultAsync(Operation operation);
        Stream GetResultVideo(string url);
        Task<Stream> GetResultVideoAsync(string url);
        string DetectMotionQS(SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Operation MotionDetection(string videoUrl, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Task<Operation> MotionDetectionAsync(string videoUrl, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Operation MotionDetection(Stream videoStream, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Task<Operation> MotionDetectionAsync(Stream videoStream, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Operation Stabilization(string videoUrl);
        Task<Operation> StabilizationAsync(string videoUrl);
        Operation Stabilization(Stream videoStream);
        Task<Operation> StabilizationAsync(Stream videoStream);
        Operation Thumbnail(string videoUrl, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
        Task<Operation> ThumbnailAsync(string videoUrl, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeIFadeOut);
        Operation Thumbnail(Stream videoStream, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
        Task<Operation> ThumbnailAsync(Stream videoStream, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
    }
}
