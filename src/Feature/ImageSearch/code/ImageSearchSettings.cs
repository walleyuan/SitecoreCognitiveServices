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
    }
}