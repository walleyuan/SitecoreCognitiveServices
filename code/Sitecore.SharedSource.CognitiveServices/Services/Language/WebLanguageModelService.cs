using System;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.WebLanguageModel;
using Microsoft.SharedSource.CognitiveServices.Repositories.Language;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public class WebLanguageModelService : IWebLanguageModelService
    {
        protected IWebLanguageModelRepository WebLanguageModelRepository;
        protected ILogWrapper Logger;

        public WebLanguageModelService(
            IWebLanguageModelRepository webLanguageModelRepository,
            ILogWrapper logger)
        {
            WebLanguageModelRepository = webLanguageModelRepository;
            Logger = logger;
        }

        public virtual BreakIntoWordsResponse BreakIntoWords(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            try
            {
                var result = WebLanguageModelRepository.BreakIntoWords(model, text, order, maxNumOfCandidatesReturned);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("WebLanguageModelService.BreakIntoWords failed", this, ex);
            }

            return null;
        }

        public virtual ConditionalProbabilityResponse CalculateConditionalProbability(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5)
        {
            try
            {
                var result = WebLanguageModelRepository.CalculateConditionalProbability(model, request, order);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("WebLanguageModelService.CalculateConditionalProbability failed", this, ex);
            }

            return null;
        }

        public virtual JointProbabilityResponse CalculateJointProbability(WebLMModelOptions model, JointProbabilityRequest request, int order = 5)
        {
            try
            {
                var result = WebLanguageModelRepository.CalculateJointProbability(model, request, order);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("WebLanguageModelService.CalculateJointProbability failed", this, ex);
            }

            return null;
        }

        public virtual GenerateNextWordsResponse GenerateNextWords(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5)
        {
            try
            {
                var result = WebLanguageModelRepository.GenerateNextWords(model, words, order, maxNumOfCandidatesReturned);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("WebLanguageModelService.GenerateNextWords failed", this, ex);
            }

            return null;
        }

        public virtual WebLMModelResponse ListAvailableModels()
        {
            try
            {
                var result = WebLanguageModelRepository.ListAvailableModels();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("WebLanguageModelService.ListAvailableModels failed", this, ex);
            }

            return null;
        }
    }
}