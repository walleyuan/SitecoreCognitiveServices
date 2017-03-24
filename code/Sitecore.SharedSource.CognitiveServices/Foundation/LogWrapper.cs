using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.CognitiveServices.Foundation {
    public class LogWrapper : ILogWrapper {

        public virtual void Error(string message, object owner, Exception ex = null)
        {
            if(ex == null) { 
                Log.Error(message, owner);
            } else {  
                Log.Error(ProcessWebException(message, ex), ex, owner);
                if (ex.InnerException != null)
                    throw ex.InnerException;
                throw ex;
            }
        }

        public virtual void Warn(string message, object owner, Exception ex = null) {
            if (ex == null)
                Log.Warn(message, owner);
            else
                Log.Warn(message, ex, owner);
        }

        public virtual void Info(string message, object owner) {
            Log.Info(message, owner);
        }

        protected virtual string ProcessWebException(string message, Exception e)
        {
            if (!(e is WebException))
                return message;

            var we = (WebException) e;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine($"{e}");

            string strResponse = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)we.Response) {
                using (Stream responseStream = response.GetResponseStream()) {
                    using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.ASCII)) {
                        sb.AppendLine(sr.ReadToEnd());
                    }
                }
            }
            sb.AppendLine($"Http status code={we.Status}, error message={strResponse}");

            return sb.ToString();
        }
    }
}