using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Foundation.SCSDK {
    public interface IApplicationSettings {
        ID MSSDKId { get; }
        ID IBMSDKId { get; }
        bool CatchAndReleaseExceptions { get; }
    }
}