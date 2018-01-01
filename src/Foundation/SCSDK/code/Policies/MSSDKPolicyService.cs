using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Polly;
using Polly.Fallback;
using Polly.Retry;
using Polly.Wrap;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Policies
{
    public class MSSDKPolicyService : IMSSDKPolicyService
    {
        protected readonly ILogWrapper Logger;
        public MSSDKPolicyService(ILogWrapper logger)
        {
            Logger = logger;
        }
        
        public T ExecuteRetryAndCapture400Errors<T>(string requestType, int retryInSeconds, Func<T> action, T defaultValue)
        {
            var policyResult = Policy
                .Handle<WebException>(ex => ex.Message.Contains("(429) Too Many Requests"))
                .WaitAndRetry(
                    1,
                    retryAttempt => TimeSpan.FromSeconds(retryInSeconds),
                    (exception, span) =>
                    {
                        //{ "statusCode": 429, "message": "Rate limit is exceeded. Try again in 38 seconds." }
                        Logger.Info($"{requestType} failed: Too Many Requests. will retry", this);
                    })
                .ExecuteAndCapture(action);

            if (policyResult.Outcome == OutcomeType.Failure)
            {
                var additionalInfo = (policyResult.FinalException.Message.Contains("(400) Bad Request"))
                    ? "; image didn't fit the API requirements"
                    : string.Empty;

                additionalInfo += (policyResult.FinalException.Message.Contains("(401) Unauthorized"))
                    ? "; api key or url is incorrect"
                    : string.Empty;

                Logger.Error($"{requestType} failed{additionalInfo}", this, policyResult.FinalException);

                return defaultValue;
            }

            Logger.Info($"{requestType} Succeeded", this);

            return policyResult.Result;
        }
    }
}