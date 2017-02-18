
using Microsoft.ProjectOxford.EntityLinking.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Services.Knowledge
{
    public interface IEntityLinkingService
    {
        EntityLink[] Link(string text, string selection = "", int offset = 0);
    }
}