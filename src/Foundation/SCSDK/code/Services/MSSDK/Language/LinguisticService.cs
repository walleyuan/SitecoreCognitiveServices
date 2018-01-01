using System;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language
{
    public class LinguisticService : ILinguisticService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ILinguisticRepository LinguisticRepository;
        protected readonly ILogWrapper Logger;

        public LinguisticService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ILinguisticRepository linguisticRepository,
            ILogWrapper logger) 
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            LinguisticRepository = linguisticRepository;
            Logger = logger;
        }

        public virtual POSTagsTextAnalysisResponse GetPOSTagsTextAnalysis(TextAnalysisRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LinguisticService.GetPOSTagsTextAnalysis",
                ApiKeys.LinguisticAnalysisRetryInSeconds,
                () =>
                {
                    var result = LinguisticRepository.GetPOSTagsTextAnalysis(request);
                    return result;
                },
                null);
        }

        public virtual ConstituencyTreeTextAnalysisResponse GetConstituencyTreeTextAnalysis(TextAnalysisRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LinguisticService.GetConstituencyTreeTextAnalysis",
                ApiKeys.LinguisticAnalysisRetryInSeconds,
                () =>
                {
                    var result = LinguisticRepository.GetConstituencyTreeTextAnalysis(request);
                    return result;
                },
                null);
        }

        public virtual TokensTextAnalysisResponse GetTokensTextAnalysis(TextAnalysisRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LinguisticService.GetTokensTextAnalysis",
                ApiKeys.LinguisticAnalysisRetryInSeconds,
                () =>
                {
                    var result = LinguisticRepository.GetTokensTextAnalysis(request);
                    return result;
                },
                null);
        }
    }
}