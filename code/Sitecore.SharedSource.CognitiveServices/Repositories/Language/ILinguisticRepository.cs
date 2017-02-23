
using Sitecore.SharedSource.CognitiveServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Models.Language;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
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
