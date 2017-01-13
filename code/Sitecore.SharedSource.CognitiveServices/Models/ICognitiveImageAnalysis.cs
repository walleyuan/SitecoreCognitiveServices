using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface ICognitiveImageAnalysis
    {
        AnalysisResult VisionAnalysis { get; set; }
        OcrResults TextAnalysis { get; set; }
        Emotion[] EmotionAnalysis { get; set; }
        Microsoft.ProjectOxford.Face.Contract.Face[] FacialAnalysis { get; set; }
        string ImageUrl { get; set; }
    }
}