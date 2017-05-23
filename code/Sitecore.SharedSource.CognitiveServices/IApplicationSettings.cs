using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices {
    public interface IApplicationSettings {
        string IndexNameFormat { get; }
        bool CatchAndReleaseExceptions { get; }
    }
}