using System;
using System.Threading.Tasks;
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
                var result = Task.Run(async () => await WebLanguageModelRepository.BreakIntoWordsAsync(model, text, order, maxNumOfCandidatesReturned)).Result;

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
                var result = Task.Run(async () => await WebLanguageModelRepository.CalculateConditionalProbabilityAsync(model, request, order)).Result;

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
                var result = Task.Run(async () => await WebLanguageModelRepository.CalculateJointProbabilityAsync(model, request, order)).Result;

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
                var result = Task.Run(async () => await WebLanguageModelRepository.GenerateNextWordsAsync(model, words, order, maxNumOfCandidatesReturned)).Result;

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
                var result = Task.Run(async () => await WebLanguageModelRepository.ListAvailableModelsAsync()).Result;

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