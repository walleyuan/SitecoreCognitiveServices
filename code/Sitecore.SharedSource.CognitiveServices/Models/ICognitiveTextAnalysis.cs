using System.Collections.Generic;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface ICognitiveTextAnalysis
    {
        List<LinkAnalysisResult> LinkAnalysis { get; set; }
        SentimentResponse SentimentAnalysis { get; set; }
        LanguageResponse LanguageAnalysis { get; set; }
    }
}