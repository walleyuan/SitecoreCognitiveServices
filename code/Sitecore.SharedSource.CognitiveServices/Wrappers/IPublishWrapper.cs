using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Wrappers
{
    public interface IPublishWrapper
    {
        Handle PublishItem(Item item, Database[] targets, Globalization.Language[] languages, bool deep, bool compareRevisions);
    }
}