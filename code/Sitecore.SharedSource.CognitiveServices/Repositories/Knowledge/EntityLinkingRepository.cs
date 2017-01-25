using Microsoft.ProjectOxford.EntityLinking;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge
{
    public class EntityLinkingRepository : EntityLinkingServiceClient, IEntityLinkingRepository
    {
        public EntityLinkingRepository(
            IApiKeys apiKeys)
            : base(apiKeys.EntityLinking)
        {
        }
    }
}
