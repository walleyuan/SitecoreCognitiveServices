using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Foundation.SCSDK {
    public class SCSDKSettings : ISCSDKSettings
    {
        public virtual string CoreDatabase => Settings.GetSetting("CognitiveService.CoreDatabase");
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.MasterDatabase");
        public virtual string WebDatabase => Settings.GetSetting("CognitiveService.WebDatabase");
        public virtual ID MSSDKId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ID"));
        public virtual ID IBMSDKId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.ID"));
        public virtual bool CatchAndReleaseExceptions
        {
            get
            {
                var value = Settings.GetSetting("CognitiveService.CatchAndReleaseExceptions");
                bool boolValue;

                return (bool.TryParse(value, out boolValue)) && boolValue;
            }
        }

        public virtual string SitecoreIndexNameFormat => Settings.GetSetting("CognitiveService.SitecoreIndexNameFormat");
    }
}