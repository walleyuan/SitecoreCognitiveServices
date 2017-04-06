using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Publishing;

namespace Sitecore.SharedSource.CognitiveServices.Foundation {
    public class PublishWrapper : IPublishWrapper {
        public Handle PublishItem(Item item, Database[] targets, Globalization.Language[] languages, bool deep, bool compareRevisions) {
            return PublishManager.PublishItem(item, targets, languages, deep, compareRevisions);
        }
    }
}