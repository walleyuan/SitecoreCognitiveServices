using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Language;
using Sitecore.SharedSource.CognitiveServices.Models.Language.WebLanguageModel;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language {
    public interface IWebLanguageModelRepository {
        Task<BreakIntoWordsResponse> BreakIntoWordsAsync(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5);
        Task<ConditionalProbabilityResponse> CalculateConditionalProbabilityAsync(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5);
        Task<JointProbabilityResponse> CalculateJointProbabilityAsync(WebLMModelOptions model, JointProbabilityRequest request, int order = 5);
        Task<GenerateNextWordsResponse> GenerateNextWordsAsync(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5);
        Task<WebLMModelResponse> ListAvailableModelsAsync();
    }
}