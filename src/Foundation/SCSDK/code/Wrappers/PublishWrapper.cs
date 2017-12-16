using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Publishing;
using Sitecore.Globalization;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IPublishWrapper
    {
        Handle PublishItem(Item item, Database[] targets, Language[] languages, bool deep, bool compareRevisions);
        List<string> GetPublishingTargets(string dbName);
    }

    public class PublishWrapper : IPublishWrapper
    {
        protected readonly ISitecoreDataWrapper DataWrapper;

        public PublishWrapper(ISitecoreDataWrapper dataWrapper)
        {
            DataWrapper = dataWrapper;
        }

        public Handle PublishItem(Item item, Database[] targets, Language[] languages, bool deep, bool compareRevisions) {
            return PublishManager.PublishItem(item, targets, languages, deep, compareRevisions);
        }

        public List<string> GetPublishingTargets(string dbName)
        {
            var db = DataWrapper.GetDatabase(dbName);
            
            var publishingTargetsItem = db.GetItem("/sitecore/system/publishing targets");
            return publishingTargetsItem?.GetChildren()
                       .Select(
                           child => child?.Fields["target database"]?.Value ?? string.Empty
                       ).Where(a => !string.IsNullOrEmpty(a))
                       .ToList() ?? new List<string>();
        }
    }
}