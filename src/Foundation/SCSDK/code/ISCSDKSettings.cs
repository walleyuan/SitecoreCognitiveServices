using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Foundation.SCSDK {
    public interface ISCSDKSettings {
        string CoreDatabase { get; }
        string MasterDatabase { get; }
        string WebDatabase { get; }
        ID MSSDKId { get; }
        ID IBMSDKId { get; }
        bool CatchAndReleaseExceptions { get; }
        string SitecoreIndexNameFormat { get; }
    }
}