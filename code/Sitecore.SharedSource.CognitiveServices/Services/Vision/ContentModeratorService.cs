using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Vision;
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

        public virtual ContentModeratorEvaluateResponse Evaluate(string imageUrl)
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

        public virtual ContentModeratorEvaluateResponse Evaluate(Stream stream)
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

        public virtual ContentModeratorFindFacesResponse FindFaces(string imageUrl)
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

        public virtual ContentModeratorFindFacesResponse FindFaces(Stream stream)
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

        public virtual ContentModeratorMatchResponse Match(string imageUrl, string listId = "")
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

        public virtual ContentModeratorMatchResponse Match(Stream stream, string listId = "")
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

        public virtual ContentModeratorOCRResult OCR(string imageUrl, string language = "", bool enhanced = false)
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

        public virtual ContentModeratorOCRResult OCR(Stream stream, string language = "", bool enhanced = false)
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

        public virtual ContentModeratorDetectLanguageResponse DetectLanguage(string text)
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

        public virtual ContentModeratorScreenResponse Screen(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "")
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
    }
}