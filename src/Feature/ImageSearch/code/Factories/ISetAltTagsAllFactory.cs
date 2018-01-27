using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface ISetAltTagsAllFactory
    {
        ISetAltTagsAll Create(string itemId, string db, string language, int itemCount, int itemsModified, int threshold, bool overwrite);
    }
}