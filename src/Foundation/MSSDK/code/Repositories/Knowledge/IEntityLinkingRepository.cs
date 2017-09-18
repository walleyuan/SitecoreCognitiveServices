
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.EntityLinking;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Knowledge
{
    public interface IEntityLinkingRepository
    {
        EntityLink[] Link(string text, string selection = "", int offset = 0);
        Task<EntityLink[]> LinkAsync(string text, string selection = "", int offset = 0);
    }
}
