using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.ContentSearch.Diagnostics;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields
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
                return null;

            if (indexItem?.Database?.Name == "core")
                return null;

            if (indexItem.TemplateID == TemplateIDs.MediaFolder || indexItem.ID == ItemIDs.MediaLibraryRoot)
                return null;
            
            try {

                CognitiveIndexableImageItem cognitiveIndexable;
                try
                {
                    cognitiveIndexable = (CognitiveIndexableImageItem)indexable;
                }
                catch (Exception ex)
                {
                    CrawlingLog.Log.Warn("Unable to convert indexable to CognitiveIndexableItem. Id: " + indexable.UniqueId + ", Message: " + ex.Message);
                    return null;
                }
                return GetFieldValue(cognitiveIndexable);
            } catch (Exception e) {
                Log.Error($"Error indexing field: {FieldName}, Item Path: {indexItem.Paths.FullPath}", e, GetType());
            }

            return null;
        }

        protected virtual object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            return null;
        }

        protected void LogError(Exception ex, Item indexItem)
        {
            Exception exception = ex.InnerException as Exception;

            if (exception != null)
                Log.Error($"ImageItemAnalysis failed to index {indexItem.Paths.Path}: {exception.Message}", exception, GetType());
            else
                Log.Error(ex.Message, ex, GetType());
        }
    }
}