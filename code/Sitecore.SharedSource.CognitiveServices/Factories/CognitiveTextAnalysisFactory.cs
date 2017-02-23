using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Analysis;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveTextAnalysisFactory : ICognitiveTextAnalysisFactory
    {
        protected readonly IReflectionUtilWrapper ReflectionUtil;

        public CognitiveTextAnalysisFactory(IReflectionUtilWrapper reflectionUtil)
        {
            ReflectionUtil = reflectionUtil;
        }

        public virtual ICognitiveTextAnalysis Create()
        {
            return ReflectionUtil.CreateObjectFromSettings<ICognitiveTextAnalysis>("CognitiveService.Types.ICognitiveTextAnalysis");
        }

        public virtual ICognitiveTextAnalysis Create(ICognitiveSearchResult result)
        {
            var analysis = Create();
            analysis.LanguageAnalysis = result.LanguageAnalysis;
            analysis.LinkAnalysis = result.LinkAnalysis;
            analysis.SentimentAnalysis = result.SentimentAnalysis;
            analysis.KeyPhraseAnalysis = result.KeyPhraseAnalysis;
            analysis.LinguisticAnalysis = result.LinguisticAnalysis;
            
            return analysis;
        }
    }
}