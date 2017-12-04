
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language
{
    public interface ILinguisticService
    {
        POSTagsTextAnalysisResponse GetPOSTagsTextAnalysis(TextAnalysisRequest request);
        ConstituencyTreeTextAnalysisResponse GetConstituencyTreeTextAnalysis(TextAnalysisRequest request);
        TokensTextAnalysisResponse GetTokensTextAnalysis(TextAnalysisRequest request);
    }
}