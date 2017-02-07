using System.Collections.Generic;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.SharedSource.CognitiveServices.Repositories.Language;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface ICognitiveTextAnalysis
    {
        List<LinkAnalysisResult> LinkAnalysis { get; set; }
        SentimentResponse SentimentAnalysis { get; set; }
        LanguageResponse LanguageAnalysis { get; set; }
        List<KeyPhraseAnalysisResult> KeyPhraseAnalysis { get; set; }
        List<LinguisticAnalysisResult> LinguisticAnalysis { get; set; }
    }
}