using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface IReanalyzeAllFactory
    {
        IReanalyzeAll Create(string itemId, string db, string language, int itemCount);
    }
}