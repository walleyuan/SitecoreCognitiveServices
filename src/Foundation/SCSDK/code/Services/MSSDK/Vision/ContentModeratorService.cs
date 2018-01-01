using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision
{
    public class ContentModeratorService : IContentModeratorService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IContentModeratorRepository ContentModeratorRepository;
        protected readonly ILogWrapper Logger;

        public ContentModeratorService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IContentModeratorRepository contentModeratorRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            ContentModeratorRepository = contentModeratorRepository;
            Logger = logger;
        }

        #region Moderate

        public virtual EvaluateResponse Evaluate(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.Evaluate",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.Evaluate(imageUrl);
                    return result;
                },
                null);
        }

        public virtual EvaluateResponse Evaluate(Stream stream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.Evaluate",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.Evaluate(stream);
                    return result;
                },
                null);
        }

        public virtual FindFacesResponse FindFaces(string imageUrl)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.FindFaces",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.FindFaces(imageUrl);
                    return result;
                },
                null);
        }

        public virtual FindFacesResponse FindFaces(Stream stream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.FindFaces",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.FindFaces(stream);
                    return result;
                },
                null);
        }

        public virtual MatchResponse Match(string imageUrl, string listId = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.Match",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.Match(imageUrl);
                    return result;
                },
                null);
        }

        public virtual MatchResponse Match(Stream stream, string listId = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.Match",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.Match(stream, listId);
                    return result;
                },
                null);
        }

        public virtual OCRResult OCR(string imageUrl, string language = "", bool enhanced = false)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.OCR",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.OCR(imageUrl, language, enhanced);
                    return result;
                },
                null);
        }

        public virtual OCRResult OCR(Stream stream, string language = "", bool enhanced = false)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.OCR",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.OCR(stream, language, enhanced);
                    return result;
                },
                null);
        }

        public virtual DetectLanguageResponse DetectLanguage(string text)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.DetectLanguage",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.DetectLanguage(text);
                    return result;
                },
                null);
        }

        public virtual ScreenResponse Screen(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.Screen",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.Screen(text, language, autocorrect, urls, PII, listId);
                    return result;
                },
                null);
        }

        #endregion Moderate

        #region Review

        public virtual CreateJobResponse CreateImageJob(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.CreateImageJob",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.CreateImageJob(imageUrl, teamName, contentId, workflowName, callbackEndpoint);
                    return result;
                },
                null);
        }

        public virtual CreateJobResponse CreateImageJob(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.CreateImageJob",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.CreateImageJob(stream, teamName, contentId, workflowName, callbackEndpoint);
                    return result;
                },
                null);
        }

        public virtual CreateJobResponse CreateTextJob(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.CreateTextJob",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.CreateTextJob(text, teamName, contentId, workflowName, callbackEndpoint);
                    return result;
                },
                null);
        }

        public virtual GetJobResponse GetJob(string teamName, string jobId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetJob",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetJob(teamName, jobId);
                    return result;
                },
                null);
        }

        public virtual List<string> CreateReview(string teamName, List<ReviewRequest> requests, string subTeam = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.CreateReview",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.CreateReview(teamName, requests, subTeam);
                    return result;
                },
                null);
        }

        public virtual GetReviewResponse GetReview(string teamName, string reviewId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetReview",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetReview(teamName, reviewId);
                    return result;
                },
                null);
        }

        public virtual bool CreateOrUpdateWorkflow(string teamName, string workflowName, WorkflowExpression expression)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.CreateOrUpdateWorkflow",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.CreateOrUpdateWorkflow(teamName, workflowName, expression);
                    return result;
                },
                false);
        }

        public virtual WorkflowExpressionResponse GetWorkflow(string teamName, string workflowName)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetWorkflow",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetWorkflow(teamName, workflowName);
                    return result;
                },
                null);
        }

        public virtual List<WorkflowExpressionResponse> GetAllWorkflows(string teamName)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetAllWorkflows",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetAllWorkflows(teamName);
                    return result;
                },
                null);
        }

        #endregion Review

        #region List Management 

        public virtual AddImageResponse AddImage(string imageUrl, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.AddImage",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.AddImage(imageUrl, listId, tag, label);
                    return result;
                },
                null);
        }

        public virtual AddImageResponse AddImage(Stream stream, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.AddImage",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.AddImage(stream, listId, tag, label);
                    return result;
                },
                null);
        }

        public virtual bool DeleteImage(string listId, string imageId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.DeleteImage",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    ContentModeratorRepository.DeleteImage(listId, imageId);
                    return true;
                },
                false);
        }

        public virtual bool DeleteAllImage(string listId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.DeleteAllImage",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    ContentModeratorRepository.DeleteAllImage(listId);
                    return true;
                },
                false);
        }

        public virtual GetImagesResponse GetAllImageIds(string listId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetAllImageIds",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetAllImageIds(listId);
                    return result;
                },
                null);
        }

        public virtual ListDetails GetImageListDetails(string listId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetImageListDetails",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetImageListDetails(listId);
                    return result;
                },
                null);
        }

        public virtual ListDetails CreateList(ListDetails details)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.CreateList",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.CreateList(details);
                    return result;
                },
                null);
        }

        public virtual bool DeleteImageList(string listId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.DeleteImageList",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    ContentModeratorRepository.DeleteImageList(listId);
                    return true;
                },
                false);
        }

        public virtual List<ListDetails> GetAllImageLists()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetAllImageLists",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetAllImageLists();
                    return result;
                },
                null);
        }

        public virtual RefreshSearchResponse RefreshImageSearchIndex(string listId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.RefreshImageSearchIndex",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.RefreshImageSearchIndex(listId);
                    return result;
                },
                null);
        }

        public virtual ListDetails UpdateImageListDetails(string listId, ListDetails details)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.UpdateImageListDetails",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.UpdateImageListDetails(listId, details);
                    return result;
                },
                null);
        }

        public virtual bool AddTerm(string listId, string term, string language)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.AddTerm",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    ContentModeratorRepository.AddTerm(listId, term, language);
                    return true;
                },
                false);
        }

        public virtual bool DeleteTerm(string listId, string term, string language)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.DeleteTerm",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    ContentModeratorRepository.DeleteTerm(listId, term, language);
                    return true;
                },
                false);
        }

        public virtual bool DeleteAllTerms(string listId, string language)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.DeleteAllTerms",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    ContentModeratorRepository.DeleteAllTerms(listId, language);
                    return true;
                },
                false);
        }

        public virtual GetTermsResponse GetAllTerms(string listId, string language)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetAllTerms",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetAllTerms(listId, language);
                    return result;
                },
                null);
        }

        public virtual ListDetails CreateTermList(ListDetails details)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.CreateTermList",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.CreateTermList(details);
                    return result;
                },
                null);
        }

        public virtual bool DeleteTermList(string listId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.DeleteTermList",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    ContentModeratorRepository.DeleteTermList(listId);
                    return true;
                },
                false);
        }

        public virtual List<ListDetails> GetAllTermLists()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetAllTermLists",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetAllTermLists();
                    return result;
                },
                null);
        }

        public virtual ListDetails GetTermListDetails(string listId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.GetTermListDetails",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.GetTermListDetails(listId);
                    return result;
                },
                null);
        }

        public virtual RefreshSearchResponse RefreshTermSearchIndex(string listId, string language)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.RefreshTermSearchIndex",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.RefreshTermSearchIndex(listId, language);
                    return result;
                },
                null);
        }

        public virtual ListDetails UpdateTermListDetails(string listId, ListDetails details)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "ContentModeratorService.UpdateTermListDetails",
                ApiKeys.ContentModeratorRetryInSeconds,
                () =>
                {
                    var result = ContentModeratorRepository.UpdateTermListDetails(listId, details);
                    return result;
                },
                null);
        }

        #endregion List Management
    }
}