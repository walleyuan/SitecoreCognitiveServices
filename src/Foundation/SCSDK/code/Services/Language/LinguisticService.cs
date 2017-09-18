using System;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Language
{
    public class LinguisticService : ILinguisticService
    {
        protected ILinguisticRepository LinguisticRepository;
        protected ILogWrapper Logger;

        public LinguisticService(
            ILinguisticRepository linguisticRepository,
            ILogWrapper logger) 
        {
            LinguisticRepository = linguisticRepository;
            Logger = logger;
        }

        public virtual POSTagsTextAnalysisResponse GetPOSTagsTextAnalysis(TextAnalysisRequest request)
        {
            try {
                var result = LinguisticRepository.GetPOSTagsTextAnalysis(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LinguisticService.GetPOSTagsTextAnalysis failed", this, ex);
            }

            return null;
        }

        public virtual ConstituencyTreeTextAnalysisResponse GetConstituencyTreeTextAnalysis(TextAnalysisRequest request) {
            try {
                var result = LinguisticRepository.GetConstituencyTreeTextAnalysis(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LinguisticService.GetConstituencyTreeTextAnalysis failed", this, ex);
            }

            return null;
        }

        public virtual TokensTextAnalysisResponse GetTokensTextAnalysis(TextAnalysisRequest request) {
            try {
                var result = LinguisticRepository.GetTokensTextAnalysis(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LinguisticService.GetTokensTextAnalysis failed", this, ex);
            }

            return null;
        }
    }
}