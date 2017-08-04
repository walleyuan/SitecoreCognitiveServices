
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Models.Analysis
{
    public class CognitiveImageAnalysis : ICognitiveImageAnalysis
    {
        public CognitiveImageAnalysis()
        {
            VisionAnalysis = new AnalysisResult();
            TextAnalysis = new OcrResults();
            EmotionAnalysis = new Emotion[0];
            FacialAnalysis = new Face[0];
        }

        public AnalysisResult VisionAnalysis { get; set; }
        public OcrResults TextAnalysis { get; set; }
        public Emotion[] EmotionAnalysis { get; set; }
        public Face[] FacialAnalysis { get; set; }
        public string ImageUrl { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
    }
}