using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision {
    public interface IContentModeratorRepository
    {
        Task<EvaluateResponse> EvaluateAsync(string imageUrl);
        Task<EvaluateResponse> EvaluateAsync(Stream stream);
        Task<FindFacesResponse> FindFacesAsync(string imageUrl);
        Task<FindFacesResponse> FindFacesAsync(Stream stream);
        Task<MatchResponse> MatchAsync(string imageUrl, string listId = "");
        Task<MatchResponse> MatchAsync(Stream stream, string listId = "");
        Task<OCRResult> OCRAsync(string imageUrl, string language = "", bool enhanced = false);
        Task<OCRResult> OCRAsync(Stream stream, string language = "", bool enhanced = false);
        Task<DetectLanguageResponse> DetectLanguageAsync(string text);
        Task<ScreenResponse> ScreenAsync(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "");
        Task<CreateJobResponse> CreateImageJobAsync(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        Task<CreateJobResponse> CreateImageJobAsync(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        Task<CreateJobResponse> CreateTextJobAsync(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        Task<GetJobResponse> GetJobAsync(string teamName, string jobId);
        Task<List<string>> CreateReviewAsync(string teamName, List<ReviewRequest> requests, string subTeam = "");
        Task<GetReviewResponse> GetReviewAsync(string teamName, string reviewId);
        Task CreateOrUpdateWorkflowAsync(string teamName, string workflowName, WorkflowExpression expression);
        Task<WorkflowExpression> GetWorkflowAsync(string teamName, string workflowName);
        Task<List<WorkflowExpression>> GetAllWorkflowsAsync(string teamName);
    }
}