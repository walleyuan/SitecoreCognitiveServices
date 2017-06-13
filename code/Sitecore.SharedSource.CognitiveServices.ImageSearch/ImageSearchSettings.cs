using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch {
    public class ImageSearchSettings : IImageSearchSettings {
        public virtual string IndexNameFormat => Sitecore.Configuration.Settings.GetSetting("CognitiveService.ImageSearch.IndexNameFormat");
    }
}