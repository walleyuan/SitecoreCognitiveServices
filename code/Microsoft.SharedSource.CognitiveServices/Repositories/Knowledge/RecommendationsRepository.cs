using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge
{
    public class RecommendationsRepository : IRecommendationsRepository
    {
        protected static readonly string operationsUrl = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/operations/";
        protected static readonly string modelsUrl = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/models/";
        protected static readonly string batchUrl = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/batchjobs/";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        public RecommendationsRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        #region Post

        public virtual CreateBusinessRuleResponse CreateBusinessRule(string modelId, CreateBusinessRuleRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBusinessRuleResponse>(response);
        }

        public virtual async Task<CreateBusinessRuleResponse> CreateBusinessRuleAsync(string modelId, CreateBusinessRuleRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBusinessRuleResponse>(response);
        }

        public virtual RecommendationModel CreateModel(CreateModelRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Recommendations, modelsUrl, JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        public virtual async Task<RecommendationModel> CreateModelAsync(CreateModelRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, modelsUrl, JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        public virtual CreateBuildResponse CreateBuild(string modelId, CreateBuildRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBuildResponse>(response);
        }

        public virtual async Task<CreateBuildResponse> CreateBuildAsync(string modelId, CreateBuildRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBuildResponse>(response);
        }

        public virtual void StartBatchJob(BatchJobRequest request) {
            RepositoryClient.SendJsonPost(ApiKeys.Recommendations, batchUrl, JsonConvert.SerializeObject(request));
        }

        public virtual async Task StartBatchJobAsync(BatchJobRequest request)
        {
            await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, batchUrl, JsonConvert.SerializeObject(request));
        }

        public virtual UploadCatalogFileResponse UploadCatalogFile(string modelId, string catalogDisplayName, Stream stream) {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog?catalogDisplayName={catalogDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadCatalogFileResponse>(response);
        }

        public virtual async Task<UploadCatalogFileResponse> UploadCatalogFileAsync(string modelId, string catalogDisplayName, Stream stream)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog?catalogDisplayName={catalogDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadCatalogFileResponse>(response);
        }

        public virtual void UploadUsageEvent(string modelId, UploadUsageEventRequest request) {
            RepositoryClient.SendJsonPost(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/events", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UploadUsageEventAsync(string modelId, UploadUsageEventRequest request)
        {
            await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/events", JsonConvert.SerializeObject(request));
        }

        public virtual UploadUsageFileResponse UploadUsageFile(string modelId, string usageDisplayName, Stream stream) {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage?usageDisplayName={usageDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadUsageFileResponse>(response);
        }

        public virtual async Task<UploadUsageFileResponse> UploadUsageFileAsync(string modelId, string usageDisplayName, Stream stream)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage?usageDisplayName={usageDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadUsageFileResponse>(response);
        }

        #endregion Post

        #region Delete

        public virtual void CancelOperation(string operationId) {
            RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{operationsUrl}?id={operationId}");
        }

        public virtual async Task CancelOperationAsync(string operationId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{operationsUrl}?id={operationId}");
        }

        public virtual void DeleteAllBusinessRules(string modelId) {
            RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules");
        }

        public virtual async Task DeleteAllBusinessRulesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules");
        }

        public virtual void DeleteAllUsageFiles(string modelId) {
            RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage");
        }

        public virtual async Task DeleteAllUsageFilesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage");
        }

        public virtual void DeleteBuild(string modelId, int buildId) {
            RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}");
        }

        public virtual async Task DeleteBuildAsync(string modelId, int buildId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}");
        }

        public virtual void DeleteBusinessRule(string modelId, string ruleId) {
            RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules/{ruleId}");
        }

        public virtual async Task DeleteBusinessRuleAsync(string modelId, string ruleId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules/{ruleId}");
        }

        public virtual DeleteCatalogItemsResponse DeleteCatalogItems(string modelId, bool deleteAll = false) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog?deleteAll={deleteAll}");

            return JsonConvert.DeserializeObject<DeleteCatalogItemsResponse>(response);
        }

        public virtual async Task<DeleteCatalogItemsResponse> DeleteCatalogItemsAsync(string modelId, bool deleteAll = false)
        {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog?deleteAll={deleteAll}");

            return JsonConvert.DeserializeObject<DeleteCatalogItemsResponse>(response);
        }

        public virtual void DeleteModel(string id) {
            RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{modelsUrl}{id}");
        }

        public virtual async Task DeleteModelAsync(string id)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{id}");
        }

        public virtual void DeleteUsageFile(string modelId, string fileId) {
            RepositoryClient.SendJsonDelete(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/{fileId}");
        }

        public virtual async Task DeleteUsageFileAsync(string modelId, string fileId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/{fileId}");
        }

        #endregion Delete

        #region Update

        public virtual UpdateCatalogItemsResponse UpdateCatalogItems(string modelId, Stream fileStream) {
            var response = RepositoryClient.SendOctetStreamUpdate(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog", fileStream);

            return JsonConvert.DeserializeObject<UpdateCatalogItemsResponse>(response);
        }

        public virtual async Task<UpdateCatalogItemsResponse> UpdateCatalogItemsAsync(string modelId, Stream fileStream)
        {
            var response = await RepositoryClient.SendOctetStreamUpdateAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog", fileStream);

            return JsonConvert.DeserializeObject<UpdateCatalogItemsResponse>(response);
        }

        public virtual void UpdateModel(string modelId, UpdateModelRequest request) {
            RepositoryClient.SendJsonUpdate(ApiKeys.Recommendations, $"{modelsUrl}{modelId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateModelAsync(string modelId, UpdateModelRequest request)
        {
            await RepositoryClient.SendJsonUpdateAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}", JsonConvert.SerializeObject(request));
        }

        #endregion Update

        #region Get

        public virtual string DownloadUsageFile(string modelId, string fileId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/{fileId}");

            return response;
        }

        public virtual async Task<string> DownloadUsageFileAsync(string modelId, string fileId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/{fileId}");

            return response;
        }

        public virtual GetBatchJobResponse GetAllBatchJobs(string jobId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{batchUrl}{jobId}");

            return JsonConvert.DeserializeObject<GetBatchJobResponse>(response);
        }

        public virtual async Task<GetBatchJobResponse> GetAllBatchJobsAsync(string jobId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{batchUrl}{jobId}");

            return JsonConvert.DeserializeObject<GetBatchJobResponse>(response);
        }

        public virtual GetAllBuildsResponse GetAllBuilds(string modelId, bool onlyLastRequestedBuild = false) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds?onlyLastRequestedBuild={onlyLastRequestedBuild}");

            return JsonConvert.DeserializeObject<GetAllBuildsResponse>(response);
        }

        public virtual async Task<GetAllBuildsResponse> GetAllBuildsAsync(string modelId, bool onlyLastRequestedBuild = false)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds?onlyLastRequestedBuild={onlyLastRequestedBuild}");

            return JsonConvert.DeserializeObject<GetAllBuildsResponse>(response);
        }

        public virtual GetAllBusinessRulesResponse GetAllBusinessRules(string modelId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules");

            return JsonConvert.DeserializeObject<GetAllBusinessRulesResponse>(response);
        }

        public virtual async Task<GetAllBusinessRulesResponse> GetAllBusinessRulesAsync(string modelId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules");

            return JsonConvert.DeserializeObject<GetAllBusinessRulesResponse>(response);
        }

        protected virtual string GetCatItemsQuerystring(int top, int skip, int maxpagesize)
        {
            StringBuilder sb = new StringBuilder();

            if (top > 0)
                sb.Append($"?$top={top}");

            if (skip > 0) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}$skip={skip}");
            }

            if (maxpagesize > 0) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}$maxpagesize={maxpagesize}");
            }

            return sb.ToString();
        }

        public virtual GetAllCatalogItemsResponse GetAllCatalogItems(string modelId, int top = 0, int skip = 0, int maxpagesize = 0) {
            var qs = GetCatItemsQuerystring(top, skip, maxpagesize);
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog{qs}");

            return JsonConvert.DeserializeObject<GetAllCatalogItemsResponse>(response);
        }

        public virtual async Task<GetAllCatalogItemsResponse> GetAllCatalogItemsAsync(string modelId, int top = 0, int skip = 0, int maxpagesize = 0)
        {
            var qs = GetCatItemsQuerystring(top, skip, maxpagesize);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog{qs}");

            return JsonConvert.DeserializeObject<GetAllCatalogItemsResponse>(response);
        }

        public virtual GetAllModelsResponse GetAllModels() {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, modelsUrl);

            return JsonConvert.DeserializeObject<GetAllModelsResponse>(response);
        }

        public virtual async Task<GetAllModelsResponse> GetAllModelsAsync()
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, modelsUrl);

            return JsonConvert.DeserializeObject<GetAllModelsResponse>(response);
        }

        public virtual Build GetBuildById(string modelId, int buildId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}");

            return JsonConvert.DeserializeObject<Build>(response);
        }

        public virtual async Task<Build> GetBuildByIdAsync(string modelId, int buildId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}");

            return JsonConvert.DeserializeObject<Build>(response);
        }

        public virtual BuildDataStatisticsResponse GetBuildDataStatistics(string modelId, int buildId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/datastatistics");

            return JsonConvert.DeserializeObject<BuildDataStatisticsResponse>(response);
        }

        public virtual async Task<BuildDataStatisticsResponse> GetBuildDataStatisticsAsync(string modelId, int buildId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/datastatistics");

            return JsonConvert.DeserializeObject<BuildDataStatisticsResponse>(response);
        }
        
        public virtual BuildMetricsResponse GetBuildMetrics(string modelId, int buildId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/metrics");

            return JsonConvert.DeserializeObject<BuildMetricsResponse>(response);
        }

        public virtual async Task<BuildMetricsResponse> GetBuildMetricsAsync(string modelId, int buildId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/metrics");

            return JsonConvert.DeserializeObject<BuildMetricsResponse>(response);
        }

        public virtual BusinessRule GetBusinessRule(string modelId, string ruleId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules/{ruleId}");

            return JsonConvert.DeserializeObject<BusinessRule>(response);
        }

        public virtual async Task<BusinessRule> GetBusinessRuleAsync(string modelId, string ruleId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules/{ruleId}");

            return JsonConvert.DeserializeObject<BusinessRule>(response);
        }

        protected virtual string GetItemToItemQuerystring(int buildId)
        {
            StringBuilder sb = new StringBuilder();

            if (buildId > 0)
                sb.Append($"&buildId={buildId}");

            return sb.ToString();
        }

        public virtual ItemRecommendationResponse GetItemToItemRecommendations(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0) {
            var qs = GetItemToItemQuerystring(buildId);
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/recommend/item?itemIds={string.Join(",", itemIds)}&numberOfResults={numberOfResults}&minimalScore={minimalScore}{qs}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public virtual async Task<ItemRecommendationResponse> GetItemToItemRecommendationsAsync(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0)
        {
            var qs = GetItemToItemQuerystring(buildId);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/recommend/item?itemIds={string.Join(",", itemIds)}&numberOfResults={numberOfResults}&minimalScore={minimalScore}{qs}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public virtual RecommendationModel GetModel(string modelId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}");

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        public virtual async Task<RecommendationModel> GetModelAsync(string modelId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}");

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        protected virtual string GetModelFeaturesQuerystring(int rankBuildId)
        {
            StringBuilder sb = new StringBuilder();

            if (rankBuildId > 0)
                sb.Append($"?rankBuildId={rankBuildId}");

            return sb.ToString();
        }

        public virtual ModelFeatureResponse GetModelFeatures(string modelId, int rankBuildId = 0) {
            var qs = GetModelFeaturesQuerystring(rankBuildId);
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/features{qs}");

            return JsonConvert.DeserializeObject<ModelFeatureResponse>(response);
        }

        public virtual async Task<ModelFeatureResponse> GetModelFeaturesAsync(string modelId, int rankBuildId = 0)
        {
            var qs = GetModelFeaturesQuerystring(rankBuildId);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/features{qs}");

            return JsonConvert.DeserializeObject<ModelFeatureResponse>(response);
        }

        public virtual GetOperationStatusResponse GetOperationStatus(string operationId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{operationsUrl}{operationId}");

            return JsonConvert.DeserializeObject<GetOperationStatusResponse>(response);
        }

        public virtual async Task<GetOperationStatusResponse> GetOperationStatusAsync(string operationId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{operationsUrl}{operationId}");

            return JsonConvert.DeserializeObject<GetOperationStatusResponse>(response);
        }

        protected virtual string GetCatItemsQuerystring(List<string> ids, string searchTerm)
        {
            StringBuilder sb = new StringBuilder();

            if (ids != null && ids.Any())
                sb.Append($"?ids={string.Join(",", ids)}");

            if (!string.IsNullOrEmpty(searchTerm)) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}searchTerm={searchTerm}");
            }

            return sb.ToString();
        }

        public virtual SearchCatalogItemsResponse GetSpecificCatalogItemsBySearchTerm(string modelId, List<string> ids = null, string searchTerm = "") {
            var qs = GetCatItemsQuerystring(ids, searchTerm);
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog/items{qs}");

            return JsonConvert.DeserializeObject<SearchCatalogItemsResponse>(response);
        }

        public virtual async Task<SearchCatalogItemsResponse> GetSpecificCatalogItemsBySearchTermAsync(string modelId, List<string> ids = null, string searchTerm = "")
        {
            var qs = GetCatItemsQuerystring(ids, searchTerm);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog/items{qs}");

            return JsonConvert.DeserializeObject<SearchCatalogItemsResponse>(response);
        }

        public virtual BuildUsageStatisticsResponse GetUsageStatisticsForABuild(string modelId, int buildId, string interval, List<string> eventTypes) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/usagestatistics?interval={interval}&eventTypes={string.Join(",", eventTypes)}");

            return JsonConvert.DeserializeObject<BuildUsageStatisticsResponse>(response);
        }

        public virtual async Task<BuildUsageStatisticsResponse> GetUsageStatisticsForABuildAsync(string modelId, int buildId, string interval, List<string> eventTypes)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/usagestatistics?interval={interval}&eventTypes={string.Join(",",eventTypes)}");

            return JsonConvert.DeserializeObject<BuildUsageStatisticsResponse>(response);
        }

        public virtual ModelUsageStatisticsResponse GetUsageStatisticsForAModel(string modelId, string interval, List<string> eventTypes) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/usagestatistics?interval={interval}&eventTypes={string.Join(",", eventTypes)}");

            return JsonConvert.DeserializeObject<ModelUsageStatisticsResponse>(response);
        }

        public virtual async Task<ModelUsageStatisticsResponse> GetUsageStatisticsForAModelAsync(string modelId, string interval, List<string> eventTypes)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/usagestatistics?interval={interval}&eventTypes={string.Join(",", eventTypes)}");

            return JsonConvert.DeserializeObject<ModelUsageStatisticsResponse>(response);
        }

        protected virtual string GetUserToItemQuerystring(List<string> itemIds, bool includeMetadata, int buildId)
        {
            StringBuilder sb = new StringBuilder();

            if (itemIds != null && itemIds.Any())
                sb.Append($"&itemIds={string.Join(",", itemIds)}");

            if (includeMetadata)
                sb.Append($"&includeMetadata={includeMetadata}");

            if (buildId > 0)
                sb.Append($"&buildId={buildId}");

            return sb.ToString();
        }

        public virtual ItemRecommendationResponse GetUserToItemRecommendations(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0) {
            var qs = GetUserToItemQuerystring(itemIds, includeMetadata, buildId);
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/recommend/user?userId={userId}&numberOfResults={numberOfResults}{qs}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public virtual async Task<ItemRecommendationResponse> GetUserToItemRecommendationsAsync(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0)
        {
            var qs = GetUserToItemQuerystring(itemIds, includeMetadata, buildId);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/recommend/user?userId={userId}&numberOfResults={numberOfResults}{qs}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public virtual List<UsageFile> ListUsageFiles(string modelId) {
            var response = RepositoryClient.SendGet(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage");

            return JsonConvert.DeserializeObject<List<UsageFile>>(response);
        }

        public virtual async Task<List<UsageFile>> ListUsageFilesAsync(string modelId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage");

            return JsonConvert.DeserializeObject<List<UsageFile>>(response);
        }

        #endregion Get
    }
}