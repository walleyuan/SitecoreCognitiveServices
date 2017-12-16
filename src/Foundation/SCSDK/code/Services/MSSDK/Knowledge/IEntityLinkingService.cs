using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.EntityLinking;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge
{
    public interface IEntityLinkingService
    {
        EntityLink[] Link(string text, string selection = "", int offset = 0);
    }
}