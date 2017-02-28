using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Video.Contract;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

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
        
        public virtual Operation CreateOperation(Stream video, VideoOperationSettings operationSettings)
        {
            try
            {
                var result = Task.Run(async () => await VideoRepository.CreateOperationAsync(video, operationSettings)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VideoService.CreateOperation failed", this, ex);
            }

            return null;
        }

        public virtual Operation CreateOperation(byte[] video, VideoOperationSettings operationSettings)
        {
            try
            {
                var result = Task.Run(async () => await VideoRepository.CreateOperationAsync(video, operationSettings)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VideoService.CreateOperation failed", this, ex);
            }

            return null;
        }

        public virtual Operation CreateOperation(string videoUrl, VideoOperationSettings operationSettings)
        {
            try
            {
                var result = Task.Run(async () => await VideoRepository.CreateOperationAsync(videoUrl, operationSettings)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VideoService.CreateOperation failed", this, ex);
            }

            return null;
        }

        public virtual OperationResult GetOperationResult(Operation operation)
        {
            try
            {
                var result = Task.Run(async () => await VideoRepository.GetOperationResultAsync(operation)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VideoService.GetOperationResult failed", this, ex);
            }

            return null;
        }

        public virtual Stream GetResultVideo(string url)
        {
            try
            {
                var result = Task.Run(async () => await VideoRepository.GetResultVideoAsync(url)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VideoService.GetResultVideo failed", this, ex);
            }

            return null;
        }
    }
}