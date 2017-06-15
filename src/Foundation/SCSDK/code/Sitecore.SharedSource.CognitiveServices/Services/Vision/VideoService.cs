using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Video.Contract;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Vision;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class VideoService : IVideoService
    {
        protected IVideoRepository VideoRepository;
        protected ILogWrapper Logger;

        public VideoService(
            IVideoRepository videoRepository,
            ILogWrapper logger)
        {
            VideoRepository = videoRepository;
            Logger = logger;
        }

        public virtual Operation FaceDetectionAndTracking(string videoUrl) {
            try {
                var result = VideoRepository.FaceDetectionAndTracking(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTracking failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> FaceDetectionAndTrackingAsync(string videoUrl) {
            try {
                var result = await VideoRepository.FaceDetectionAndTrackingAsync(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTrackingAsync failed", this, ex);
            }

            return null;
        }

        public virtual Operation FaceDetectionAndTracking(Stream videoStream) {
            try {
                var result = VideoRepository.FaceDetectionAndTracking(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTracking failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> FaceDetectionAndTrackingAsync(Stream videoStream) {
            try {
                var result = await VideoRepository.FaceDetectionAndTrackingAsync(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTrackingAsync failed", this, ex);
            }

            return null;
        }

        public virtual OperationResult GetOperationResult(Operation operation) {
            try {
                var result = VideoRepository.GetOperationResult(operation);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.GetOperationResult failed", this, ex);
            }

            return null;
        }

        public virtual async Task<OperationResult> GetOperationResultAsync(Operation operation) {
            try {
                var result = await VideoRepository.GetOperationResultAsync(operation);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.GetOperationResultAsync failed", this, ex);
            }

            return null;
        }

        public virtual Stream GetResultVideo(string url) {
            try {
                var result = VideoRepository.GetResultVideo(url);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.GetResultVideo failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Stream> GetResultVideoAsync(string url) {
            try {
                var result = await VideoRepository.GetResultVideoAsync(url);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.GetResultVideoAsync failed", this, ex);
            }

            return null;
        }
        
        public virtual Operation MotionDetection(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = VideoRepository.MotionDetection(videoUrl, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetection failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> MotionDetectionAsync(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = await VideoRepository.MotionDetectionAsync(videoUrl, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetectionAsync failed", this, ex);
            }

            return null;
        }

        public virtual Operation MotionDetection(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = VideoRepository.MotionDetection(videoStream, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetection failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> MotionDetectionAsync(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = await VideoRepository.MotionDetectionAsync(videoStream, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetectionAsync failed", this, ex);
            }

            return null;
        }

        public virtual Operation Stabilization(string videoUrl) {
            try {
                var result = VideoRepository.Stabilization(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Stabilization failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> StabilizationAsync(string videoUrl) {
            try {
                var result = await VideoRepository.StabilizationAsync(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.StabilizationAsync failed", this, ex);
            }

            return null;
        }

        public virtual Operation Stabilization(Stream videoStream) {
            try {
                var result = VideoRepository.Stabilization(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Stabilization failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> StabilizationAsync(Stream videoStream) {
            try {
                var result = await VideoRepository.StabilizationAsync(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.StabilizationAsync failed", this, ex);
            }

            return null;
        }
        
        public virtual Operation Thumbnail(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            try {
                var result = VideoRepository.Thumbnail(videoUrl, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Thumbnail failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> ThumbnailAsync(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            try {
                var result = await VideoRepository.ThumbnailAsync(videoUrl, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.ThumbnailAsync failed", this, ex);
            }

            return null;
        }

        public virtual Operation Thumbnail(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            try {
                var result = VideoRepository.Thumbnail(videoStream, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Thumbnail failed", this, ex);
            }

            return null;
        }

        public virtual async Task<Operation> ThumbnailAsync(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
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