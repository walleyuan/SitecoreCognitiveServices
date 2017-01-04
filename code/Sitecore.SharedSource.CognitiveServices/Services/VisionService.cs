using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel;
using Sitecore.SharedSource.CognitiveServices.Api.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services
{
    public class VisionService : IVisionService
    {
        public IVisionApi VisionApi;
        public IApiService ApiService;

        public VisionService(
            IVisionApi visionApi,
            IApiService apiService)
        {
            VisionApi = visionApi;
            ApiService = apiService;
        }

        #region DescribeAsync

        public virtual AnalysisResult DescribeAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = VisionApi.DescribeAsync(stream);

                return result.Result;
            }
        }

        public virtual Description GetDescription(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = DescribeAsync(mediaItem);

            return result.Description;
        }

        public virtual void SetImageAlt(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (new SecurityDisabler())
            {
                using (new EditContext(mediaItem))
                {
                    try
                    {
                        var result = GetDescription(mediaItem);

                        mediaItem.Alt = (result.Captions != null && result.Captions.Any())
                            ? result.Captions.First().Text
                            : string.Empty;
                    }
                    catch (Exception ex)
                    {
                        var exception = ex.InnerException as ClientException;
                        if (exception != null)
                            Log.Error("SetAutoAltTag: " + exception.Error.Message, exception, GetType());
                        else
                            Log.Error("SetAutoAltTag: " + ex.Message, ex, GetType());
                    }
                }
            }
        }

        #endregion DescribeAsync

        #region AnalyzeImageAsync

        public virtual AnalysisResult AnalyzeImageAsync(MediaItem mediaItem, IEnumerable<VisualFeature> features)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = Task.Run(async () => await VisionApi.AnalyzeImageAsync(stream, features)).Result;

                return result;
            }
        }

        public virtual AnalysisResult GetFullAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });

            return result;
        }

        public virtual AnalysisResult GetFullAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });

            return result.Result;
        }

        public virtual Adult GetAdultAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual Adult GetAdultAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Result.Adult;
        }

        public virtual Category[] GetCategoryAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual Category[] GetCategoryAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Result.Categories;
        }

        public virtual Microsoft.ProjectOxford.Vision.Contract.Color GetColorAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual Microsoft.ProjectOxford.Vision.Contract.Color GetColorAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Color });
            return result.Result.Color;
        }

        public virtual Description GetDescriptionAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Description });
            return result.Description;
        }

        public virtual Description GetDescriptionAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Description });
            return result.Result.Description;
        }

        public virtual Face[] GetFaceAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual Face[] GetFaceAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Result.Faces;
        }

        public virtual ImageType GetImageTypeAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual ImageType GetImageTypeAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.Result.ImageType;
        }

        public virtual Tag[] GetTagsAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Tags });
            return result.Tags;
        }

        public virtual Tag[] GetTagsAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = VisionApi.AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Tags });
            return result.Result.Tags;
        }

        #endregion AnalyzeImageAsync

        #region AnalyzeImageInDomainAsync

        public virtual Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(MediaItem mediaItem, Model model)
        {
            Assert.IsNotNull(mediaItem, GetType());
            Assert.IsNotNull(model, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = VisionApi.AnalyzeImageInDomainAsync(stream, model);

                return result;
            }
        }

        #endregion AnalyzeImageInDomainAsync

        #region GetTagsAsync

        public virtual Task<AnalysisResult> GetTagsAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = VisionApi.GetTagsAsync(stream);

                return result;
            }
        }

        #endregion GetTagsAsync

        #region GetThumbnailAsync

        public virtual Task<byte[]> GetThumbnailAsync(MediaItem mediaItem, int height, int width, bool smartCrop)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = VisionApi.GetThumbnailAsync(stream, height, width, smartCrop);

                return result;
            }
        }

        #endregion GetThumbnailAsync

        #region RecognizeTextAsync

        public virtual Task<OcrResults> RecognizeTextAsync(MediaItem mediaItem, string languageCode, bool detectOrientation)
        {
            Assert.IsNotNull(mediaItem, GetType());
            Assert.IsNotNullOrEmpty(languageCode, "RecognizeTextAsync: The language code must be provided but was empty");

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = VisionApi.RecognizeTextAsync(stream, languageCode, detectOrientation);

                return result;
            }
        }

        #endregion RecognizeTextAsync
    }
}