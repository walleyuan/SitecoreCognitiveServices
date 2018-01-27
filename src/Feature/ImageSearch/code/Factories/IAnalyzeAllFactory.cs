using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface IAnalyzeAllFactory
    {
        IAnalyzeAll Create(string itemId, string db, string language, string handleName);
    }
}