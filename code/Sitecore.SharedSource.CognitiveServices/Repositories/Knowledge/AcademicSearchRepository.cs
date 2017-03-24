using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge.AcademicSearch;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge {
    public class AcademicSearchRepository : TextClient, IAcademicSearchRepository
    {
        protected static readonly string calcUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/calchistogram";
        protected static readonly string evaluateUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/evaluate";
        protected static readonly string graphUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/graph/search";
        protected static readonly string interpretUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/interpret";
        protected static readonly string similarityUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/similarity";
        
        protected readonly IRepositoryClient RepositoryClient;

        public AcademicSearchRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
            : base(apiKeys.Academic)
        {
            RepositoryClient = repoClient;
        }

        #region Calculate Histogram

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
            return Task.Run(async () => await CalcHistogramAsync(expression, model, attributes, count, offset)).Result;
        }

        public virtual async Task<CalcHistogramResponse> CalcHistogramAsync(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0) {

            StringBuilder sb = new StringBuilder();
            
            if (!string.IsNullOrEmpty(attributes))
                sb.Append($"&attributes={attributes}");

            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            var modelName = Enum.GetName(typeof(AcademicModelOptions), model).Replace("beta2015", "beta-2015");

            var response = await SendGetAsync($"{calcUrl}?expr={expression}&model={modelName}{sb}");

            return JsonConvert.DeserializeObject<CalcHistogramResponse>(response);
        }

        #endregion Calculate Histogram

        #region Evaluate

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
            return Task.Run(async () => await EvaluateAsync(expression, model, count, offset, attributes, orderby)).Result;
        }

        public virtual async Task<EvaluateResponse> EvaluateAsync(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "") {

            StringBuilder sb = new StringBuilder();
            
            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            if (!string.IsNullOrEmpty(orderby))
                sb.Append($"&orderby={orderby}");

            if (!string.IsNullOrEmpty(attributes))
                sb.Append($"&attributes={attributes}");

            var modelName = Enum.GetName(typeof(AcademicModelOptions), model).Replace("beta2015", "beta-2015");

            var response = await this.SendGetAsync($"{evaluateUrl}?expr={expression}&model={modelName}{sb}");

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        #endregion Evaluate

        #region Graph Search

        public virtual GraphSearchResponse GraphSearch(GraphSearchRequest request) {
            return Task.Run(async () => await GraphSearchAsync(request)).Result;
        }

        public virtual async Task<GraphSearchResponse> GraphSearchAsync(GraphSearchRequest request) {
            
            var response = await RepositoryClient.SendJsonPostAsync(ApiKey, $"{graphUrl}?mode=json", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<GraphSearchResponse>(response);
        }

        #endregion Graph Search

        #region Interpret
        
        /// <param name="query">Query entered by user. If complete is set to 1, query will be interpreted as a prefix for generating query auto-completion suggestions.</param>
        /// <param name="complete">1 means that auto-completion suggestions are generated based on the grammar and graph data.</param>
        /// <param name="count">Maximum number of interpretations to return.</param>
        /// <param name="offset">Index of the first interpretation to return. For example, count=2&offset=0 returns interpretations 0 and 1. count=2&offset=2 returns interpretations 2 and 3.</param>
        /// <param name="timeout">Timeout in milliseconds.Only interpretations found before the timeout has elapsed are returned.</param>
        /// <param name="model">Name of the model that you wish to query.Currently, the value defaults to "latest".</param>
        /// <returns></returns>
        public virtual InterpretResponse Interpret(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest)
        {
            return Task.Run(async () => await InterpretAsync(query, complete, count, offset, timeout, model)).Result;
        }

        public virtual async Task<InterpretResponse> InterpretAsync(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest)
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

            var modelName = Enum.GetName(typeof(AcademicModelOptions), model).Replace("beta2015", "beta-2015");

            var response = await SendGetAsync($"{interpretUrl}?query={query}&model={modelName}{sb}");

            return JsonConvert.DeserializeObject<InterpretResponse>(response);
        }

        #endregion Interpret

        #region Similarity
        
        public virtual double Similarity(string s1, string s2)
        {
            return Task.Run(async () => await SimilarityAsync(s1, s2)).Result;
        }

        public virtual async Task<double> SimilarityAsync(string s1, string s2)
        {
            var response = await RepositoryClient.SendEncodedFormPostAsync(ApiKey, similarityUrl, $"s1={s1}&s2={s2}");

            return JsonConvert.DeserializeObject<double>(response);
        }

        #endregion Similarity
    }
}