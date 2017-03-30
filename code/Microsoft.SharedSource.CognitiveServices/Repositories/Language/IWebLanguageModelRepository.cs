using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.WebLanguageModel;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language {
    public interface IWebLanguageModelRepository {
        Task<BreakIntoWordsResponse> BreakIntoWordsAsync(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5);
        Task<ConditionalProbabilityResponse> CalculateConditionalProbabilityAsync(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5);
        Task<JointProbabilityResponse> CalculateJointProbabilityAsync(WebLMModelOptions model, JointProbabilityRequest request, int order = 5);
        Task<GenerateNextWordsResponse> GenerateNextWordsAsync(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5);
        Task<WebLMModelResponse> ListAvailableModelsAsync();
    }
}