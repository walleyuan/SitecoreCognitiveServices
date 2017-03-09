
using System.IO;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Models.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision {
    public interface IContentModeratorRepository
    {
        Task<ContentModeratorEvaluateResponse> EvaluateAsync(string imageUrl);
        Task<ContentModeratorEvaluateResponse> EvaluateAsync(Stream stream);
        Task<ContentModeratorFindFacesResponse> FindFacesAsync(string imageUrl);
        Task<ContentModeratorFindFacesResponse> FindFacesAsync(Stream stream);
        Task<ContentModeratorMatchResponse> MatchAsync(string imageUrl, string listId = "");
        Task<ContentModeratorMatchResponse> MatchAsync(Stream stream, string listId = "");
        Task<ContentModeratorOCRResult> OCRAsync(string imageUrl, string language = "", bool enhanced = false);
        Task<ContentModeratorOCRResult> OCRAsync(Stream stream, string language = "", bool enhanced = false);
        Task<ContentModeratorDetectLanguageResponse> DetectLanguageAsync(string text);
        Task<ContentModeratorScreenResponse> ScreenAsync(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "");
    }
}