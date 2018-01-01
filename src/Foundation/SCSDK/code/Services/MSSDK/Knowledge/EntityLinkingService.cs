using System;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.EntityLinking;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge
{
    public class EntityLinkingService : IEntityLinkingService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IEntityLinkingRepository EntityLinkingRepository;
        protected readonly ILogWrapper Logger;

        public EntityLinkingService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IEntityLinkingRepository entityLinkingRepository,
            ILogWrapper logger) 
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            EntityLinkingRepository = entityLinkingRepository;
            Logger = logger;
        }

        public virtual EntityLink[] Link(string text, string selection = "", int offset = 0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "EntityLinkingService.Link",
                ApiKeys.EntityLinkingRetryInSeconds,
                () =>
                {
                    var result = EntityLinkingRepository.Link(text, selection, offset);
                    return result;
                },
                null);
        }
    }
}