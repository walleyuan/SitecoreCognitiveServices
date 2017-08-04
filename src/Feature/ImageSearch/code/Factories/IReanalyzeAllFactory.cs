using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Utility;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories
{
    public interface IReanalyzeAllFactory
    {
        IReanalyzeAll Create(string itemId, string db, string language, int itemCount);
    }
}