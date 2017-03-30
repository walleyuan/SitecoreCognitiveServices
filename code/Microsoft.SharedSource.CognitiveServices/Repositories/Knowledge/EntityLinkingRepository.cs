using Microsoft.ProjectOxford.EntityLinking;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge
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
