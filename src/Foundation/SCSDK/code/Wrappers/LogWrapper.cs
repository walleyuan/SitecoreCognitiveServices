using System;
using System.IO;
using System.Net;
using System.Text;
using Sitecore.Diagnostics;
using Sitecore.Web.UI.WebControls;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface ILogWrapper
    {
        void Error(string message, object owner, Exception ex = null);
        void Warn(string message, object owner, Exception ex = null);
        void Info(string message, object owner);
    }

    public class LogWrapper : ILogWrapper
    {
        protected readonly IApplicationSettings Settings;

        public LogWrapper(IApplicationSettings settings)
        {
            Settings = settings;
        }

        public virtual void Error(string message, object owner, Exception ex = null)
        {
            if(ex == null) { 
                Log.Error(message, owner);
            } else {  
                Log.Error(ProcessException(message, ex), ex, owner);

                if (!Settings.CatchAndReleaseExceptions)
                    return;

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

        protected virtual string HandleWebException(WebException exception)
        {
            if (exception == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            
            try
            {
                Stream responseStream = exception?.Response.GetResponseStream();
                using (StreamReader sr = new StreamReader(responseStream, Encoding.ASCII))
                {
                    sb.AppendLine(sr.ReadToEnd());
                }
            }
            catch (NullReferenceException)
            {
                sb.AppendLine("WebException response was null");
            }

            return sb.ToString();
        }

        protected virtual string ProcessException(string message, Exception e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine($"{e}");

            WebException webexInner = e.InnerException as WebException;
            if (webexInner != null)
                sb.Append(HandleWebException(webexInner));

            WebException webex = e as WebException;
            if (webex != null)
                sb.Append(HandleWebException(webex));
            
            return sb.ToString();
        }
    }
}