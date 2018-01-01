using System;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge
{
    public class AcademicSearchService : IAcademicSearchService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IAcademicSearchRepository AcademicSearchRepository;
        protected readonly ILogWrapper Logger;

        public AcademicSearchService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IAcademicSearchRepository academicSearchRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            AcademicSearchRepository = academicSearchRepository;
            Logger = logger;
        }
        
        public virtual CalcHistogramResponse CalcHistogram(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "AcademicSearchService.CalcHistogram",
                ApiKeys.AcademicRetryInSeconds,
                () =>
                {
                    var result = AcademicSearchRepository.CalcHistogram(expression, model, attributes, count, offset);
                    return result;
                },
                null);
        }

        public virtual EvaluateResponse Evaluate(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "AcademicSearchService.Evaluate",
                ApiKeys.AcademicRetryInSeconds,
                () =>
                {
                    var result = AcademicSearchRepository.Evaluate(expression, model, count, offset, attributes, orderby);
                    return result;
                },
                null);
        }
        
        public virtual GraphSearchResponse GraphSearch(GraphSearchRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "AcademicSearchService.GraphSearch",
                ApiKeys.AcademicRetryInSeconds,
                () =>
                {
                    var result = AcademicSearchRepository.GraphSearch(request);
                    return result;
                },
                null);
        }

        public virtual InterpretResponse Interpret(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "AcademicSearchService.Interpret",
                ApiKeys.AcademicRetryInSeconds,
                () =>
                {
                    var result = AcademicSearchRepository.Interpret(query, complete, count, offset, timeout, model);
                    return result;
                },
                null);
        }
        
        public virtual double Similarity(string s1, string s2)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "AcademicSearchService.Similarity",
                ApiKeys.AcademicRetryInSeconds,
                () =>
                {
                    var result = AcademicSearchRepository.Similarity(s1, s2);
                    return result;
                },
                0f);            
        }
    }
}