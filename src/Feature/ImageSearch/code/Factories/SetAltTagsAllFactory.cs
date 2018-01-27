using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public class SetAltTagsAllFactory : ISetAltTagsAllFactory
    {
        protected readonly IServiceProvider Provider;

        public SetAltTagsAllFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual ISetAltTagsAll Create(string itemId, string db, string language, int itemCount, int itemsModified, int threshold, bool overwrite)
        {
            var obj = Provider.GetService<ISetAltTagsAll>();

            obj.ItemId = itemId;
            obj.Database = db;
            obj.Language = language;
            obj.ItemCount = itemCount;
            obj.ItemsModified = itemsModified;
            obj.Threshold = threshold;
            obj.Overwrite = overwrite;

            return obj;
        }
    }
}