using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveTextAnalysisFactory : ICognitiveTextAnalysisFactory
    {
        public ICognitiveTextAnalysis Create()
        {
            return new CognitiveTextAnalysis();
        }

        public ICognitiveTextAnalysis Create(ICognitiveSearchResult result)
        {
            var analysis = Create();
            analysis.LanguageAnalysis = result.LanguageAnalysis;
            analysis.LinkAnalysis = result.LinkAnalysis;
            analysis.SentimentAnalysis = result.SentimentAnalysis;
            
            return analysis;
        }
    }
}