using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Analysis
{
    public interface IImageAnalysisService
    {
        ICognitiveImageAnalysis AnalyzeImage(Item imageItem);
        int AnalyzeImagesRecursively(Item item, string db);
        Emotion[] GetEmotionalAnalysis(MediaItem m);
        Face[] GetFacialAnalysis(MediaItem m);
        AnalysisResult GetVisualAnalysis(MediaItem m);
        OcrResults GetTextualAnalysis(MediaItem m);
        Item CreateAnalysisItem(Item imageItem);
        Item GetImageAnalysisFolder(string dbName);
        Item GetImageAnalysisTemplate(string dbName);
    }
}