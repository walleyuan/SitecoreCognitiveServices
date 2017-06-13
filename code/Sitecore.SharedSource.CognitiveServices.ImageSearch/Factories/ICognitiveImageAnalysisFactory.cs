using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Analysis;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories
{
    public interface ICognitiveImageAnalysisFactory
    {
        ICognitiveImageAnalysis Create();
        ICognitiveImageAnalysis Create(ICognitiveImageSearchResult result);
    }
}