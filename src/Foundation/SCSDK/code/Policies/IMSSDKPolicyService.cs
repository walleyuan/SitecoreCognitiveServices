using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polly.Fallback;
using Polly.Retry;
using Polly.Wrap;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Policies
{
    public interface IMSSDKPolicyService
    {
        T ExecuteAndCapture<T>(string requestType, int retryInSeconds, Func<T> action);
    }
}