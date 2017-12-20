
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis
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
        public bool HasAnyAnalysis()
        {
            var hasAnyAnalyis = EmotionAnalysis?.Length > 0
                                || FacialAnalysis?.Length > 0
                                || TextAnalysis?.Regions != null
                                || VisionAnalysis?.Description != null;

            return hasAnyAnalyis;
        }

        public bool HasNoAnalysis()
        {
            return !HasAnyAnalysis();
        }
    }
}