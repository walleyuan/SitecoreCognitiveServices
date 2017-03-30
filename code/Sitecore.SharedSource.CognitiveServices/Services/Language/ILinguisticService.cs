
using Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public interface ILinguisticService
    {
        POSTagsTextAnalysisResponse GetPOSTagsTextAnalysis(TextAnalysisRequest request);
        ConstituencyTreeTextAnalysisResponse GetConstituencyTreeTextAnalysis(TextAnalysisRequest request);
        TokensTextAnalysisResponse GetTokensTextAnalysis(TextAnalysisRequest request);
    }
}