
using SitecoreCognitiveServices.Foundation.MSSDK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language
{
    public interface ILinguisticRepository
    {
        POSTagsTextAnalysisResponse GetPOSTagsTextAnalysis(TextAnalysisRequest request);
        Task<POSTagsTextAnalysisResponse> GetPOSTagsTextAnalysisAsync(TextAnalysisRequest request);
        ConstituencyTreeTextAnalysisResponse GetConstituencyTreeTextAnalysis(TextAnalysisRequest request);
        Task<ConstituencyTreeTextAnalysisResponse> GetConstituencyTreeTextAnalysisAsync(TextAnalysisRequest request);
        TokensTextAnalysisResponse GetTokensTextAnalysis(TextAnalysisRequest request);
        Task<TokensTextAnalysisResponse> GetTokensTextAnalysisAsync(TextAnalysisRequest request);
    }
}
