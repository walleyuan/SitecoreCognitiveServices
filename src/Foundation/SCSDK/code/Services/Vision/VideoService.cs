using System;
using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using MicrosoftCognitiveServices.Foundation.MSSDK.Enums;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using System.Collections.Generic;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Vision
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

        public virtual VideoOperation FaceDetectionAndTracking(string videoUrl) {
            try {
                var result = VideoRepository.FaceDetectionAndTracking(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTracking failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> FaceDetectionAndTrackingAsync(string videoUrl) {
            try {
                var result = await VideoRepository.FaceDetectionAndTrackingAsync(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTrackingAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation FaceDetectionAndTracking(Stream videoStream) {
            try {
                var result = VideoRepository.FaceDetectionAndTracking(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTracking failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> FaceDetectionAndTrackingAsync(Stream videoStream) {
            try {
                var result = await VideoRepository.FaceDetectionAndTrackingAsync(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.FaceDetectionAndTrackingAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperationResult GetOperationResult(VideoOperation operation) {
            try {
                var result = VideoRepository.GetOperationResult(operation);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.GetOperationResult failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperationResult> GetOperationResultAsync(VideoOperation operation) {
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
        
        public virtual VideoOperation MotionDetection(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = VideoRepository.MotionDetection(videoUrl, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetection failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> MotionDetectionAsync(string videoUrl, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = await VideoRepository.MotionDetectionAsync(videoUrl, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetectionAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation MotionDetection(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = VideoRepository.MotionDetection(videoStream, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetection failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> MotionDetectionAsync(Stream videoStream, SensitivityOptions sensitivityLevel = SensitivityOptions.medium, int frameSamplingValue = 1, List<DetectionZone> detectionZones = null, bool detectLightChange = false, double mergeTimeThreshold = 0.0) {
            try {
                var result = await VideoRepository.MotionDetectionAsync(videoStream, sensitivityLevel, frameSamplingValue, detectionZones, detectLightChange, mergeTimeThreshold);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.MotionDetectionAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation Stabilization(string videoUrl) {
            try {
                var result = VideoRepository.Stabilization(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Stabilization failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> StabilizationAsync(string videoUrl) {
            try {
                var result = await VideoRepository.StabilizationAsync(videoUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.StabilizationAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation Stabilization(Stream videoStream) {
            try {
                var result = VideoRepository.Stabilization(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Stabilization failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> StabilizationAsync(Stream videoStream) {
            try {
                var result = await VideoRepository.StabilizationAsync(videoStream);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.StabilizationAsync failed", this, ex);
            }

            return null;
        }
        
        public virtual VideoOperation Thumbnail(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            try {
                var result = VideoRepository.Thumbnail(videoUrl, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Thumbnail failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> ThumbnailAsync(string videoUrl, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            try {
                var result = await VideoRepository.ThumbnailAsync(videoUrl, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.ThumbnailAsync failed", this, ex);
            }

            return null;
        }

        public virtual VideoOperation Thumbnail(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
            try {
                var result = VideoRepository.Thumbnail(videoStream, maxMotionThumbnailDurationInSecs, outputAudio, fadeInFadeOut);

                return result;
            } catch (Exception ex) {
                Logger.Error("VideoService.Thumbnail failed", this, ex);
            }

            return null;
        }

        public virtual async Task<VideoOperation> ThumbnailAsync(Stream videoStream, int maxMotionThumbnailDurationInSecs = 0, bool outputAudio = true, bool fadeInFadeOut = true) {
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