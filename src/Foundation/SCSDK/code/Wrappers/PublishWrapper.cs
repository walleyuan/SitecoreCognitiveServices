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
    }

    public class PublishWrapper : IPublishWrapper {
        public Handle PublishItem(Item item, Database[] targets, Language[] languages, bool deep, bool compareRevisions) {
            return PublishManager.PublishItem(item, targets, languages, deep, compareRevisions);
        }
    }
}