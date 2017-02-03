using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ISetAltTagsAllFactory
    {
        ISetAltTagsAll Create();

        ISetAltTagsAll Create(int itemCount, int itemsModified, string db, string language, string itemId);
    }
}