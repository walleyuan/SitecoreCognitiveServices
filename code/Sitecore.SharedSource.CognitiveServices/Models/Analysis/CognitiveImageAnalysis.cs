using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models.Analysis
{
    public class CognitiveImageAnalysis : ICognitiveImageAnalysis
    {
        public CognitiveImageAnalysis()
        {
            VisionAnalysis = new AnalysisResult();
            TextAnalysis = new OcrResults();
            EmotionAnalysis = new Emotion[0];
            FacialAnalysis = new Microsoft.ProjectOxford.Face.Contract.Face[0];
        }

        public AnalysisResult VisionAnalysis { get; set; }
        public OcrResults TextAnalysis { get; set; }
        public Emotion[] EmotionAnalysis { get; set; }
        public Microsoft.ProjectOxford.Face.Contract.Face[] FacialAnalysis { get; set; }
        public string ImageUrl { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
    }
}