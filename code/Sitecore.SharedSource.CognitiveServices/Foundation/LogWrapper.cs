using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.CognitiveServices.Foundation {
    public class LogWrapper : ILogWrapper {

        public void Error(string message, object owner, Exception ex = null)
        {
            if(ex == null)
                Log.Error(message, owner);
            else 
                Log.Error(message, ex, owner);
        }

        public void Warn(string message, object owner, Exception ex = null) {
            if (ex == null)
                Log.Warn(message, owner);
            else
                Log.Warn(message, ex, owner);
        }

        public void Info(string message, object owner) {
            Log.Info(message, owner);
        }
    }
}