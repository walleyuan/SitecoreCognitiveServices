using SitecoreCognitiveServices.Feature.ImageSearch.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface IReanalyzeAllFactory
    {
        IReanalyzeAll Create(string itemId, string db, string language, int itemCount);
    }
}