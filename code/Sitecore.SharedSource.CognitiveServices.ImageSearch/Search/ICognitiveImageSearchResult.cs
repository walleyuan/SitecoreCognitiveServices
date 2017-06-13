using System.Collections.Generic;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public interface ICognitiveImageSearchResult
    {
        string EmotionAnalysisValue { get; set; }
        Emotion[] EmotionAnalysis { get; }
        string FacialAnalysisValue { get; set; }
        Microsoft.ProjectOxford.Face.Contract.Face[] FacialAnalysis { get; }
        string TextAnalysisValue { get; set; }
        OcrResults TextAnalysis { get; }
        string VisionAnalysisValue { get; set; }
        AnalysisResult VisionAnalysis { get; }
        string UniqueId { get; set; }
        string Language { get; set; }
        string Path { get; set; }
        string TemplateName { get; set; }
        string DatabaseName { get; set; }
        int Gender { get; set; }
        int Size { get; set; }
        List<int> Glasses { get; set; }
        string[] Tags { get; set; }
        double AgeMin { get; set; }
        double AgeMax { get; set; }
    }
}