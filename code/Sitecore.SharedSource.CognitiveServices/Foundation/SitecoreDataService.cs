using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
        public bool IsMediaFile(Item i)
        {
            var bases = GetBaseTemplates(i).ToList();

            return bases
                .Any(a => 
                    a.ID.Guid.Equals(TemplateIDs.UnversionedFile.Guid) 
                    || a.ID.Guid.Equals(TemplateIDs.VersionedFile.Guid));
        }

        public bool IsMediaFolder(Item i)
        {
            return i.ID.Guid.Equals(Sitecore.ItemIDs.MediaLibraryRoot.Guid) || (i.Paths.IsMediaItem && !IsMediaFile(i));
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

        public IEnumerable<TemplateItem> GetBaseTemplates(Item i) {
            return i.Template.BaseTemplates.SelectMany(a => GetBaseTemplates(a));
        }

        public IEnumerable<TemplateItem> GetBaseTemplates(TemplateItem t) {

            if (t.ID.Guid.Equals(TemplateIDs.StandardTemplate.Guid))
                return new TemplateItem[0];

            return new[] { t }
                    .Concat(t.BaseTemplates.SelectMany(a => GetBaseTemplates(a)));
        }
    }
}