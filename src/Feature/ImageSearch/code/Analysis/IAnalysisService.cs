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
    public interface IAnalysisService
    {
        ICognitiveImageAnalysis GetAnalysis(string id, string dbName);
        ICognitiveImageAnalysis AnalyzeImage(Item imageItem);
        int AnalyzeImagesRecursively(Item item, string db);
        Emotion[] GetEmotionAnalysis(MediaItem m);
        Face[] GetFaceAnalysis(MediaItem m);
        AnalysisResult GetVisionAnalysis(MediaItem m);
        OcrResults GetTextAnalysis(MediaItem m);
        Item GetImageAnalysisFolder(string dbName);
        Item GetImageAnalysisTemplate(string dbName);
    }
}