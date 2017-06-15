
using System.Threading.Tasks;
using Microsoft.ProjectOxford.EntityLinking.Contract;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge
{
    public interface IEntityLinkingRepository
    {
        /// <summary>
        /// Stubs out the internal interface that Microsoft.ProjectOxford.EntityLinking.EntityLinkingServiceClient implements
        /// </summary>
        EntityLink[] Link(string text, string selection = "", int offset = 0);
        Task<EntityLink[]> LinkAsync(string text, string selection = "", int offset = 0);
    }
}
