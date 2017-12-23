using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch {
    public class ImageSearchSettings : IImageSearchSettings {
        public virtual string IndexNameFormat => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.IndexNameFormat");
        public virtual string ImageAnalysisFolder => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisFolder");
        public virtual string ImageAnalysisTemplate => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisTemplate");
    }
}