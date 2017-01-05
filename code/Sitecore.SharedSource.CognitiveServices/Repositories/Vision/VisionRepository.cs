using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel;
using Sitecore.SharedSource.CognitiveServices.Services;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public class VisionRepository : VisionServiceClient, IVisionRepository
    {
        public IApiService ApiService;

        public VisionRepository(
            IApiKeys apiKeys,
            IApiService apiService) : base(apiKeys.ComputerVision)
        {
            ApiService = apiService;
        }

        #region DescribeAsync

        public virtual async Task<AnalysisResult> DescribeAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return await DescribeAsync(stream);
            }
        }

        #endregion DescribeAsync

        #region AnalyzeImageAsync

        public virtual async Task<AnalysisResult> AnalyzeImageAsync(MediaItem mediaItem, IEnumerable<VisualFeature> features)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return await AnalyzeImageAsync(stream, features);
            }
        }

        public virtual async Task<AnalysisResult> GetFullAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            return await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual async Task<AnalysisResult> GetFullAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            return await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual async Task<Adult> GetAdultAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual async Task<Adult> GetAdultAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual async Task<Category[]> GetCategoryAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual async Task<Category[]> GetCategoryAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual async Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual async Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual async Task<Description> GetDescriptionAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Description });
            return result.Description;
        }

        public virtual async Task<Description> GetDescriptionAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Description });
            return result.Description;
        }

        public virtual async Task<Face[]> GetFaceAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual async Task<Face[]> GetFaceAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual async Task<ImageType> GetImageTypeAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual async Task<ImageType> GetImageTypeAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual async Task<Tag[]> GetTagsAnalysis(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            var result = await AnalyzeImageAsync(mediaItem, new List<VisualFeature>() { VisualFeature.Tags });
            return result.Tags;
        }

        public virtual async Task<Tag[]> GetTagsAnalysis(string imageUrl)
        {
            Assert.IsNotNullOrEmpty(imageUrl, "GetFullAnalysis: image url must be provided but was empty");

            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Tags });
            return result.Tags;
        }

        #endregion AnalyzeImageAsync

        #region AnalyzeImageInDomainAsync

        public virtual Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(MediaItem mediaItem, Model model)
        {
            Assert.IsNotNull(mediaItem, GetType());
            Assert.IsNotNull(model, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return AnalyzeImageInDomainAsync(stream, model);
            }
        }

        #endregion AnalyzeImageInDomainAsync

        #region GetTagsAsync

        public virtual Task<AnalysisResult> GetTagsAsync(MediaItem mediaItem)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                return GetTagsAsync(stream);
            }
        }

        #endregion GetTagsAsync

        #region GetThumbnailAsync

        public virtual Task<byte[]> GetThumbnailAsync(MediaItem mediaItem, int height, int width, bool smartCrop)
        {
            Assert.IsNotNull(mediaItem, GetType());

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = GetThumbnailAsync(stream, height, width, smartCrop);

                return result;
            }
        }

        #endregion GetThumbnailAsync

        #region RecognizeTextAsync

        public virtual Task<OcrResults> RecognizeTextAsync(MediaItem mediaItem, string languageCode, bool detectOrientation = true)
        {
            Assert.IsNotNull(mediaItem, GetType());
            Assert.IsNotNullOrEmpty(languageCode, "RecognizeTextAsync: The language code must be provided but was empty");

            using (MemoryStream stream = ApiService.GetStream(mediaItem))
            {
                var result = RecognizeTextAsync(stream, languageCode, detectOrientation);

                return result;
            }
        }

        #endregion RecognizeTextAsync
    }
}
