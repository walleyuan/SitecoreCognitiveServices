using System.Collections.Generic;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class CognitiveTextAnalysis : ICognitiveTextAnalysis
    {
        public CognitiveTextAnalysis()
        {
            LinkAnalysis = new List<LinkAnalysisResult>();
            SentimentAnalysis = new SentimentResponse();
            LanguageAnalysis = new LanguageResponse();
        }

        public List<LinkAnalysisResult> LinkAnalysis { get; set; }
        public SentimentResponse SentimentAnalysis { get; set; }
        public LanguageResponse LanguageAnalysis { get; set; }
    }
}