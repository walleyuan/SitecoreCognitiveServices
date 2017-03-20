using System.Collections.Generic;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.ContentSearch;
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
        string LinkAnalysisValue { get; set; }
        List<LinkAnalysisResult> LinkAnalysis { get; }
        string SentimentAnalysisValue { get; set; }
        SentimentResponse SentimentAnalysis { get; }
        string KeyPhraseAnalysisValue { get; set; }
        List<KeyPhraseAnalysisResult> KeyPhraseAnalysis { get; }
        string LinguisticAnalysisValue { get; set; }
        List<LinguisticAnalysisResult> LinguisticAnalysis { get; }
        string UniqueId { get; set; }
        int Gender { get; set; }
        int Size { get; set; }

        List<int> Glasses { get; set; }
        string[] Tags { get; set; }
        double AgeMin { get; set; }
        double AgeMax { get; set; }
        string Language { get; set; }
        string Path { get; set; }
        string TemplateName { get; set; }
        string DatabaseName { get; set; }
    }
}