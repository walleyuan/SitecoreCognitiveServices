using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Sites;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields
{
    public abstract class BaseComputedField : IComputedIndexField
    {
        public virtual string FieldName { get; set; }
        public virtual string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, "indexable");

            Item indexItem = indexable as SitecoreIndexableItem;
            if (indexItem == null)
                return false;

            if (indexItem?.Database?.Name == "core")
                return false;

            if (indexItem.TemplateID == TemplateIDs.MediaFolder || indexItem.ID == ItemIDs.MediaLibraryRoot)
                return false;

            //if (!indexItem.Paths.IsContentItem)
            //    return false;
            
            try {
                return GetFieldValue(indexItem);
            } catch (Exception e) {
                Log.Error($"Error indexing field: {FieldName}, Item Path: {indexItem.Paths.FullPath}", e, GetType());
            }

            return false;
        }

        protected virtual object GetFieldValue(Item indexItem)
        {
            return string.Empty;
        }
    }
}