
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.EntityLinking;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge
{
    public interface IEntityLinkingRepository
    {
        EntityLink[] Link(string text, string selection = "", int offset = 0);
        Task<EntityLink[]> LinkAsync(string text, string selection = "", int offset = 0);
    }
}
