using System.Collections.Generic;
using System.IO;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IVisionService
    {
        Description GetDescription(MediaItem mediaItem);
        void SetImageDescription(MediaItem mediaItem, string altDescription);
        OcrResults RecognizeText(Stream stream, string language = "unk", bool detectOrientation = true);
        OcrResults RecognizeText(string imageUrl, string language = "unk", bool detectOrientation = true);
        AnalysisResult AnalyzeImage(Stream stream, List<VisualFeature> features = null, IEnumerable<string> details = null);
        AnalysisResult AnalyzeImage(string imageUrl, List<VisualFeature> features = null, IEnumerable<string> details = null);
    }
}