
using Microsoft.SharedSource.CognitiveServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language
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
