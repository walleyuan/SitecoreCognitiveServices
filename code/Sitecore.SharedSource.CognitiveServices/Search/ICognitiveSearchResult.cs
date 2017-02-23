using System.Collections.Generic;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Language;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public interface ICognitiveSearchResult : ISearchResult
    {
        string EmotionAnalysisValue { get; set; }
        Emotion[] EmotionAnalysis { get; }
        string FacialAnalysisValue { get; set; }
        Microsoft.ProjectOxford.Face.Contract.Face[] FacialAnalysis { get; }
        string TextAnalysisValue { get; set; }
        OcrResults TextAnalysis { get; }
        string VisionAnalysisValue { get; set; }
        AnalysisResult VisionAnalysis { get; }
        string LanguageAnalysisValue { get; set; }
        LanguageResponse LanguageAnalysis { get; }
        string LinkAnalysisValue { get; set; }
        List<LinkAnalysisResult> LinkAnalysis { get; }
        string SentimentAnalysisValue { get; set; }
        SentimentResponse SentimentAnalysis { get; }
        string KeyPhraseAnalysisValue { get; set; }
        List<KeyPhraseAnalysisResult> KeyPhraseAnalysis { get; }
        string LinguisticAnalysisValue { get; set; }
        List<LinguisticAnalysisResult> LinguisticAnalysis { get; }
        string UniqueId { get; set; }
        string Language { get; set; }
        string Path { get; set; }
        string TemplateName { get; set; }
        string DatabaseName { get; set; }
    }
}