using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public interface ISitecoreDataService
    {
        Database GetDatabase(string dbName);
        ID GetID(string itemId);
        Item GetItemByUri(string itemUri);
        bool IsMediaItem(Item i);
    }
}