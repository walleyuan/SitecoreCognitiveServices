using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Foundation.SCSDK {
    public class ApplicationSettings : IApplicationSettings
    {
        public virtual ID MSSDKId => new ID("{03BAF8AE-03CB-4E30-875C-0901EBA6A163}");
        public virtual ID IBMSDKId => new ID("{503A5B1D-6F2F-41EC-9A77-AE1DAA37A987}");
        public virtual bool CatchAndReleaseExceptions
        {
            get
            {
                var value = Sitecore.Configuration.Settings.GetSetting("CognitiveService.CatchAndReleaseExceptions");
                bool boolValue;

                return (bool.TryParse(value, out boolValue)) && boolValue;
            }
        }
    }
}