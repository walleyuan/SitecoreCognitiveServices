using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public class VisionRepository : VisionServiceClient, IVisionRepository
    {
        public VisionRepository(
            IApiKeys apiKeys) : base(apiKeys.ComputerVision)
        {
        }
        
        #region AnalyzeImageAsync
        
        public virtual async Task<AnalysisResult> GetFullAnalysisAsync(Stream stream)
        {
            return await AnalyzeImageAsync(stream, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual async Task<AnalysisResult> GetFullAnalysisAsync(string imageUrl)
        {
            return await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags });
        }

        public virtual async Task<Adult> GetAdultAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual async Task<Adult> GetAdultAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Adult });
            return result.Adult;
        }

        public virtual async Task<Category[]> GetCategoryAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual async Task<Category[]> GetCategoryAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Categories });
            return result.Categories;
        }

        public virtual async Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }

        public virtual async Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Color });
            return result.Color;
        }
        
        public virtual async Task<Face[]> GetFaceAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual async Task<Face[]> GetFaceAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.Faces });
            return result.Faces;
        }

        public virtual async Task<ImageType> GetImageTypeAnalysisAsync(Stream stream)
        {
            var result = await AnalyzeImageAsync(stream, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        public virtual async Task<ImageType> GetImageTypeAnalysisAsync(string imageUrl)
        {
            var result = await AnalyzeImageAsync(imageUrl, new List<VisualFeature>() { VisualFeature.ImageType });
            return result.ImageType;
        }

        #endregion AnalyzeImageAsync
    }
}
