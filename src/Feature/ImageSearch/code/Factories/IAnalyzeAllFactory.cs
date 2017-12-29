using SitecoreCognitiveServices.Feature.ImageSearch.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface IAnalyzeAllFactory
    {
        IAnalyzeAll Create(string itemId, string db, string language, int itemCount);
    }
}