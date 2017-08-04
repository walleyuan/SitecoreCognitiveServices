
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Analysis
{
    public interface ICognitiveImageAnalysis
    {
        AnalysisResult VisionAnalysis { get; set; }
        OcrResults TextAnalysis { get; set; }
        Emotion[] EmotionAnalysis { get; set; }
        Face[] FacialAnalysis { get; set; }
        string ImageUrl { get; set; }
        int ImageHeight { get; set; }
        int ImageWidth { get; set; }
    }
}