using System;
using System.Linq;
using System.Collections.Generic;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel;
using Sitecore.Shell.Framework.Commands;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
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

    public class SitecoreDataWrapper : ISitecoreDataWrapper
    {
        protected readonly ILogWrapper Logger;

        public SitecoreDataWrapper(ILogWrapper logger)
        {
            Logger = logger;
        }

        public virtual Database GetDatabase(string dbName) => Sitecore.Configuration.Factory.GetDatabase(dbName);
        public virtual List<Database> GetDatabases() => Sitecore.Configuration.Factory.GetDatabases();
        public virtual ID GetID(string itemId)
        {
            ID idObj;
            return (ID.TryParse(itemId, out idObj))
                ? idObj
                : ID.Null;
        }

        public virtual Item GetItemByUri(string itemUri)
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

        public virtual Item GetItemByIdValue(string itemId, string database)
        {
            ID id = GetID(itemId);
            return id.IsNull ? null : GetDatabase(database)?.GetItem(id);
        }

        /// <summary>
        /// Checks if both in the media library and not a folder
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public virtual bool IsMediaFile(Item i)
        {
            var bases = GetBaseTemplates(i).ToList();

            return bases
                .Any(a => 
                    a.ID.Guid.Equals(TemplateIDs.UnversionedFile.Guid) 
                    || a.ID.Guid.Equals(TemplateIDs.VersionedFile.Guid));
        }

        public virtual bool IsMediaFolder(Item i)
        {
            return i.ID.Guid.Equals(Sitecore.ItemIDs.MediaLibraryRoot.Guid) || (i.Paths.IsMediaItem && !IsMediaFile(i));
        }

        public virtual IEnumerable<MediaItem> GetMediaFileDescendents(string id, string db) {

            Item item = GetItemByIdValue(id, db);
            if (item == null)
                return new MediaItem[0];

            return item
                .Axes
                .GetDescendants()
                .Where(IsMediaFile)
                .Select(a => new MediaItem(a))
                .ToList();
        }

        public virtual Item ExtractItem(CommandContext context)
        {
            if (context == null)
                return null;

            if (!context.Items.Any())
                return null;

            return context.Items[0];
        }

        public virtual string GetFieldDimension(Item i, string fieldName, int minimum, int offset)
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

        public virtual IEnumerable<TemplateItem> GetBaseTemplates(Item i) {
            return i.Template.BaseTemplates.SelectMany(a => GetBaseTemplates(a));
        }

        public virtual IEnumerable<TemplateItem> GetBaseTemplates(TemplateItem t) {

            if (t.ID.Guid.Equals(TemplateIDs.StandardTemplate.Guid))
                return new TemplateItem[0];

            return new[] { t }
                    .Concat(t.BaseTemplates.SelectMany(a => GetBaseTemplates(a)));
        }

        public virtual void SetImageDescription(MediaItem mediaItem, string altDescription) {
            Assert.IsNotNull(mediaItem, GetType());

            using (new SecurityDisabler()) {
                using (new EditContext(mediaItem)) {
                    try {
                        mediaItem.Alt = altDescription;
                    } catch (Exception ex) {
                        Logger.Error("Set Image Description: " + ex.Message, this, ex);
                    }
                }
            }
        }
    }
}