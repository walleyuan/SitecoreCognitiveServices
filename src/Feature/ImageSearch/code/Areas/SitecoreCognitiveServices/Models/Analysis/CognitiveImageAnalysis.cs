using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis
{
    public class CognitiveImageAnalysis : ICognitiveImageAnalysis
    {
        public CognitiveImageAnalysis()
        {
            VisionAnalysis = new AnalysisResult();
            TextAnalysis = new OcrResults();
            FacialAnalysis = new Face[0];
        }

        public AnalysisResult VisionAnalysis { get; set; }
        public OcrResults TextAnalysis { get; set; }
        public Face[] FacialAnalysis { get; set; }
        public string ImageUrl { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public bool HasAnyAnalysis()
        {
            var hasAnyAnalyis = FacialAnalysis?.Length > 0
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