using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator;
using Microsoft.SharedSource.CognitiveServices.Repositories.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public class ContentModeratorService : IContentModeratorService
    {
        protected IContentModeratorRepository ContentModeratorRepository;
        protected ILogWrapper Logger;

        public ContentModeratorService(
            IContentModeratorRepository contentModeratorRepository,
            ILogWrapper logger)
        {
            ContentModeratorRepository = contentModeratorRepository;
            Logger = logger;
        }

        #region Moderate

        public virtual EvaluateResponse Evaluate(string imageUrl)
        {
            try
            {
                var result = ContentModeratorRepository.Evaluate(imageUrl);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.Evaluate failed", this, ex);
            }

            return null;
        }

        public virtual EvaluateResponse Evaluate(Stream stream)
        {
            try
            {
                var result = ContentModeratorRepository.Evaluate(stream);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.Evaluate failed", this, ex);
            }

            return null;
        }

        public virtual FindFacesResponse FindFaces(string imageUrl)
        {
            try
            {
                var result = ContentModeratorRepository.FindFaces(imageUrl);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.FindFaces failed", this, ex);
            }

            return null;
        }

        public virtual FindFacesResponse FindFaces(Stream stream)
        {
            try
            {
                var result = ContentModeratorRepository.FindFaces(stream);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.FindFaces failed", this, ex);
            }

            return null;
        }

        public virtual MatchResponse Match(string imageUrl, string listId = "")
        {
            try
            {
                var result = ContentModeratorRepository.Match(imageUrl);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.Match failed", this, ex);
            }

            return null;
        }

        public virtual MatchResponse Match(Stream stream, string listId = "")
        {
            try
            {
                var result = ContentModeratorRepository.Match(stream, listId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.Match failed", this, ex);
            }

            return null;
        }

        public virtual OCRResult OCR(string imageUrl, string language = "", bool enhanced = false)
        {
            try
            {
                var result = ContentModeratorRepository.OCR(imageUrl, language, enhanced);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.OCR failed", this, ex);
            }

            return null;
        }

        public virtual OCRResult OCR(Stream stream, string language = "", bool enhanced = false)
        {
            try
            {
                var result = ContentModeratorRepository.OCR(stream, language, enhanced);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.OCR failed", this, ex);
            }

            return null;
        }

        public virtual DetectLanguageResponse DetectLanguage(string text)
        {
            try
            {
                var result = ContentModeratorRepository.DetectLanguage(text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DetectLanguage failed", this, ex);
            }

            return null;
        }

        public virtual ScreenResponse Screen(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "")
        {
            try
            {
                var result = ContentModeratorRepository.Screen(text, language, autocorrect, urls, PII, listId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.Screen failed", this, ex);
            }

            return null;
        }

        #endregion Moderate

        #region Review

        public virtual CreateJobResponse CreateImageJob(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            try
            {
                var result = ContentModeratorRepository.CreateImageJob(imageUrl, teamName, contentId, workflowName, callbackEndpoint);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateImageJob failed", this, ex);
            }

            return null;
        }

        public virtual CreateJobResponse CreateImageJob(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            try
            {
                var result = ContentModeratorRepository.CreateImageJob(stream, teamName, contentId, workflowName, callbackEndpoint);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateImageJob failed", this, ex);
            }

            return null;
        }

        public virtual CreateJobResponse CreateTextJob(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            try
            {
                var result = ContentModeratorRepository.CreateTextJob(text, teamName, contentId, workflowName, callbackEndpoint);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateTextJob failed", this, ex);
            }

            return null;
        }

        public virtual GetJobResponse GetJob(string teamName, string jobId)
        {
            try
            {
                var result = ContentModeratorRepository.GetJob(teamName, jobId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetJob failed", this, ex);
            }

            return null;
        }

        public virtual List<string> CreateReview(string teamName, List<ReviewRequest> requests, string subTeam = "")
        {
            try
            {
                var result = ContentModeratorRepository.CreateReview(teamName, requests, subTeam);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateReview failed", this, ex);
            }

            return null;
        }

        public virtual GetReviewResponse GetReview(string teamName, string reviewId)
        {
            try
            {
                var result = ContentModeratorRepository.GetReview(teamName, reviewId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetReview failed", this, ex);
            }

            return null;
        }

        public virtual bool CreateOrUpdateWorkflow(string teamName, string workflowName, WorkflowExpression expression)
        {
            try
            {
                var result = ContentModeratorRepository.CreateOrUpdateWorkflow(teamName, workflowName, expression);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateOrUpdateWorkflow failed", this, ex);
            }

            return false;
        }

        public virtual WorkflowExpressionResponse GetWorkflow(string teamName, string workflowName)
        {
            try
            {
                var result = ContentModeratorRepository.GetWorkflow(teamName, workflowName);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetWorkflow failed", this, ex);
            }

            return null;
        }

        public virtual List<WorkflowExpressionResponse> GetAllWorkflows(string teamName)
        {
            try
            {
                var result = ContentModeratorRepository.GetAllWorkflows(teamName);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetAllWorkflows failed", this, ex);
            }

            return null;
        }

        #endregion Review

        #region List Management 

        public virtual AddImageResponse AddImage(string imageUrl, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "")
        {
            try
            {
                var result = ContentModeratorRepository.AddImage(imageUrl, listId, tag, label);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"ContentModeratorService.AddImage failed: {imageUrl}", this, ex);
            }

            return null;
        }

        public virtual AddImageResponse AddImage(Stream stream, string listId, ContentModeratorTag tag = ContentModeratorTag.None, string label = "")
        {
            try
            {
                var result = ContentModeratorRepository.AddImage(stream, listId, tag, label);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.AddImage failed", this, ex);
            }

            return null;
        }

        public virtual bool DeleteImage(string listId, string imageId)
        {
            try
            {
                ContentModeratorRepository.DeleteImage(listId, imageId);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteImage failed", this, ex);
            }

            return false;
        }

        public virtual bool DeleteAllImage(string listId)
        {
            try
            {
                ContentModeratorRepository.DeleteAllImage(listId);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteAllImage failed", this, ex);
            }

            return false;
        }

        public virtual GetImagesResponse GetAllImageIds(string listId)
        {
            try
            {
                var result = ContentModeratorRepository.GetAllImageIds(listId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetAllImageIds failed", this, ex);
            }

            return null;
        }

        public virtual ListDetails GetImageListDetails(string listId)
        {
            try
            {
                var result = ContentModeratorRepository.GetImageListDetails(listId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetImageListDetails failed", this, ex);
            }

            return null;
        }

        public virtual ListDetails CreateList(ListDetails details)
        {
            try
            {
                var result = ContentModeratorRepository.CreateList(details);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateList failed", this, ex);
            }

            return null;
        }

        public virtual bool DeleteImageList(string listId)
        {
            try
            {
                ContentModeratorRepository.DeleteImageList(listId);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteImageList failed", this, ex);
            }

            return false;
        }

        public virtual List<ListDetails> GetAllImageLists()
        {
            try
            {
                var result = ContentModeratorRepository.GetAllImageLists();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetAllImageLists failed", this, ex);
            }

            return null;
        }

        public virtual RefreshSearchResponse RefreshImageSearchIndex(string listId)
        {
            try
            {
                var result = ContentModeratorRepository.RefreshImageSearchIndex(listId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.RefreshImageSearchIndex failed", this, ex);
            }

            return null;
        }

        public virtual ListDetails UpdateImageListDetails(string listId, ListDetails details)
        {
            try
            {
                var result = ContentModeratorRepository.UpdateImageListDetails(listId, details);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.UpdateImageListDetails failed", this, ex);
            }

            return null;
        }

        public virtual bool AddTerm(string listId, string term, string language)
        {
            try
            {
                ContentModeratorRepository.AddTerm(listId, term, language);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.AddTerm failed", this, ex);
            }

            return false;
        }

        public virtual bool DeleteTerm(string listId, string term, string language)
        {
            try
            {
                ContentModeratorRepository.DeleteTerm(listId, term, language);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteTerm failed", this, ex);
            }

            return false;
        }

        public virtual bool DeleteAllTerms(string listId, string language)
        {
            try
            {
                ContentModeratorRepository.DeleteAllTerms(listId, language);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteAllTerms failed", this, ex);
            }

            return false;
        }

        public virtual GetTermsResponse GetAllTerms(string listId, string language)
        {
            try
            {
                var result = ContentModeratorRepository.GetAllTerms(listId, language);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetAllTerms failed", this, ex);
            }

            return null;
        }

        public virtual ListDetails CreateTermList(ListDetails details)
        {
            try
            {
                var result = ContentModeratorRepository.CreateTermList(details);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateTextList failed", this, ex);
            }

            return null;
        }

        public virtual bool DeleteTermList(string listId)
        {
            try
            {
                ContentModeratorRepository.DeleteTermList(listId);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteTermList failed", this, ex);
            }

            return false;
        }

        public virtual List<ListDetails> GetAllTermLists()
        {
            try
            {
                var result = ContentModeratorRepository.GetAllTermLists();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetAllTermLists failed", this, ex);
            }

            return null;
        }

        public virtual ListDetails GetTermListDetails(string listId)
        {
            try
            {
                var result = ContentModeratorRepository.GetTermListDetails(listId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.GetTermListDetails failed", this, ex);
            }

            return null;
        }

        public virtual RefreshSearchResponse RefreshTermSearchIndex(string listId, string language)
        {
            try
            {
                var result = ContentModeratorRepository.RefreshTermSearchIndex(listId, language);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.RefreshTermSearchIndex failed", this, ex);
            }

            return null;
        }

        public virtual ListDetails UpdateTermListDetails(string listId, ListDetails details)
        {
            try
            {
                var result = ContentModeratorRepository.UpdateTermListDetails(listId, details);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.UpdateTermListDetails failed", this, ex);
            }

            return null;
        }

        #endregion List Management
    }
}