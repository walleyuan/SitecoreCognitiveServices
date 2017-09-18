using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge {
    public class AcademicSearchRepository : IAcademicSearchRepository
    {
        protected static readonly string calcUrl = "calchistogram";
        protected static readonly string evaluateUrl = "evaluate";
        protected static readonly string graphUrl = "graph/search";
        protected static readonly string interpretUrl = "interpret";
        protected static readonly string similarityUrl = "similarity";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public AcademicSearchRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        protected virtual string GetModelName(AcademicModelOptions model) {
            return Enum.GetName(typeof(AcademicModelOptions), model).Replace("beta2015", "beta-2015");
        }

        #region Calculate Histogram

        protected virtual string GetCalcQuerystring(string attributes, int count, int offset)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(attributes))
                sb.Append($"&attributes={attributes}");

            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression">Example: Composite(AA.AuN='sue dumais') - See: https://www.microsoft.com/cognitive-services/en-us/Academic-Knowledge-API/documentation/QueryExpressionSyntax</param>
        /// <param name="model"></param>
        /// <param name="attributes"></param>
        /// <param name="count"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public virtual CalcHistogramResponse CalcHistogram(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0)
        {
            var qs = GetCalcQuerystring(attributes, count, offset);
            var modelName = GetModelName(model);
            var response = RepositoryClient.SendGet(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{calcUrl}?expr={expression}&model={modelName}{qs}");

            return JsonConvert.DeserializeObject<CalcHistogramResponse>(response);
        }

        public virtual async Task<CalcHistogramResponse> CalcHistogramAsync(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0)
        {
            var qs = GetCalcQuerystring(attributes, count, offset);
            var modelName = GetModelName(model);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{calcUrl}?expr={expression}&model={modelName}{qs}");

            return JsonConvert.DeserializeObject<CalcHistogramResponse>(response);
        }

        #endregion Calculate Histogram

        #region Evaluate

        protected virtual string GetEvaluateQuerystring(int count, int offset, string orderby, string attributes)
        {
            StringBuilder sb = new StringBuilder();

            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            if (!string.IsNullOrEmpty(orderby))
                sb.Append($"&orderby={orderby}");

            if (!string.IsNullOrEmpty(attributes))
                sb.Append($"&attributes={attributes}");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression">Example: Composite(AA.AuN='sue dumais') - See: https://www.microsoft.com/cognitive-services/en-us/Academic-Knowledge-API/documentation/QueryExpressionSyntax</param>
        /// <param name="model"></param>
        /// <param name="attributes"></param>
        /// <param name="count"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public virtual EvaluateResponse Evaluate(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "") {
            var qs = GetEvaluateQuerystring(count, offset, orderby, attributes);
            var modelName = GetModelName(model);
            var response = RepositoryClient.SendGet(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{evaluateUrl}?expr={expression}&model={modelName}{qs}");

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        public virtual async Task<EvaluateResponse> EvaluateAsync(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "") {

            var qs = GetEvaluateQuerystring(count, offset, orderby, attributes);
            var modelName = GetModelName(model);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{evaluateUrl}?expr={expression}&model={modelName}{qs}");

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        #endregion Evaluate

        #region Graph Search

        public virtual GraphSearchResponse GraphSearch(GraphSearchRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{graphUrl}?mode=json", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<GraphSearchResponse>(response);
        }

        public virtual async Task<GraphSearchResponse> GraphSearchAsync(GraphSearchRequest request) {
            
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{graphUrl}?mode=json", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<GraphSearchResponse>(response);
        }

        #endregion Graph Search

        #region Interpret

        protected virtual string GetInterpretQuerystring(bool complete, int count, int offset, int timeout)
        {
            StringBuilder sb = new StringBuilder();

            if (complete)
                sb.Append($"complete={complete}");

            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            if (timeout > 0)
                sb.Append($"&timeout={timeout}");

            return sb.ToString();
        }
        
        /// <param name="query">Query entered by user. If complete is set to 1, query will be interpreted as a prefix for generating query auto-completion suggestions.</param>
        /// <param name="complete">1 means that auto-completion suggestions are generated based on the grammar and graph data.</param>
        /// <param name="count">Maximum number of interpretations to return.</param>
        /// <param name="offset">Index of the first interpretation to return. For example, count=2&offset=0 returns interpretations 0 and 1. count=2&offset=2 returns interpretations 2 and 3.</param>
        /// <param name="timeout">Timeout in milliseconds.Only interpretations found before the timeout has elapsed are returned.</param>
        /// <param name="model">Name of the model that you wish to query.Currently, the value defaults to "latest".</param>
        /// <returns></returns>
        public virtual InterpretResponse Interpret(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest)
        {
            var qs = GetInterpretQuerystring(complete, count, offset, timeout);
            var modelName = GetModelName(model);
            var response = RepositoryClient.SendGet(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{interpretUrl}?query={query}&model={modelName}{qs}");

            return JsonConvert.DeserializeObject<InterpretResponse>(response);
        }

        public virtual async Task<InterpretResponse> InterpretAsync(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest)
        {
            var qs = GetInterpretQuerystring(complete, count, offset, timeout);
            var modelName = GetModelName(model);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{interpretUrl}?query={query}&model={modelName}{qs}");

            return JsonConvert.DeserializeObject<InterpretResponse>(response);
        }

        #endregion Interpret

        #region Similarity
        
        public virtual double Similarity(string s1, string s2)
        {
            var response = RepositoryClient.SendEncodedFormPost(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{similarityUrl}", $"s1={s1}&s2={s2}");

            return JsonConvert.DeserializeObject<double>(response);
        }

        public virtual async Task<double> SimilarityAsync(string s1, string s2)
        {
            var response = await RepositoryClient.SendEncodedFormPostAsync(ApiKeys.Academic, $"{ApiKeys.AcademicEndpoint}{similarityUrl}", $"s1={s1}&s2={s2}");

            return JsonConvert.DeserializeObject<double>(response);
        }

        #endregion Similarity
    }
}