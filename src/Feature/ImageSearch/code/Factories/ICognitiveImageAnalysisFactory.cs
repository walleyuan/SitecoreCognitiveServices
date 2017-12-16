using SitecoreCognitiveServices.Feature.ImageSearch.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface ICognitiveImageAnalysisFactory
    {
        ICognitiveImageAnalysis Create();
        ICognitiveImageAnalysis Create(ICognitiveImageSearchResult result);
    }
}