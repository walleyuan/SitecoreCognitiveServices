using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices {
    public class ApplicationSettings : IApplicationSettings
    {
        public virtual Guid OleApplicationId => new Guid(Sitecore.Configuration.Settings.GetSetting("CognitiveService.OleApplicationId"));
        public virtual string IndexNameFormat => Sitecore.Configuration.Settings.GetSetting("CognitiveService.Search.IndexNameFormat");
    }
}