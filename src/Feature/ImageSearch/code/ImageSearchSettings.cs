using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;

namespace SitecoreCognitiveServices.Feature.ImageSearch {
    public class ImageSearchSettings : IImageSearchSettings {
        public virtual string SitecoreIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.SitecoreIndexNameFormat");
        public virtual string CognitiveIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.CognitiveIndexNameFormat");
        public virtual string ImageAnalysisFolder => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisFolder");
        public virtual string ImageAnalysisTemplate => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisTemplate");
        public virtual string VisualAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.Fields.VisualAnalysis");
        public virtual string TextualAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.Fields.TextualAnalysis");
        public virtual string FacialAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.Fields.FacialAnalysis");
        public virtual string EmotionalAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.Fields.EmotionalAnalysis");
        public virtual string AnalyzedImageField => Settings.GetSetting("CognitiveService.ImageSearch.Fields.AnalyzedImage");
    }
}