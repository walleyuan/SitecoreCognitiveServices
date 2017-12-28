using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch {
    public class ImageSearchSettings : IImageSearchSettings {
        public virtual string SitecoreIndexNameFormat => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.SitecoreIndexNameFormat");
        public virtual string CognitiveIndexNameFormat => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.CognitiveIndexNameFormat");
        public virtual string ImageAnalysisFolder => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisFolder");
        public virtual string ImageAnalysisTemplate => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisTemplate");
        public virtual string VisualAnalysisField => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.Fields.VisualAnalysis");
        public virtual string TextualAnalysisField => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.Fields.TextualAnalysis");
        public virtual string FacialAnalysisField => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.Fields.FacialAnalysis");
        public virtual string EmotionalAnalysisField => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.Fields.EmotionalAnalysis");
    }
}