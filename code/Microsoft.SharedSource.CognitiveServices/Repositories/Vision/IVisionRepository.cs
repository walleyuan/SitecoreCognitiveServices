using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Vision
{
    public interface IVisionRepository : IVisionServiceClient
    {
        Task<AnalysisResult> GetFullAnalysisAsync(Stream stream);
        Task<AnalysisResult> GetFullAnalysisAsync(string imageUrl);
        Task<Adult> GetAdultAnalysisAsync(Stream stream);
        Task<Adult> GetAdultAnalysisAsync(string imageUrl);
        Task<Category[]> GetCategoryAnalysisAsync(Stream stream);
        Task<Category[]> GetCategoryAnalysisAsync(string imageUrl);
        Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysisAsync(Stream stream);
        Task<Microsoft.ProjectOxford.Vision.Contract.Color> GetColorAnalysisAsync(string imageUrl);
        Task<Face[]> GetFaceAnalysisAsync(Stream stream);
        Task<Face[]> GetFaceAnalysisAsync(string imageUrl);
        Task<ImageType> GetImageTypeAnalysisAsync(Stream stream);
        Task<ImageType> GetImageTypeAnalysisAsync(string imageUrl);
    }
}
