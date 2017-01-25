using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
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
            var jsd = new JavaScriptSerializer();

            var analysis = Create();

            try { 
                var lJson = (result != null) ? result.LanguageAnalysis : string.Empty;
                analysis.LanguageAnalysis = jsd.Deserialize<LanguageResponse>(lJson);
            } catch { }

            try {
                var lnkJson = (result != null) ? result.LinkAnalysis : string.Empty;
                analysis.LinkAnalysis = jsd.Deserialize<EntityLink[]>(lnkJson);
            } catch { }

            try { 
                var sJson = (result != null) ? result.SentimentAnalysis : string.Empty;
                analysis.SentimentAnalysis = jsd.Deserialize<SentimentResponse>(sJson);
            } catch { }

            return analysis;
        }
    }
}