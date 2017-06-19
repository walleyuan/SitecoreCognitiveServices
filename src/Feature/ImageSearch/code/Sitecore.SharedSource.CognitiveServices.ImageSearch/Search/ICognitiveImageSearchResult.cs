using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public interface ICognitiveImageSearchResult
    {
        string EmotionAnalysisValue { get; set; }
        Emotion[] EmotionAnalysis { get; }
        string FacialAnalysisValue { get; set; }
        Face[] FacialAnalysis { get; }
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