using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class SetAltTagsAllFactory : ISetAltTagsAllFactory
    {
        public ISetAltTagsAll Create(string itemId, string db, string language, int itemCount, int itemsModified, int threshold, bool overwrite)
        {
            return new SetAltTagsAll()
            {
                ItemId = itemId,
                Database = db,
                Language = language,
                ItemCount = itemCount,
                ItemsModified = itemsModified,
                Threshold = threshold,
                Overwrite = overwrite
            };
        }
    }
}