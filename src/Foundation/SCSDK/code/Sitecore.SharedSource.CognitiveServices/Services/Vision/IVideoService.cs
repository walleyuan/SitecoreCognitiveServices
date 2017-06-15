using System.IO;
using Microsoft.ProjectOxford.Video.Contract;
using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using Microsoft.SharedSource.CognitiveServices.Enums;
using System.Threading.Tasks;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IVideoService
    {
        Operation FaceDetectionAndTracking(string videoUrl);
        Task<Operation> FaceDetectionAndTrackingAsync(string videoUrl);
        Operation FaceDetectionAndTracking(Stream videoStream);
        Task<Operation> FaceDetectionAndTrackingAsync(Stream videoStream);
        OperationResult GetOperationResult(Operation operation);
        Task<OperationResult> GetOperationResultAsync(Operation operation);
        Stream GetResultVideo(string url);
        Task<Stream> GetResultVideoAsync(string url);
        Operation MotionDetection(string videoUrl, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Task<Operation> MotionDetectionAsync(string videoUrl, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Operation MotionDetection(Stream videoStream, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Task<Operation> MotionDetectionAsync(Stream videoStream, SensitivityOptions sensitivityLevel, int frameSamplingValue, List<DetectionZone> detectionZones, bool detectLightChange, double mergeTimeThreshold);
        Operation Stabilization(string videoUrl);
        Task<Operation> StabilizationAsync(string videoUrl);
        Operation Stabilization(Stream videoStream);
        Task<Operation> StabilizationAsync(Stream videoStream);
        Operation Thumbnail(string videoUrl, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
        Task<Operation> ThumbnailAsync(string videoUrl, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
        Operation Thumbnail(Stream videoStream, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
        Task<Operation> ThumbnailAsync(Stream videoStream, int maxMotionThumbnailDurationInSecs, bool outputAudio, bool fadeInFadeOut);
    }
}