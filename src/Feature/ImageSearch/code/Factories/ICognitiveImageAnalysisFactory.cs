using Sitecore.Data.Items;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface ICognitiveImageAnalysisFactory
    {
        ICognitiveImageAnalysis Create();
        ICognitiveImageAnalysis Create(ICognitiveImageSearchResult result);
        ICognitiveImageAnalysis Create(MediaItem mediaItem, Emotion[] emotionAnalysis, Face[] facialAnalysis,
            OcrResults textAnalysis, AnalysisResult visionAnalysis);
    }
}