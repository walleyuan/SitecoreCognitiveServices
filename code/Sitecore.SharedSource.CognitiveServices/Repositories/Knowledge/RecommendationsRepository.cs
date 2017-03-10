using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge
{
    public class RecommendationsRepository : TextClient, IRecommendationsRepository
    {
        protected static readonly string operationsUrl = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/operations/";
        protected static readonly string modelsUrl = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/models/";
        protected static readonly string batchUrl = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/batchjobs/";

        protected readonly IRepositoryClient RepositoryClient;

        public RecommendationsRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
            : base(apiKeys.Recommendations)
        {
            RepositoryClient = repoClient;
        }

        #region Post

        public async Task<CreateBusinessRuleResponse> CreateBusinessRuleAsync(string modelId, CreateBusinessRuleRequest request)
        {
            var response = await SendPostAsync($"{modelsUrl}{modelId}/rules", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBusinessRuleResponse>(response);
        }
        
        public async Task<RecommendationModel> CreateModelAsync(CreateModelRequest request)
        {
            var response = await SendPostAsync(modelsUrl, JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        public async Task<CreateBuildResponse> CreateBuildAsync(string modelId, CreateBuildRequest request)
        {
            var response = await SendPostAsync($"{modelsUrl}{modelId}/builds", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBuildResponse>(response);
        }

        public async Task StartBatchJobAsync(BatchJobRequest request)
        {
            await SendPostAsync(batchUrl, JsonConvert.SerializeObject(request));
        }

        public async Task<UploadCatalogFileResponse> UploadCatalogFileAsync(string modelId, string catalogDisplayName, Stream stream)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKey, $"{modelsUrl}{modelId}/catalog?catalogDisplayName={catalogDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadCatalogFileResponse>(response);
        }

        public async Task UploadUsageEventAsync(string modelId, UploadUsageEventRequest request)
        {
            await SendPostAsync($"{modelsUrl}{modelId}/usage/events", JsonConvert.SerializeObject(request));
        }

        public async Task<UploadUsageFileResponse> UploadUsageFileAsync(string modelId, string usageDisplayName, Stream stream)
        {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKey, $"{modelsUrl}{modelId}/usage?usageDisplayName={usageDisplayName}", stream);

            return JsonConvert.DeserializeObject<UploadUsageFileResponse>(response);
        }

        #endregion Post

        #region Delete
        
        public async Task CancelOperationAsync(string operationId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{operationsUrl}?id={operationId}");
        }

        public async Task DeleteAllBusinessRulesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{modelsUrl}{modelId}/rules");
        }

        public async Task DeleteAllUsageFilesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{modelsUrl}{modelId}/usage");
        }

        public async Task DeleteBuildAsync(string modelId, int buildId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{modelsUrl}{modelId}/builds/{buildId}");
        }

        public async Task DeleteBusinessRuleAsync(string modelId, string ruleId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{modelsUrl}{modelId}/rules/{ruleId}");
        }

        public async Task<DeleteCatalogItemsResponse> DeleteCatalogItemsAsync(string modelId, bool deleteAll = false)
        {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{modelsUrl}{modelId}/catalog?deleteAll={deleteAll}");

            return JsonConvert.DeserializeObject<DeleteCatalogItemsResponse>(response);
        }

        public async Task DeleteModelAsync(string id)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{modelsUrl}{id}");
        }

        public async Task DeleteUsageFileAsync(string modelId, string fileId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{modelsUrl}{modelId}/usage/{fileId}");
        }

        #endregion Delete

        #region Update

        public async Task<UpdateCatalogItemsResponse> UpdateCatalogItemsAsync(string modelId, Stream fileStream)
        {
            var response = await RepositoryClient.SendOctetStreamUpdateAsync(ApiKey, $"{modelsUrl}{modelId}/catalog", fileStream);

            return JsonConvert.DeserializeObject<UpdateCatalogItemsResponse>(response);
        }

        public async Task UpdateModelAsync(string modelId, UpdateModelRequest request)
        {
            await RepositoryClient.SendJsonUpdateAsync(ApiKey, $"{modelsUrl}{modelId}", JsonConvert.SerializeObject(request));
        }

        #endregion Update

        #region Get

        public async Task<string> DownloadUsageFileAsync(string modelId, string fileId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/usage/{fileId}");

            return response;
        }

        public async Task<GetBatchJobResponse> GetAllBatchJobsAsync(string jobId)
        {
            var response = await SendGetAsync($"{batchUrl}{jobId}");

            return JsonConvert.DeserializeObject<GetBatchJobResponse>(response);
        }

        public async Task<GetAllBuildsResponse> GetAllBuildsAsync(string modelId, bool onlyLastRequestedBuild = false)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/builds?onlyLastRequestedBuild={onlyLastRequestedBuild}");

            return JsonConvert.DeserializeObject<GetAllBuildsResponse>(response);
        }

        public async Task<GetAllBusinessRulesResponse> GetAllBusinessRulesAsync(string modelId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/rules");

            return JsonConvert.DeserializeObject<GetAllBusinessRulesResponse>(response);
        }

        public async Task<GetAllCatalogItemsResponse> GetAllCatalogItemsAsync(string modelId, int top = 0, int skip = 0, int maxpagesize = 0)
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

            var response = await SendGetAsync($"{modelsUrl}{modelId}/catalog{sb}");

            return JsonConvert.DeserializeObject<GetAllCatalogItemsResponse>(response);
        }

        public async Task<GetAllModelsResponse> GetAllModelsAsync()
        {
            var response = await SendGetAsync(modelsUrl);

            return JsonConvert.DeserializeObject<GetAllModelsResponse>(response);
        }

        public async Task<Build> GetBuildByIdAsync(string modelId, int buildId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/builds/{buildId}");

            return JsonConvert.DeserializeObject<Build>(response);
        }

        public async Task<BuildDataStatisticsResponse> GetBuildDataStatisticsAsync(string modelId, int buildId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/builds/{buildId}/datastatistics");

            return JsonConvert.DeserializeObject<BuildDataStatisticsResponse>(response);
        }

        public async Task<BuildMetricsResponse> GetBuildMetricsAsync(string modelId, int buildId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/builds/{buildId}/metrics");

            return JsonConvert.DeserializeObject<BuildMetricsResponse>(response);
        }

        public async Task<BusinessRule> GetBusinessRuleAsync(string modelId, string ruleId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/rules/{ruleId}");

            return JsonConvert.DeserializeObject<BusinessRule>(response);
        }
        
        public async Task<ItemRecommendationResponse> GetItemToItemRecommendationsAsync(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (buildId > 0)
                sb.Append($"&buildId={buildId}");

            var response = await SendGetAsync($"{modelsUrl}{modelId}/recommend/item?itemIds={string.Join(",", itemIds)}&numberOfResults={numberOfResults}&minimalScore={minimalScore}{sb}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public async Task<RecommendationModel> GetModelAsync(string modelId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}");

            return JsonConvert.DeserializeObject<RecommendationModel>(response);
        }

        public async Task<ModelFeatureResponse> GetModelFeaturesAsync(string modelId, int rankBuildId = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (rankBuildId > 0)
                sb.Append($"?rankBuildId={rankBuildId}");

            var response = await SendGetAsync($"{modelsUrl}{modelId}/features{sb}");

            return JsonConvert.DeserializeObject<ModelFeatureResponse>(response);
        }

        public async Task<GetOperationStatusResponse> GetOperationStatusAsync(string operationId)
        {
            var response = await SendGetAsync($"{operationsUrl}{operationId}");

            return JsonConvert.DeserializeObject<GetOperationStatusResponse>(response);
        }

        public async Task<SearchCatalogItemsResponse> GetSpecificCatalogItemsBySearchTermAsync(string modelId, List<string> ids = null, string searchTerm = "") 
        {
            StringBuilder sb = new StringBuilder();

            if (ids != null && ids.Any())
                sb.Append($"?ids={string.Join(",", ids)}");

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}searchTerm={searchTerm}");
            }

            var response = await SendGetAsync($"{modelsUrl}{modelId}/catalog/items{sb}");

            return JsonConvert.DeserializeObject<SearchCatalogItemsResponse>(response);
        }

        public async Task<BuildUsageStatisticsResponse> GetUsageStatisticsForABuildAsync(string modelId, int buildId, string interval, List<string> eventTypes)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/builds/{buildId}/usagestatistics?interval={interval}&eventTypes={string.Join(",",eventTypes)}");

            return JsonConvert.DeserializeObject<BuildUsageStatisticsResponse>(response);
        }

        public async Task<ModelUsageStatisticsResponse> GetUsageStatisticsForAModelAsync(string modelId, string interval, List<string> eventTypes)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/builds/usagestatistics?interval={interval}&eventTypes={string.Join(",", eventTypes)}");

            return JsonConvert.DeserializeObject<ModelUsageStatisticsResponse>(response);
        }

        public async Task<ItemRecommendationResponse> GetUserToItemRecommendationsAsync(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (itemIds != null && itemIds.Any())
                sb.Append($"&itemIds={string.Join(",", itemIds)}");
            
            if(includeMetadata)
                sb.Append($"&includeMetadata={includeMetadata}");

            if (buildId > 0)
                sb.Append($"&buildId={buildId}");

            var response = await SendGetAsync($"{modelsUrl}{modelId}/recommend/user?userId={userId}&numberOfResults={numberOfResults}{sb}");

            return JsonConvert.DeserializeObject<ItemRecommendationResponse>(response);
        }

        public async Task<List<UsageFile>> ListUsageFilesAsync(string modelId)
        {
            var response = await SendGetAsync($"{modelsUrl}{modelId}/usage");

            return JsonConvert.DeserializeObject<List<UsageFile>>(response);
        }

        #endregion Get
    }
}