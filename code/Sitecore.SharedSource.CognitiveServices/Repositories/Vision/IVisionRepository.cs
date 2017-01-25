using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public interface IVisionRepository : IVisionServiceClient
    {
        Task<AnalysisResult> GetFullAnalysis(Stream stream);
        Task<AnalysisResult> GetFullAnalysis(string imageUrl);
        Task<Adult> GetAdultAnalysis(Stream stream);
        Task<Adult> GetAdultAnalysis(string imageUrl);
        Task<Category[]> GetCategoryAnalysis(Stream stream);
        Task<Category[]> GetCategoryAnalysis(string imageUrl);
        Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysis(Stream stream);
        Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysis(string imageUrl);
        Task<Description> GetDescriptionAnalysis(Stream stream);
        Task<Description> GetDescriptionAnalysis(string imageUrl);
        Task<Face[]> GetFaceAnalysis(Stream stream);
        Task<Face[]> GetFaceAnalysis(string imageUrl);
        Task<ImageType> GetImageTypeAnalysis(Stream stream);
        Task<ImageType> GetImageTypeAnalysis(string imageUrl);
        Task<Tag[]> GetTagsAnalysis(Stream stream);
        Task<Tag[]> GetTagsAnalysis(string imageUrl);
    }
}
