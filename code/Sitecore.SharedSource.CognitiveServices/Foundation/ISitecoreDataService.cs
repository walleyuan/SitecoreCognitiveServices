using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public interface ISitecoreDataService
    {
        Database GetDatabase(string dbName);
        ID GetID(string itemId);
        Item GetItemByUri(string itemUri);
        Item GetItemByIdValue(string itemId, string database);
        bool IsMediaItem(Item i);
        Item ExtractItem(CommandContext context);
    }
}