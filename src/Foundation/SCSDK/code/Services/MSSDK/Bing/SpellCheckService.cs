using System;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Bing;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Bing.SpellCheck;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing
{
    public class SpellCheckService : ISpellCheckService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ISpellCheckRepository SpellCheckRepository;
        protected readonly ILogWrapper Logger;

        public SpellCheckService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ISpellCheckRepository spellCheckRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            SpellCheckRepository = spellCheckRepository;
            Logger = logger;
        }

        public virtual SpellCheckResponse SpellCheck(string text, SpellCheckModeOptions mode = SpellCheckModeOptions.None, string languageCode = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "SpellCheckService.SpellCheck",
                ApiKeys.BingSpellCheckRetryInSeconds,
                () =>
                {
                    var result = SpellCheckRepository.SpellCheck(text, mode, languageCode);
                    return result;
                },
                null);
        }
    }
}