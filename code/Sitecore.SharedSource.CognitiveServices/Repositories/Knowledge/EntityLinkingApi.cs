using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.EntityLinking;

namespace Sitecore.SharedSource.CognitiveServices.Repository.Knowledge
{
    public class EntityLinkingApi : EntityLinkingServiceClient, IEntityLinkingApi
    {
        public EntityLinkingApi(
            IApiKeys apiKeys)
            : base(apiKeys.EntityLinking)
        {
        }
    }
}
