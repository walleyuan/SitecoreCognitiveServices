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

        public virtual async Task<CreateBusinessRuleResponse> CreateBusinessRuleAsync(string modelId, CreateBusinessRuleRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBusinessRuleResponse>(response);
        }
        
        public virtual async Task<RecommendationModel> CreateModelAsync(CreateModelRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, modelsUrl, JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        public virtual async Task<CreateBuildResponse> CreateBuildAsync(string modelId, CreateBuildRequest request)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBuildResponse>(response);
        }

        public virtual async Task StartBatchJobAsync(BatchJobRequest request)
        {
            await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, batchUrl, JsonConvert.SerializeObject(request));
        }

        public virtual async Task<UploadCatalogFileResponse> UploadCatalogFileAsync(string modelId, string catalogDisplayName, Stream stream)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog?catalogDisplayName={catalogDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadCatalogFileResponse>(response);
        }

        public virtual async Task UploadUsageEventAsync(string modelId, UploadUsageEventRequest request)
        {
            await RepositoryClient.SendJsonPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/events", JsonConvert.SerializeObject(request));
        }

        public virtual async Task<UploadUsageFileResponse> UploadUsageFileAsync(string modelId, string usageDisplayName, Stream stream)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage?usageDisplayName={usageDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadUsageFileResponse>(response);
        }

        #endregion Post

        #region Delete
        
        public virtual async Task CancelOperationAsync(string operationId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{operationsUrl}?id={operationId}");
        }

        public virtual async Task DeleteAllBusinessRulesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules");
        }

        public virtual async Task DeleteAllUsageFilesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage");
        }

        public virtual async Task DeleteBuildAsync(string modelId, int buildId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}");
        }

        public virtual async Task DeleteBusinessRuleAsync(string modelId, string ruleId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules/{ruleId}");
        }

        public virtual async Task<DeleteCatalogItemsResponse> DeleteCatalogItemsAsync(string modelId, bool deleteAll = false)
        {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog?deleteAll={deleteAll}");

            return JsonConvert.DeserializeObject<DeleteCatalogItemsResponse>(response);
        }

        public virtual async Task DeleteModelAsync(string id)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{id}");
        }

        public virtual async Task DeleteUsageFileAsync(string modelId, string fileId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/{fileId}");
        }

        #endregion Delete

        #region Update

        public virtual async Task<UpdateCatalogItemsResponse> UpdateCatalogItemsAsync(string modelId, Stream fileStream)
        {
            var response = await RepositoryClient.SendOctetStreamUpdateAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog", fileStream);

            return JsonConvert.DeserializeObject<UpdateCatalogItemsResponse>(response);
        }

        public virtual async Task UpdateModelAsync(string modelId, UpdateModelRequest request)
        {
            await RepositoryClient.SendJsonUpdateAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}", JsonConvert.SerializeObject(request));
        }

        #endregion Update

        #region Get

        public virtual async Task<string> DownloadUsageFileAsync(string modelId, string fileId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage/{fileId}");

            return response;
        }

        public virtual async Task<GetBatchJobResponse> GetAllBatchJobsAsync(string jobId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{batchUrl}{jobId}");

            return JsonConvert.DeserializeObject<GetBatchJobResponse>(response);
        }

        public virtual async Task<GetAllBuildsResponse> GetAllBuildsAsync(string modelId, bool onlyLastRequestedBuild = false)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds?onlyLastRequestedBuild={onlyLastRequestedBuild}");

            return JsonConvert.DeserializeObject<GetAllBuildsResponse>(response);
        }

        public virtual async Task<GetAllBusinessRulesResponse> GetAllBusinessRulesAsync(string modelId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules");

            return JsonConvert.DeserializeObject<GetAllBusinessRulesResponse>(response);
        }

        public virtual async Task<GetAllCatalogItemsResponse> GetAllCatalogItemsAsync(string modelId, int top = 0, int skip = 0, int maxpagesize = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (top > 0)
                sb.Append($"?$top={top}");

            if (skip > 0)
            {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}$skip={skip}");
            }
                
            if (maxpagesize > 0)
            {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}$maxpagesize={maxpagesize}");
            }

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog{sb}");

            return JsonConvert.DeserializeObject<GetAllCatalogItemsResponse>(response);
        }

        public virtual async Task<GetAllModelsResponse> GetAllModelsAsync()
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, modelsUrl);

            return JsonConvert.DeserializeObject<GetAllModelsResponse>(response);
        }

        public virtual async Task<Build> GetBuildByIdAsync(string modelId, int buildId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}");

            return JsonConvert.DeserializeObject<Build>(response);
        }

        public virtual async Task<BuildDataStatisticsResponse> GetBuildDataStatisticsAsync(string modelId, int buildId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/datastatistics");

            return JsonConvert.DeserializeObject<BuildDataStatisticsResponse>(response);
        }

        public virtual async Task<BuildMetricsResponse> GetBuildMetricsAsync(string modelId, int buildId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/metrics");

            return JsonConvert.DeserializeObject<BuildMetricsResponse>(response);
        }

        public virtual async Task<BusinessRule> GetBusinessRuleAsync(string modelId, string ruleId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/rules/{ruleId}");

            return JsonConvert.DeserializeObject<BusinessRule>(response);
        }
        
        public virtual async Task<ItemRecommendationResponse> GetItemToItemRecommendationsAsync(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (buildId > 0)
                sb.Append($"&buildId={buildId}");

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/recommend/item?itemIds={string.Join(",", itemIds)}&numberOfResults={numberOfResults}&minimalScore={minimalScore}{sb}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public virtual async Task<RecommendationModel> GetModelAsync(string modelId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}");

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        public virtual async Task<ModelFeatureResponse> GetModelFeaturesAsync(string modelId, int rankBuildId = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (rankBuildId > 0)
                sb.Append($"?rankBuildId={rankBuildId}");

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/features{sb}");

            return JsonConvert.DeserializeObject<ModelFeatureResponse>(response);
        }

        public virtual async Task<GetOperationStatusResponse> GetOperationStatusAsync(string operationId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{operationsUrl}{operationId}");

            return JsonConvert.DeserializeObject<GetOperationStatusResponse>(response);
        }

        public virtual async Task<SearchCatalogItemsResponse> GetSpecificCatalogItemsBySearchTermAsync(string modelId, List<string> ids = null, string searchTerm = "") 
        {
            StringBuilder sb = new StringBuilder();

            if (ids != null && ids.Any())
                sb.Append($"?ids={string.Join(",", ids)}");

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}searchTerm={searchTerm}");
            }

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/catalog/items{sb}");

            return JsonConvert.DeserializeObject<SearchCatalogItemsResponse>(response);
        }

        public virtual async Task<BuildUsageStatisticsResponse> GetUsageStatisticsForABuildAsync(string modelId, int buildId, string interval, List<string> eventTypes)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/{buildId}/usagestatistics?interval={interval}&eventTypes={string.Join(",",eventTypes)}");

            return JsonConvert.DeserializeObject<BuildUsageStatisticsResponse>(response);
        }

        public virtual async Task<ModelUsageStatisticsResponse> GetUsageStatisticsForAModelAsync(string modelId, string interval, List<string> eventTypes)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/builds/usagestatistics?interval={interval}&eventTypes={string.Join(",", eventTypes)}");

            return JsonConvert.DeserializeObject<ModelUsageStatisticsResponse>(response);
        }

        public virtual async Task<ItemRecommendationResponse> GetUserToItemRecommendationsAsync(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (itemIds != null && itemIds.Any())
                sb.Append($"&itemIds={string.Join(",", itemIds)}");
            
            if(includeMetadata)
                sb.Append($"&includeMetadata={includeMetadata}");

            if (buildId > 0)
                sb.Append($"&buildId={buildId}");

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/recommend/user?userId={userId}&numberOfResults={numberOfResults}{sb}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public virtual async Task<List<UsageFile>> ListUsageFilesAsync(string modelId)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Recommendations, $"{modelsUrl}{modelId}/usage");

            return JsonConvert.DeserializeObject<List<UsageFile>>(response);
        }

        #endregion Get
    }
}