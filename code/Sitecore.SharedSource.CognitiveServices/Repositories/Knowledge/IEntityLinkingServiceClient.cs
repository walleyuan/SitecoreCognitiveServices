using System.Threading.Tasks;
using Microsoft.ProjectOxford.EntityLinking.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge
{
    /// <summary>
    /// Stubs out the internal interface that Microsoft.ProjectOxford.EntityLinking.EntityLinkingServiceClient implements
    /// </summary>
    public interface IEntityLinkingServiceClient
    {
        Task<EntityLink[]> LinkAsync(string text, string selection = "", int offset = 0);
    }
}
