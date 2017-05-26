using System;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge;

namespace Sitecore.SharedSource.CognitiveServices.Services.Knowledge
{
    public class EntityLinkingService : IEntityLinkingService
    {
        protected IEntityLinkingRepository EntityLinkingRepository;
        protected ILogWrapper Logger;

        public EntityLinkingService(
            IEntityLinkingRepository entityLinkingRepository,
            ILogWrapper logger) 
        {
            EntityLinkingRepository = entityLinkingRepository;
            Logger = logger;
        }

        public virtual EntityLink[] Link(string text, string selection = "", int offset = 0) {
            try {
                var result = Task.Run(async () => await EntityLinkingRepository.LinkAsync(text, selection, offset)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("EntityLinkingService.Link failed", this, ex);
            }

            return null;
        }
    }
}