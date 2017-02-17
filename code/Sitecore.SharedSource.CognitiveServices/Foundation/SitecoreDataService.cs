using System;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class SitecoreDataService : ISitecoreDataService
    {
        public Database GetDatabase(string dbName) => Sitecore.Configuration.Factory.GetDatabase(dbName);
        public ID GetID(string itemId)
        {
            ID idObj;
            return (ID.TryParse(itemId, out idObj))
                ? idObj
                : ID.Null;
        }

        public Item GetItemByUri(string itemUri)
        {
            //item uri format: sitecore://master/{04dad0fd-db66-4070-881f-17264ca257e1}?lang=en&ver=1
            string[] parts = itemUri
                .Replace("sitecore://", string.Empty)
                .Split(new [] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 1)
                return null;

            if (parts.Length < 2)
                return null;

            var guidParts = parts[1].Split(new [] { "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (guidParts.Length < 1)
                return null;
            
            return GetDatabase(parts[0]).GetItem(GetID(guidParts[0]));
        }

        public Item GetItemByIdValue(string itemId, string database)
        {
            ID id = GetID(itemId);
            return id.IsNull ? null : GetDatabase(database)?.GetItem(id);
        }

        /// <summary>
        /// Checks if both in the media library and not a folder
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsMediaItem(Item i)
        {
            return i.Paths.IsMediaItem && !i.Template.ID.Guid.Equals(TemplateIDs.MediaFolder.Guid);
        }

        public bool IsMediaFolder(Item i)
        {
            return i.Template.ID.Guid.Equals(TemplateIDs.MediaFolder.Guid) || i.ID.Guid.Equals(ItemIDs.MediaLibraryRoot.Guid) || i.TemplateID.Guid.Equals(TemplateIDs.Node);
        }

        public Item ExtractItem(CommandContext context)
        {
            if (context == null)
                return null;

            if (!context.Items.Any())
                return null;

            return context.Items[0];
        }

        public string GetFieldDimension(Item i, string fieldName, int minimum, int offset)
        {
            if (i.Fields[fieldName] == null)
                return minimum.ToString();

            int size = minimum;
            if (!int.TryParse(i[fieldName], out size))
                return minimum.ToString();

            return (size > minimum)
                ? (size + offset).ToString()
                : minimum.ToString();
        }
    }
}