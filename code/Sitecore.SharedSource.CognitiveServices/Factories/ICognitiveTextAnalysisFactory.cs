using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public interface ICognitiveTextAnalysisFactory
    {
        ICognitiveTextAnalysis Create();
        ICognitiveTextAnalysis Create(ICognitiveSearchResult result);
    }
}