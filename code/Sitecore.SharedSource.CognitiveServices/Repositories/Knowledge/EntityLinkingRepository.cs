using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
