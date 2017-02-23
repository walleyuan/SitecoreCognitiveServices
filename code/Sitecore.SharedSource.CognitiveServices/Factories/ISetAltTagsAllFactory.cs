using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Utility;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ISetAltTagsAllFactory
    {
        ISetAltTagsAll Create(string itemId, string db, string language, int itemCount, int itemsModified, int threshold, bool overwrite);
    }
}