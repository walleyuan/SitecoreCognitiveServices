using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Enums;
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
        Task<bool> CreateOrUpdateWorkflowAsync(string teamName, string workflowName, WorkflowExpression expression);
        Task<WorkflowExpressionResponse> GetWorkflowAsync(string teamName, string workflowName);
        Task<List<WorkflowExpressionResponse>> GetAllWorkflowsAsync(string teamName);
        Task<AddImageResponse> AddImageAsync(string imageUrl, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "");
        Task<AddImageResponse> AddImageAsync(Stream stream, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "");
        Task DeleteImageAsync(string listId, string imageId);
        Task DeleteAllImageAsync(string listId);
        Task<GetImagesResponse> GetAllImageIdsAsync(string listId);
        Task<ListDetails> GetImageListDetailsAsync(string listId);
        Task<ListDetails> CreateListAsync(ListDetails details);
        Task DeleteImageListAsync(string listId);
        Task<List<ListDetails>> GetAllImageListsAsync();
        Task<RefreshSearchResponse> RefreshImageSearchIndexAsync(string listId);
        Task<ListDetails> UpdateImageListDetailsAsync(string listId, ListDetails details);
        Task AddTermAsync(string listId, string term, string language);
        Task DeleteTermAsync(string listId, string term, string language);
        Task DeleteAllTermsAsync(string listId, string language);
        Task<GetTermsResponse> GetAllTermsAsync(string listId, string language);
        Task<ListDetails> CreateTermListAsync(ListDetails details);
        Task DeleteTermListAsync(string listId);
        Task<List<ListDetails>> GetAllTermListsAsync();
        Task<ListDetails> GetTermListDetailsAsync(string listId);
        Task<RefreshSearchResponse> RefreshTermSearchIndexAsync(string listId, string language);
        Task<ListDetails> UpdateTermListDetailsAsync(string listId, ListDetails details);
    }
}