using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Wrappers
{
    public interface ISitecoreDataWrapper
    {
        Database GetDatabase(string dbName);
        List<Database> GetDatabases();
        ID GetID(string itemId);
        Item GetItemByUri(string itemUri);
        Item GetItemByIdValue(string itemId, string database);
        bool IsMediaFile(Item i);
        bool IsMediaFolder(Item i);
        IEnumerable<MediaItem> GetMediaFileDescendents(string id, string db);
        Item ExtractItem(CommandContext context);
        string GetFieldDimension(Item i, string fieldName, int minimum, int offset);
        IEnumerable<TemplateItem> GetBaseTemplates(Item i);
        IEnumerable<TemplateItem> GetBaseTemplates(TemplateItem t);
        void SetImageDescription(MediaItem mediaItem, string altDescription);
    }
}