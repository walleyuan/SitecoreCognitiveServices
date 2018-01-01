using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polly.Fallback;
using Polly.Retry;
using Polly.Wrap;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Policies
{
    /// <summary>
    /// The Policy Service configures shared timeouts and retries for methods calls to APIs
    /// </summary>
    public interface IMSSDKPolicyService
    {
        /// <summary>
        /// Will execute the action and retry the call if you get a 429 (too many at a time). Exceptions are logged
        /// </summary>
        T ExecuteRetryAndCapture400Errors<T>(string requestType, int retryInSeconds, Func<T> action, T defaultValue);
    }
}