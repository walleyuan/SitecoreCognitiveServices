using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Academic;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge {
    public class AcademicSearchRepository : TextClient, IAcademicSearchRepository
    {
        public static readonly string calcUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/calchistogram";
        public static readonly string evaluateUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/evaluate[?expr][&model][&count][&offset][&orderby][&attributes]";
        public static readonly string graphUrl = "https://westus.api.cognitive.microsoft.com/academic/v1.0/graph/search[?mode]";

        public AcademicSearchRepository(
            IApiKeys apiKeys)
            : base(apiKeys.Academic)
        {
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
        public HistogramResult CalcHistogram(string expression, AcademicHistogramModelOptions model, string attributes = "", int count = 10, int offset = 0)
        {
            return Task.Run(async () => await CalcHistogramAsync(expression, model, attributes, count, offset)).Result;
        }

        public async Task<HistogramResult> CalcHistogramAsync(string expression, AcademicHistogramModelOptions model, string attributes = "", int count = 10, int offset = 0) {

            StringBuilder sb = new StringBuilder();
            
            if (!string.IsNullOrEmpty(attributes))
                sb.Append($"&attributes={attributes}");

            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            var modelName = Enum.GetName(typeof(AcademicHistogramModelOptions), model).Replace("beta2015", "beta-2015");

            var response = await this.SendGetAsync($"{calcUrl}?expr={expression}&model={modelName}{sb}");

            return JsonConvert.DeserializeObject<HistogramResult>(response);
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
        public EvaluateResponse Evaluate(string expression, AcademicHistogramModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "") {
            return Task.Run(async () => await EvaluateAsync(expression, model, count, offset, attributes, orderby)).Result;
        }

        public async Task<EvaluateResponse> EvaluateAsync(string expression, AcademicHistogramModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "") {

            StringBuilder sb = new StringBuilder();
            
            if (count > 0)
                sb.Append($"&count={count}");

            if (offset > 0)
                sb.Append($"&offset={offset}");

            if (!string.IsNullOrEmpty(orderby))
                sb.Append($"&orderby={orderby}");

            if (!string.IsNullOrEmpty(attributes))
                sb.Append($"&attributes={attributes}");

            var modelName = Enum.GetName(typeof(AcademicHistogramModelOptions), model).Replace("beta2015", "beta-2015");

            var response = await this.SendGetAsync($"{evaluateUrl}?expr={expression}&model={modelName}{sb}");

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        #endregion Evaluate

        #region Graph Search

        public GraphSearchResponse GraphSearch(AcademicGraphModeOptions mode, GraphSearchRequest request) {
            return Task.Run(async () => await GraphSearchAsync(mode, request)).Result;
        }

        public async Task<GraphSearchResponse> GraphSearchAsync(AcademicGraphModeOptions mode, GraphSearchRequest request) {

            var modeName = Enum.GetName(typeof(AcademicGraphModeOptions), mode);

            string data = (mode == AcademicGraphModeOptions.json)
                ? JsonConvert.SerializeObject(request)
                : GetLambda(request);

            var response = await SendPostAsync($"{graphUrl}?mode={modeName}", data);

            return JsonConvert.DeserializeObject<GraphSearchResponse>(response);
        }

        protected string GetLambda(GraphSearchRequest request)
        {
            return $"MAG.StartFrom(@\"{{ type : \"{request.Author.Return.Type}\", match : {{ Name : \"{request.Author.Return.Name}\" }} }}\").FollowEdge(\"PaperIDs\").VisitNode(Action.Return);";
        }

        #endregion Graph Search

    }
}