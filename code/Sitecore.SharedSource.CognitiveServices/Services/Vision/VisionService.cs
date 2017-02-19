using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

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

        public virtual Description GetDescription(Stream stream)
        {
            Assert.IsNotNull(stream, GetType());

            try
            {
                var result =
                    Task.Run(async () => await VisionRepository.DescribeAsync(stream))
                        .Result.Description;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("VisionService.GetDescription failed", this, ex);
            }

            return null;
        }
        
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

        public virtual AnalysisResult AnalyzeImage(Stream stream, List<VisualFeature> features = null,
            IEnumerable<string> details = null)
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

        public virtual AnalysisResult AnalyzeImage(string imageUrl, List<VisualFeature> features = null,
            IEnumerable<string> details = null)
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
    }
}