using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        public virtual void CreateOrUpdateWorkflow(string teamName, string workflowName, WorkflowExpression expression)
        {
            try
            {
                Task.Run(async () => await ContentModeratorRepository.CreateOrUpdateWorkflowAsync(teamName, workflowName, expression));
            }
            catch (Exception ex)
            {
                Logger.Error("ContentModeratorService.CreateOrUpdateWorkflow failed", this, ex);
            }
        }

        public virtual WorkflowExpression GetWorkflow(string teamName, string workflowName)
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

        public virtual List<WorkflowExpression> GetAllWorkflows(string teamName)
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
    }
}