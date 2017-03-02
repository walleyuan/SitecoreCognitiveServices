using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.Models.Analysis;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveTextAnalysisFactory : ICognitiveTextAnalysisFactory
    {
        protected readonly IServiceProvider Provider;

        public CognitiveTextAnalysisFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual ICognitiveTextAnalysis Create()
        {
            return Provider.GetService<ICognitiveTextAnalysis>();
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