using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Utility;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface IReanalyzeAllFactory
    {
        IReanalyzeAll Create(string itemId, string db, string language, int itemCount);
    }
}