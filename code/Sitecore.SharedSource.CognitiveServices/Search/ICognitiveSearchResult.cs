using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.ContentSearch;

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
        EntityLink[] LinkAnalysis { get; }
        string SentimentAnalysisValue { get; set; }
        SentimentResponse SentimentAnalysis { get; }
        string UniqueId { get; set; }
    }
}