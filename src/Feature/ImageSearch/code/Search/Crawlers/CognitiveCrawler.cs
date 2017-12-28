using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Diagnostics;
using Sitecore.Data.Items;
using Sitecore.Data.LanguageFallback;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.Globalization;
using System;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.Crawlers
{
    public class CognitiveCrawler : SitecoreItemCrawler
    {
        private IIndexable GetIndexable(Item item)
        {
            return item.Language.Name == GetLanguage() 
                ? new CognitiveIndexableImageItem(item) 
                : new SitecoreIndexableItem(item);
        }

        private static string GetLanguage()
        {
            return Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.Language", "en");
        }

        protected override void UpdateItemVersion(IProviderUpdateContext context, Item version, IndexEntryOperationContext operationContext)
        {
            IIndexable indexableItem = GetIndexable(version);

            this.Operations.Update((IIndexable)indexableItem, context, context.Index.Configuration);
            this.UpdateLanguageFallbackDependentItems(context, (SitecoreIndexableItem)indexableItem, operationContext);
        }

        protected override void DoAdd(IProviderUpdateContext context, SitecoreIndexableItem indexable)
        {
            Assert.ArgumentNotNull(context, "context");
            Assert.ArgumentNotNull(indexable, "indexable");
            using (new LanguageFallbackItemSwitcher(context.Index.EnableItemLanguageFallback))
            {
                Event.RaiseEvent("indexing:adding", context.Index.Name, indexable.UniqueId, indexable.AbsolutePath);

                if (!this.IsExcludedFromIndex(indexable, false))
                {
                    foreach (Language language in indexable.Item.Languages)
                    {
                        if (language.Name != "en")
                            continue;
                        
                        Item obj1;
                        using (new WriteCachesDisabler())
                            obj1 = indexable.Item.Database.GetItem(indexable.Item.ID, language, Sitecore.Data.Version.Latest);
                        if (obj1 == null)
                        { 
                            CrawlingLog.Log.Warn($"SitecoreItemCrawler : AddItem : Could not build document data {indexable.Item.Uri} - Latest version could not be found. Skipping.");
                            return;
                        }

                        Item[] objArray1;
                        using (new WriteCachesDisabler())
                        {
                            Item[] objArray2;
                            if (obj1.IsFallback)
                                objArray2 = new Item[1] { obj1 };
                            else
                                objArray2 = obj1.Versions.GetVersions(false);
                            objArray1 = objArray2;
                        }
                        foreach (Item obj2 in objArray1)
                        {
                            IIndexable indexableItem = GetIndexable(indexable);

                            SitecoreIndexableItem sitecoreIndexableItem1 = (SitecoreIndexableItem)obj2;
                            SitecoreIndexableItem sitecoreIndexableItem2 = sitecoreIndexableItem1;
                            int num = ((IIndexableBuiltinFields)sitecoreIndexableItem2).Version == obj1.Version.Number ? 1 : 0;
                            ((IIndexableBuiltinFields)sitecoreIndexableItem2).IsLatestVersion = num != 0;
                            sitecoreIndexableItem1.IndexFieldStorageValueFormatter = context.Index.Configuration.IndexFieldStorageValueFormatter;
                            this.Operations.Add((IIndexable)indexableItem, context, this.index.Configuration);
                        }
                    }
                }

                Event.RaiseEvent(
                    "indexing:added", 
                    context.Index.Name, 
                    indexable.UniqueId, 
                    indexable.AbsolutePath);
            }
        }
    }
}