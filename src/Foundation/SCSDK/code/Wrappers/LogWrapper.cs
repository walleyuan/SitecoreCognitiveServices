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
                Log.Error(ProcessWebException(message, ex), ex, owner);

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

        protected virtual string HandleWebException(WebException exception, string message)
        {
            if (exception == null)
                return message;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine($"{exception}");
            
            try
            {
                Stream responseStream = exception?.Response.GetResponseStream();
                using (StreamReader sr = new StreamReader(responseStream, Encoding.ASCII))
                {
                    sb.AppendLine(sr.ReadToEnd());
                }
                sb.AppendLine($"Http status code={exception.Status}, error message={message}");
            }
            catch (NullReferenceException)
            {
                sb.AppendLine($"WebException response was null, error message={message}");
            }

            return sb.ToString();
        }

        protected virtual string ProcessWebException(string message, Exception e)
        {
            WebException webexInner = e.InnerException as WebException;
            if (webexInner != null)
                return HandleWebException(webexInner, message);

            WebException webex = e as WebException;
            if (webex != null)
                return HandleWebException(webex, message);
            
            return message;
        }
    }
}