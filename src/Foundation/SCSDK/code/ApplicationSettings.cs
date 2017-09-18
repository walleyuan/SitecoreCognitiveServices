using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK {
    public class ApplicationSettings : IApplicationSettings
    {
        public virtual bool CatchAndReleaseExceptions
        {
            get
            {
                var value = Sitecore.Configuration.Settings.GetSetting("CognitiveService.CatchAndReleaseExceptions");
                var boolValue = false;

                return (bool.TryParse(value, out boolValue)) && boolValue;
            }
        }
    }
}