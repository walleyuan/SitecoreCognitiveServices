using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class CognitiveImageAnalysis : ICognitiveImageAnalysis
    {
        public AnalysisResult VisionAnalysis { get; set; }
        public OcrResults TextAnalysis { get; set; }
        public Emotion[] EmotionAnalysis { get; set; }
        public Microsoft.ProjectOxford.Face.Contract.Face[] FacialAnalysis { get; set; }
    }
}