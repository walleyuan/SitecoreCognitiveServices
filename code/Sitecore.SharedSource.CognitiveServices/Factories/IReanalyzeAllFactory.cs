using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface IReanalyzeAllFactory
    {
        IReanalyzeAll Create();

        IReanalyzeAll Create(int itemCount, string db, string language, string itemId);
    }
}