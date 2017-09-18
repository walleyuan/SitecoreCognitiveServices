using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.WebLanguageModel;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language {
    public interface IWebLanguageModelRepository {
        BreakIntoWordsResponse BreakIntoWords(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5);
        Task<BreakIntoWordsResponse> BreakIntoWordsAsync(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5);
        ConditionalProbabilityResponse CalculateConditionalProbability(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5);
        Task<ConditionalProbabilityResponse> CalculateConditionalProbabilityAsync(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5);
        JointProbabilityResponse CalculateJointProbability(WebLMModelOptions model, JointProbabilityRequest request, int order = 5);
        Task<JointProbabilityResponse> CalculateJointProbabilityAsync(WebLMModelOptions model, JointProbabilityRequest request, int order = 5);
        GenerateNextWordsResponse GenerateNextWords(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5);
        Task<GenerateNextWordsResponse> GenerateNextWordsAsync(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5);
        WebLMModelResponse ListAvailableModels();
        Task<WebLMModelResponse> ListAvailableModelsAsync();
    }
}