using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;
using Sitecore.SharedSource.CognitiveServices.Repositories.Vision;

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
                var result = Task.Run(async () => await ContentModeratorRepository.EvaluateAsync(imageUrl)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.EvaluateAsync(stream)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.FindFacesAsync(imageUrl)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.FindFacesAsync(stream)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.MatchAsync(imageUrl)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.MatchAsync(stream, listId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.OCRAsync(imageUrl, language, enhanced)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.OCRAsync(stream, language, enhanced)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.DetectLanguageAsync(text)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.ScreenAsync(text, language, autocorrect, urls, PII, listId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.CreateImageJobAsync(imageUrl, teamName, contentId, workflowName, callbackEndpoint)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.CreateImageJobAsync(stream, teamName, contentId, workflowName, callbackEndpoint)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.CreateTextJobAsync(text, teamName, contentId, workflowName, callbackEndpoint)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.GetJobAsync(teamName, jobId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.CreateReviewAsync(teamName, requests, subTeam)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.GetReviewAsync(teamName, reviewId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.CreateOrUpdateWorkflowAsync(teamName, workflowName, expression)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.GetWorkflowAsync(teamName, workflowName)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.GetAllWorkflowsAsync(teamName)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.AddImageAsync(imageUrl, listId, tag, label)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.AddImageAsync(stream, listId, tag, label)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.AddImage failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteImage(string listId, string imageId)
        {
            try
            {
                Task.Run(async () => await ContentModeratorRepository.DeleteImageAsync(listId, imageId));
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteImage failed", this, ex);
            }
        }

        public virtual void DeleteAllImage(string listId)
        {
            try
            {
                Task.Run(async () => await ContentModeratorRepository.DeleteAllImageAsync(listId));
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteAllImage failed", this, ex);
            }
        }

        public virtual GetImagesResponse GetAllImageIds(string listId)
        {
            try
            {
                var result = Task.Run(async () => await ContentModeratorRepository.GetAllImageIdsAsync(listId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.GetImageListDetailsAsync(listId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.CreateListAsync(details)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateList failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteImageList(string listId)
        {
            try
            {
                Task.Run(async () => await ContentModeratorRepository.DeleteImageListAsync(listId));
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteImageList failed", this, ex);
            }
        }

        public virtual List<ListDetails> GetAllImageLists()
        {
            try
            {
                var result = Task.Run(async () => await ContentModeratorRepository.GetAllImageListsAsync()).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.RefreshImageSearchIndexAsync(listId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.UpdateImageListDetailsAsync(listId, details)).Result;

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
                Task.Run(async () => await ContentModeratorRepository.AddTermAsync(listId, term, language));

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.AddTerm failed", this, ex);
            }

            return false;
        }

        public virtual void DeleteTerm(string listId, string term, string language)
        {
            try
            {
                Task.Run(async () => await ContentModeratorRepository.DeleteTermAsync(listId, term, language));
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteTerm failed", this, ex);
            }
        }

        public virtual void DeleteAllTerms(string listId, string language)
        {
            try
            {
                Task.Run(async () => await ContentModeratorRepository.DeleteAllTermsAsync(listId, language));
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteAllTerms failed", this, ex);
            }
        }

        public virtual GetTermsResponse GetAllTerms(string listId, string language)
        {
            try
            {
                var result = Task.Run(async () => await ContentModeratorRepository.GetAllTermsAsync(listId, language)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.CreateTermListAsync(details)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateTextList failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteTermList(string listId)
        {
            try
            {
                Task.Run(async () => await ContentModeratorRepository.DeleteTermListAsync(listId));
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.DeleteTermList failed", this, ex);
            }
        }

        public virtual List<ListDetails> GetAllTermLists()
        {
            try
            {
                var result = Task.Run(async () => await ContentModeratorRepository.GetAllTermListsAsync()).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.GetTermListDetailsAsync(listId)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.RefreshTermSearchIndexAsync(listId, language)).Result;

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
                var result = Task.Run(async () => await ContentModeratorRepository.UpdateTermListDetailsAsync(listId, details)).Result;

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