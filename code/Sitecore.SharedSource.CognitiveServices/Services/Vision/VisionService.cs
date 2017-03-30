using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Repositories.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class VisionService : IVisionService
    {
        protected IVisionRepository VisionRepository;
        protected ILogWrapper Logger;

        public VisionService(
            IVisionRepository visionRepository,
            ILogWrapper logger)
        {
            VisionRepository = visionRepository;
            Logger = logger;
        }

        #region Adult

        public virtual Adult GetAdultAnalysis(string imageUrl)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetAdultAnalysis(imageUrl)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"VisionService.GetAdultAnalysis failed on: {imageUrl}", this, ex);
            }

            return null;
        }

        public virtual Adult GetAdultAnalysis(Stream imageStream)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetAdultAnalysis(imageStream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetAdultAnalysis failed", this, ex);
            }

            return null;
        }

        #endregion Adult

        #region Categories

        public virtual Category[] GetCategoryAnalysis(string imageUrl)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetCategoryAnalysis(imageUrl)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"VisionService.GetCategoryAnalysis failed on: {imageUrl}", this, ex);
            }

            return null;
        }

        public virtual Category[] GetCategoryAnalysis(Stream imageStream)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetCategoryAnalysis(imageStream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetCategoryAnalysis failed", this, ex);
            }

            return null;
        }

        #endregion Categories

        #region Color

        public virtual Color GetColorAnalysis(string imageUrl)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetColorAnalysis(imageUrl)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"VisionService.GetColorAnalysis failed on: {imageUrl}", this, ex);
            }

            return null;
        }

        public virtual Color GetColorAnalysis(Stream imageStream)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetColorAnalysis(imageStream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetColorAnalysis failed", this, ex);
            }

            return null;
        }

        #endregion Color

        #region Face

        public virtual Face[] GetFaceAnalysis(string imageUrl)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetFaceAnalysis(imageUrl)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"VisionService.GetFaceAnalysis failed on: {imageUrl}", this, ex);
            }

            return null;
        }

        public virtual Face[] GetFaceAnalysis(Stream imageStream)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetFaceAnalysis(imageStream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetFaceAnalysis failed", this, ex);
            }

            return null;
        }

        #endregion Face

        #region Full Analysis

        public virtual AnalysisResult GetFullAnalysis(string imageUrl)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetFullAnalysis(imageUrl)).Result;
                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetFullAnalysis failed", this, ex);
            }

            return null;
        }

        public virtual AnalysisResult GetFullAnalysis(Stream imageStream)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetFullAnalysis(imageStream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetFullAnalysis failed", this, ex);
            }

            return null;
        }

        #endregion Full Analysis

        #region Image Type

        public virtual ImageType GetImageTypeAnalysis(string imageUrl)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetImageTypeAnalysis(imageUrl)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"VisionService.GetImageTypeAnalysis failed on: {imageUrl}", this, ex);
            }

            return null;
        }

        public virtual ImageType GetImageTypeAnalysis(Stream imageStream)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetImageTypeAnalysis(imageStream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetImageTypeAnalysis failed", this, ex);
            }

            return null;
        }

        #endregion Image Type

        #region Analyze Image

        public virtual AnalysisResult AnalyzeImage(string url, string[] visualFeatures = null)
        {
            try
            {
                var result =
                    Task.Run(async () => await VisionRepository.AnalyzeImageAsync(url, visualFeatures)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.AnalyzeImage failed", this, ex);
            }

            return null;
        }
        
        public virtual AnalysisResult AnalyzeImage(Stream imageStream, string[] visualFeatures = null)
        {
            try
            {
                var result =
                    Task.Run(async () => await VisionRepository.AnalyzeImageAsync(imageStream, visualFeatures)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.AnalyzeImage failed", this, ex);
            }

            return null;
        }

        public virtual AnalysisResult AnalyzeImage(Stream stream, List<VisualFeature> features = null, IEnumerable<string> details = null)
        {
            try
            {
                var result =
                    Task.Run(async () => await VisionRepository.AnalyzeImageAsync(stream, features, details)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.AnalyzeImage failed", this, ex);
            }

            return null;
        }

        public virtual AnalysisResult AnalyzeImage(string imageUrl, List<VisualFeature> features = null, IEnumerable<string> details = null)
        {
            try
            {
                var result =
                    Task.Run(async () => await VisionRepository.AnalyzeImageAsync(imageUrl, features, details)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"VisionService.AnalyzeImage failed on: {imageUrl}", this, ex);
            }

            return null;
        }

        #endregion Analyze Image

        #region Analyze Image In Domain

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, Model model)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.AnalyzeImageInDomainAsync(url, model)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.AnalyzeImageInDomain failed", this, ex);
            }

            return null;
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, Model model)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.AnalyzeImageInDomainAsync(imageStream, model)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.AnalyzeImageInDomain failed", this, ex);
            }

            return null;
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, string modelName)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.AnalyzeImageInDomainAsync(url, modelName)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.AnalyzeImageInDomain failed", this, ex);
            }

            return null;
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, string modelName)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.AnalyzeImageInDomainAsync(imageStream, modelName)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.AnalyzeImageInDomain failed", this, ex);
            }

            return null;
        }

        #endregion Analyze Image In Domain

        #region List Models

        public virtual ModelResult ListModels()
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.ListModelsAsync()).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.ListModels failed", this, ex);
            }

            return null;
        }

        #endregion List Models

        #region Describe
        
        public virtual Description Describe(string url, int maxCandidates = 1)
        {
            Assert.IsNotNull(url, GetType());

            try
            {
                var result = Task.Run(async () => await VisionRepository.DescribeAsync(url, maxCandidates)).Result.Description;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.Describe failed", this, ex);
            }

            return null;
        }

        public virtual Description Describe(Stream imageStream, int maxCandidates = 1)
        {
            Assert.IsNotNull(imageStream, GetType());

            try
            {
                var result = Task.Run(async () => await VisionRepository.DescribeAsync(imageStream, maxCandidates)).Result.Description;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.Describe failed", this, ex);
            }

            return null;
        }

        #endregion Describe

        #region Get Thumbnail
        
        public virtual byte[] GetThumbnail(string url, int width, int height, bool smartCropping = true)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetThumbnailAsync(url, width, height, smartCropping)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetThumbnail failed", this, ex);
            }

            return null;
        }

        public virtual byte[] GetThumbnail(Stream stream, int width, int height, bool smartCropping = true)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetThumbnailAsync(stream, width, height, smartCropping)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetThumbnail failed", this, ex);
            }

            return null;
        }

        #endregion Get Thumbnail

        #region Recognize Text

        public virtual OcrResults RecognizeText(Stream stream, string language = "unk", bool detectOrientation = true)
        {
            try
            {
                var result =
                    Task.Run(async () => await VisionRepository.RecognizeTextAsync(stream, language, detectOrientation))
                        .Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.RecognizeText failed", this, ex);
            }

            return null;
        }

        public virtual OcrResults RecognizeText(string imageUrl, string language = "unk", bool detectOrientation = true)
        {
            try
            {
                var result =
                    Task.Run(
                        async () => await VisionRepository.RecognizeTextAsync(imageUrl, language, detectOrientation))
                        .Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"VisionService.RecognizeText failed on: {imageUrl}", this, ex);
            }

            return null;
        }
        
        #endregion Recognize Text

        #region Get Tags

        public virtual Tag[] GetTags(string url)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetTagsAsync(url)).Result.Tags;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetTags failed", this, ex);
            }

            return null;
        }
        
        public virtual Tag[] GetTags(Stream imageStream)
        {
            try
            {
                var result = Task.Run(async () => await VisionRepository.GetTagsAsync(imageStream)).Result.Tags;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetTags failed", this, ex);
            }

            return null;
        }

        #endregion Get Tags
    }
}