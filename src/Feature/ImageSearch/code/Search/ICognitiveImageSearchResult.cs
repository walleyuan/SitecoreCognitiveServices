using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Face;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search
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