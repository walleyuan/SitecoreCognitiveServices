using System;
using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public class VideoService : IVideoService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IVideoRepository VideoRepository;
        protected readonly ILogWrapper Logger;

        public VideoService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IVideoRepository videoRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            VideoRepository = videoRepository;
            Logger = logger;
        }

        public virtual VideoOperation FaceDetectionAndTracking(string videoUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.FaceDetectionAndTracking",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.FaceDetectionAndTracking(videoUrl);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> FaceDetectionAndTrackingAsync(string videoUrl)
        {
            try {
                var result = await VideoRepository.FaceDetectionAndTrackingAsync(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTrackingAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation FaceDetectionAndTracking(Stream videoStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.FaceDetectionAndTracking",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.FaceDetectionAndTracking(videoStream);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> FaceDetectionAndTrackingAsync(Stream videoStream)
        {
            try {
                var result = await VideoRepository.FaceDetectionAndTrackingAsync(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTrackingAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperationResult GetOperationResult(VideoOperation operation)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.GetOperationResult",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.GetOperationResult(operation);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperationResult> GetOperationResultAsync(VideoOperation operation)
        {
            try {
                var result = await VideoRepository.GetOperationResultAsync(operation);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.GetOperationResultAsync failed", this, ex);
            }

            return null;
        }

        public virtual Stream GetResultVideo(string url)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.GetResultVideo",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.GetResultVideo(url);
                    return result;
                },
                null);
        }

        public virtual async Task<Stream> GetResultVideoAsync(string url)
        {
            try {
                var result = await VideoRepository.GetResultVideoAsync(url);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.GetResultVideoAsync failed", this, ex);
            }

            return null;
        }
        
        public virtual VideoOperation MotionDetection(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.MotionDetection",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.MotionDetection(videoUrl, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> MotionDetectionAsync(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0)
        {
            try {
                var result = await VideoRepository.MotionDetectionAsync(videoUrl, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetectionAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation MotionDetection(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.MotionDetection",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.MotionDetection(videoStream, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> MotionDetectionAsync(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0)
        {
            try {
                var result = await VideoRepository.MotionDetectionAsync(videoStream, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetectionAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation Stabilization(string videoUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.Stabilization",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.Stabilization(videoUrl);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> StabilizationAsync(string videoUrl)
        {
            try {
                var result = await VideoRepository.StabilizationAsync(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.StabilizationAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation Stabilization(Stream videoStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.Stabilization",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.Stabilization(videoStream);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> StabilizationAsync(Stream videoStream)
        {
            try {
                var result = await VideoRepository.StabilizationAsync(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.StabilizationAsync failed", this, ex);
            }

            return null;
        }
        
        public virtual VideoOperation Thumbnail(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.Thumbnail",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.Thumbnail(videoUrl, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> ThumbnailAsync(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true)
        {
            try {
                var result = await VideoRepository.ThumbnailAsync(videoUrl, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.ThumbnailAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation Thumbnail(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VideoService.Thumbnail",
                ApiKeys.VideoRetryInSeconds,
                () =>
                {
                    var result = VideoRepository.Thumbnail(videoStream, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);
                    return result;
                },
                null);
        }

        public virtual async Task<VideoOperation> ThumbnailAsync(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true)
        {
            try {
                var result = await VideoRepository.ThumbnailAsync(videoStream, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.ThumbnailAsync failed", this, ex);
            }

            return null;
        }
    }
}