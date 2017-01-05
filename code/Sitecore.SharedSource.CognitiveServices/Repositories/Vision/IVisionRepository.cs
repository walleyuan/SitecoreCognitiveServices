using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public interface IVisionRepository : IVisionServiceClient
    {
        Task<AnalysisResult> DescribeAsync(MediaItem mediaItem);
        Task<AnalysisResult> AnalyzeImageAsync(MediaItem mediaItem, IEnumerable<VisualFeature> features);
        Task<AnalysisResult> GetFullAnalysis(MediaItem mediaItem);
        Task<AnalysisResult> GetFullAnalysis(string imageUrl);
        Task<Adult> GetAdultAnalysis(MediaItem mediaItem);
        Task<Adult> GetAdultAnalysis(string imageUrl);
        Task<Category[]> GetCategoryAnalysis(MediaItem mediaItem);
        Task<Category[]> GetCategoryAnalysis(string imageUrl);
        Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysis(MediaItem mediaItem);
        Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysis(string imageUrl);
        Task<Description> GetDescriptionAnalysis(MediaItem mediaItem);
        Task<Description> GetDescriptionAnalysis(string imageUrl);
        Task<Face[]> GetFaceAnalysis(MediaItem mediaItem);
        Task<Face[]> GetFaceAnalysis(string imageUrl);
        Task<ImageType> GetImageTypeAnalysis(MediaItem mediaItem);
        Task<ImageType> GetImageTypeAnalysis(string imageUrl);
        Task<Tag[]> GetTagsAnalysis(MediaItem mediaItem);
        Task<Tag[]> GetTagsAnalysis(string imageUrl);
        Task<AnalysisInDomainResult> AnalyzeImageInDomainAsync(MediaItem mediaItem, Model model);
        Task<AnalysisResult> GetTagsAsync(MediaItem mediaItem);
        Task<byte[]> GetThumbnailAsync(MediaItem mediaItem, int height, int width, bool smartCrop);
        Task<OcrResults> RecognizeTextAsync(MediaItem mediaItem, string languageCode, bool detectOrientation = true);
    }
}
