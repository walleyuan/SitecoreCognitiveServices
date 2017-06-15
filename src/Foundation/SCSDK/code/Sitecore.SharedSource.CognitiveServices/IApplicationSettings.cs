using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices {
    public interface IApplicationSettings {
        bool CatchAndReleaseExceptions { get; }
    }
}