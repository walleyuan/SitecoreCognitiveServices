
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis
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