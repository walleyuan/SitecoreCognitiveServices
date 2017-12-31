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
        
        public T ExecuteAndCapture<T>(string requestType, int retryInSeconds, Func<T> action)
        {
            var badRequestPolicy = Policy<T>
                .Handle<WebException>(ex => ex.Message.Contains("(400) Bad Request"))
                .Fallback(default(T), (exception, context) =>
                {
                    Logger.Info($"{requestType} failed because the image was outside of the API bounds", this);
                });

            var retryPolicy = Policy
                .Handle<WebException>(ex => ex.Message.Contains("(429) Too Many Requests"))
                .WaitAndRetry(
                    1,
                    retryAttempt => TimeSpan.FromSeconds(retryInSeconds),
                    (exception, span) =>
                    {
                        //{ "statusCode": 429, "message": "Rate limit is exceeded. Try again in 38 seconds." }
                        Logger.Info($"{requestType} failed. will retry", this);
                    });

            var policyResult = badRequestPolicy.Wrap(retryPolicy)
                .ExecuteAndCapture(action);

            if (policyResult.Outcome == OutcomeType.Failure)
            {
                Logger.Error($"{requestType} failed.", this, policyResult.FinalException);
                return default(T);
            }

            Logger.Info($"{requestType} Succeeded", this);

            return policyResult.Result;
        }
    }
}