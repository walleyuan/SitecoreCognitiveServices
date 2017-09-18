using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.WebLanguageModel;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Language
{
    public interface IWebLanguageModelService
    {
        BreakIntoWordsResponse BreakIntoWords(WebLMModelOptions model, string text, int order = 5, int maxNumOfCandidatesReturned = 5);
        ConditionalProbabilityResponse CalculateConditionalProbability(WebLMModelOptions model, ConditionalProbabilityRequest request, int order = 5);
        JointProbabilityResponse CalculateJointProbability(WebLMModelOptions model, JointProbabilityRequest request, int order = 5);
        GenerateNextWordsResponse GenerateNextWords(WebLMModelOptions model, string words, int order = 5, int maxNumOfCandidatesReturned = 5);
        WebLMModelResponse ListAvailableModels();
    }
}