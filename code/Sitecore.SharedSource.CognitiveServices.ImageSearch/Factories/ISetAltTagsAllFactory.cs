using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Utility;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories
{
    public interface ISetAltTagsAllFactory
    {
        ISetAltTagsAll Create(string itemId, string db, string language, int itemCount, int itemsModified, int threshold, bool overwrite);
    }
}