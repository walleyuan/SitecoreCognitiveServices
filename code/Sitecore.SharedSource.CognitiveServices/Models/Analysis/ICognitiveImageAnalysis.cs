using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models.Analysis
{
    public interface ICognitiveImageAnalysis
    {
        AnalysisResult VisionAnalysis { get; set; }
        OcrResults TextAnalysis { get; set; }
        Emotion[] EmotionAnalysis { get; set; }
        Microsoft.ProjectOxford.Face.Contract.Face[] FacialAnalysis { get; set; }
        string ImageUrl { get; set; }
        int ImageHeight { get; set; }
        int ImageWidth { get; set; }
    }
}