using System;

namespace Sitecore.SharedSource.CognitiveServices.Wrappers {
    public interface ILogWrapper
    {
        void Error(string message, object owner, Exception ex = null);
        void Warn(string message, object owner, Exception ex = null);
        void Info(string message, object owner);
    }
}