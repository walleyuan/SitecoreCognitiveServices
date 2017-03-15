using System.Collections.Generic;
using System.IO;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IContentModeratorService
    {
        EvaluateResponse Evaluate(string imageUrl);
        EvaluateResponse Evaluate(Stream stream);
        FindFacesResponse FindFaces(string imageUrl);
        FindFacesResponse FindFaces(Stream stream);
        MatchResponse Match(string imageUrl, string listId = "");
        MatchResponse Match(Stream stream, string listId = "");
        OCRResult OCR(string imageUrl, string language = "", bool enhanced = false);
        OCRResult OCR(Stream stream, string language = "", bool enhanced = false);
        DetectLanguageResponse DetectLanguage(string text);
        ScreenResponse Screen(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "");
        CreateJobResponse CreateImageJob(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        CreateJobResponse CreateImageJob(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        CreateJobResponse CreateTextJob(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        GetJobResponse GetJob(string teamName, string jobId);
        List<string> CreateReview(string teamName, List<ReviewRequest> requests, string subTeam = "");
        GetReviewResponse GetReview(string teamName, string reviewId);
        bool CreateOrUpdateWorkflow(string teamName, string workflowName, WorkflowExpression expression);
        WorkflowExpressionResponse GetWorkflow(string teamName, string workflowName);
        List<WorkflowExpressionResponse> GetAllWorkflows(string teamName);
        AddImageResponse AddImage(string imageUrl, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "");
        AddImageResponse AddImage(Stream stream, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "");
        bool DeleteImage(string listId, string imageId);
        bool DeleteAllImage(string listId);
        GetImagesResponse GetAllImageIds(string listId);
        ListDetails GetImageListDetails(string listId);
        ListDetails CreateList(ListDetails details);
        bool DeleteImageList(string listId);
        List<ListDetails> GetAllImageLists();
        RefreshSearchResponse RefreshImageSearchIndex(string listId);
        ListDetails UpdateImageListDetails(string listId, ListDetails details);
        bool AddTerm(string listId, string term, string language);
        bool DeleteTerm(string listId, string term, string language);
        bool DeleteAllTerms(string listId, string language);
        GetTermsResponse GetAllTerms(string listId, string language);
        ListDetails CreateTermList(ListDetails details);
        bool DeleteTermList(string listId);
        List<ListDetails> GetAllTermLists();
        ListDetails GetTermListDetails(string listId);
        RefreshSearchResponse RefreshTermSearchIndex(string listId, string language);
        ListDetails UpdateTermListDetails(string listId, ListDetails details);
    }
}