using System.Collections.Generic;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.SharedSource.CognitiveServices.Models.Language;

namespace Sitecore.SharedSource.CognitiveServices.Models.Analysis
{
    public class CognitiveTextAnalysis : ICognitiveTextAnalysis
    {
        public CognitiveTextAnalysis()
        {
            LinkAnalysis = new List<LinkAnalysisResult>();
            SentimentAnalysis = new SentimentResponse();
            KeyPhraseAnalysis = new List<KeyPhraseAnalysisResult>();
            LinguisticAnalysis = new List<LinguisticAnalysisResult>();
        }

        public List<LinkAnalysisResult> LinkAnalysis { get; set; }
        public SentimentResponse SentimentAnalysis { get; set; }
        public List<KeyPhraseAnalysisResult> KeyPhraseAnalysis { get; set; }
        public List<LinguisticAnalysisResult> LinguisticAnalysis { get; set; }
    }
}