using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Foundation {
    public interface ILogWrapper
    {
        void Error(string message, object owner, Exception ex = null);
        void Warn(string message, object owner, Exception ex = null);
        void Info(string message, object owner);
    }
}