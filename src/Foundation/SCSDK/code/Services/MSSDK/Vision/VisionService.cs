using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;
using Polly;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public class VisionService : IVisionService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IVisionRepository VisionRepository;
        protected readonly ILogWrapper Logger;

        public VisionService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IVisionRepository visionRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            VisionRepository = visionRepository;
            Logger = logger;
        }

        #region Adult

        public virtual Adult GetAdultAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetAdultAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetAdultAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual Adult GetAdultAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetAdultAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetAdultAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Adult

        #region Categories

        public virtual Category[] GetCategoryAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetCategoryAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetCategoryAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual Category[] GetCategoryAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetCategoryAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetCategoryAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Categories

        #region Color

        public virtual Color GetColorAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetColorAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetColorAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual Color GetColorAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetColorAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetColorAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Color

        #region Face

        public virtual SimpleFace[] GetFaceAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFaceAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetFaceAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual SimpleFace[] GetFaceAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFaceAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetFaceAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Face

        #region Full Analysis

        public virtual AnalysisResult GetFullAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFullAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetFullAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual AnalysisResult GetFullAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetFullAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetFullAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Full Analysis

        #region Image Type

        public virtual ImageType GetImageTypeAnalysis(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetImageTypeAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetImageTypeAnalysis(imageUrl);
                    return result;
                },
                null);
        }

        public virtual ImageType GetImageTypeAnalysis(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetImageTypeAnalysis",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetImageTypeAnalysis(imageStream);
                    return result;
                },
                null);
        }

        #endregion Image Type

        #region Analyze Image
        
        public virtual AnalysisResult AnalyzeImage(Stream stream, List<VisualFeature> features = null, IEnumerable<string> details = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImage",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.AnalyzeImage(stream, features, details);
                    return result;
                },
                null);
        }

        public virtual AnalysisResult AnalyzeImage(string imageUrl, List<VisualFeature> features = null, IEnumerable<string> details = null)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImage",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.AnalyzeImage(imageUrl, features, details);
                    return result;
                },
                null);
        }

        #endregion Analyze Image

        #region Analyze Image In Domain

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, Model model)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.AnalyzeImageInDomain(url, model);
                    return result;
                },
                null);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, Model model)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.AnalyzeImageInDomain(imageStream, model);
                    return result;
                },
                null);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(string url, string modelName)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.AnalyzeImageInDomain(url, modelName);
                    return result;
                },
                null);
        }

        public virtual AnalysisInDomainResult AnalyzeImageInDomain(Stream imageStream, string modelName)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.AnalyzeImageInDomain",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.AnalyzeImageInDomain(imageStream, modelName);
                    return result;
                },
                null);
        }

        #endregion Analyze Image In Domain

        #region List Models

        public virtual ModelResult ListModels()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.ListModels",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.ListModels();
                    return result;
                },
                null);
        }

        #endregion List Models

        #region Describe
        
        public virtual Description Describe(string url, int maxCandidates = 1)
        {
            Assert.IsNotNull(url, GetType());

            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.Describe",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.Describe(url, maxCandidates).Description;
                    return result;
                },
                null);
        }

        public virtual Description Describe(Stream imageStream, int maxCandidates = 1)
        {
            Assert.IsNotNull(imageStream, GetType());

            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.Describe",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.Describe(imageStream, maxCandidates).Description;
                    return result;
                },
                null);
        }

        #endregion Describe

        #region Get Thumbnail
        
        public virtual byte[] GetThumbnail(string url, int width, int height, bool smartCropping = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetThumbnail",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetThumbnail(url, width, height, smartCropping);
                    return result;
                },
                null);
        }

        public virtual byte[] GetThumbnail(Stream stream, int width, int height, bool smartCropping = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetThumbnail",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetThumbnail(stream, width, height, smartCropping);
                    return result;
                },
                null);
        }

        #endregion Get Thumbnail

        #region Recognize Text

        public virtual OcrResults RecognizeText(Stream stream, string language = "unk", bool detectOrientation = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.RecognizeText",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.RecognizeText(stream, language, detectOrientation);
                    return result;
                },
                null);
        }

        public virtual OcrResults RecognizeText(string imageUrl, string language = "unk", bool detectOrientation = true)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.RecognizeText",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.RecognizeText(imageUrl, language, detectOrientation);
                    return result;
                },
                null);
        }
        
        #endregion Recognize Text

        #region Get Tags

        public virtual Tag[] GetTags(string url)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetTags",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetTags(url).Tags;
                    return result;
                },
                null);
        }
        
        public virtual Tag[] GetTags(Stream imageStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "VisionService.GetTags",
                ApiKeys.ComputerVisionRetryInSeconds,
                () =>
                {
                    var result = VisionRepository.GetTags(imageStream).Tags;
                    return result;
                },
                null);
        }

        #endregion Get Tags
    }
}