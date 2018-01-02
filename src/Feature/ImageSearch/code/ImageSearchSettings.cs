using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Feature.ImageSearch {
    public class ImageSearchSettings : IImageSearchSettings
    {
        public virtual string SitecoreIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.SitecoreIndexNameFormat");
        public virtual string CognitiveIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.CognitiveIndexNameFormat");
        public virtual string ImageAnalysisFolder => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisFolder");
        public virtual string ImageAnalysisTemplate => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisTemplate");
        public virtual string VisualAnalysisField => "Visual Analysis";
        public virtual string TextualAnalysisField => "Textual Analysis";
        public virtual string FacialAnalysisField => "Facial Analysis";
        public virtual string EmotionalAnalysisField => "Emotional Analysis";
        public virtual string AnalyzedImageField => "Analyzed Image";
        public virtual ID ImageAnalysisFolderId => new ID("{DCA68A11-8670-4B60-B752-F95CBBC14E97}");
    }
}