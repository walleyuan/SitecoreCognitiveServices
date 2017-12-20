
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

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
        bool HasAnyAnalysis();
        bool HasNoAnalysis();
    }
}