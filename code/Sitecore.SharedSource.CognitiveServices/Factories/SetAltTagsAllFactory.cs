using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class SetAltTagsAllFactory : ISetAltTagsAllFactory
    {
        public ISetAltTagsAll Create()
        {
            return new SetAltTagsAll()
            {
                ItemCount = 0,
                ItemsModified = 0,
                Database = string.Empty,
                Language = string.Empty,
                ItemId = string.Empty
            };
        }

        public ISetAltTagsAll Create(int itemCount, int itemsModified, string db, string language, string itemId)
        {
            return new SetAltTagsAll()
            {
                ItemCount = itemCount,
                ItemsModified = itemsModified,
                Database = db,
                Language = language,
                ItemId = itemId
            };
        }
    }
}