using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Api.Vision
{
    public interface IVisionApi : IVisionServiceClient
    {
        AnalysisResult DescribeAsync(MediaItem mediaItem);
        Description GetDescription(MediaItem mediaItem);
        void SetImageAlt(MediaItem mediaItem);
        Task<AnalysisResult> AnalyzeImageAsync(MediaItem mediaItem, IEnumerable<VisualFeature> features);
        AnalysisResult GetFullAnalysis(MediaItem mediaItem);
        AnalysisResult GetFullAnalysis(string imageUrl);
        Adult GetAdultAnalysis(MediaItem mediaItem);
        Adult GetAdultAnalysis(string imageUrl);
        Category[] GetCategoryAnalysis(MediaItem mediaItem);
        Category[] GetCategoryAnalysis(string imageUrl);
        Microsoft.ProjectOxford.Vision.Contract.Color GetColorAnalysis(MediaItem mediaItem);
        Microsoft.ProjectOxford.Vision.Contract.Color GetColorAnalysis(string imageUrl);
        Description GetDescriptionAnalysis(MediaItem mediaItem);
        Description GetDescriptionAnalysis(string imageUrl);
        Face[] GetFaceAnalysis(MediaItem mediaItem);
        Face[] GetFaceAnalysis(string imageUrl);
        ImageType GetImageTypeAnalysis(MediaItem mediaItem);
        ImageType GetImageTypeAnalysis(string imageUrl);
        Tag[] GetTagsAnalysis(MediaItem mediaItem);
        Tag[] GetTagsAnalysis(string imageUrl);
        Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(MediaItem mediaItem, Model model);
        Task<AnalysisResult> GetTagsAsync(MediaItem mediaItem);
        Task<byte[]> GetThumbnailAsync(MediaItem mediaItem, int height, int width, bool smartCrop);
        Task<OcrResults> RecognizeTextAsync(MediaItem mediaItem, string languageCode, bool detectOrientation);
    }
}
