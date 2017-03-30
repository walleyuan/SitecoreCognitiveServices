using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge {
    public interface IRecommendationsRepository
    {
        Task<CreateBusinessRuleResponse> CreateBusinessRuleAsync(string modelId, CreateBusinessRuleRequest request);
        Task<RecommendationModel> CreateModelAsync(CreateModelRequest request);
        Task<CreateBuildResponse> CreateBuildAsync(string modelId, CreateBuildRequest request);
        Task StartBatchJobAsync(BatchJobRequest request);
        Task<UploadCatalogFileResponse> UploadCatalogFileAsync(string modelId, string catalogDisplayName, Stream stream);
        Task UploadUsageEventAsync(string modelId, UploadUsageEventRequest request);
        Task<UploadUsageFileResponse> UploadUsageFileAsync(string modelId, string usageDisplayName, Stream stream);
        Task CancelOperationAsync(string operationId);
        Task DeleteAllBusinessRulesAsync(string modelId);
        Task DeleteAllUsageFilesAsync(string modelId);
        Task DeleteBuildAsync(string modelId, int buildId);
        Task DeleteBusinessRuleAsync(string modelId, string ruleId);
        Task<DeleteCatalogItemsResponse> DeleteCatalogItemsAsync(string modelId, bool deleteAll = false);
        Task DeleteModelAsync(string id);
        Task DeleteUsageFileAsync(string modelId, string fileId);
        Task<UpdateCatalogItemsResponse> UpdateCatalogItemsAsync(string modelId, Stream fileStream);
        Task UpdateModelAsync(string modelId, UpdateModelRequest request);
        Task<string> DownloadUsageFileAsync(string modelId, string fileId);
        Task<GetBatchJobResponse> GetAllBatchJobsAsync(string jobId);
        Task<GetAllBuildsResponse> GetAllBuildsAsync(string modelId, bool onlyLastRequestedBuild = false);
        Task<GetAllBusinessRulesResponse> GetAllBusinessRulesAsync(string modelId);
        Task<GetAllCatalogItemsResponse> GetAllCatalogItemsAsync(string modelId, int top = 0, int skip = 0, int maxpagesize = 0);
        Task<GetAllModelsResponse> GetAllModelsAsync();
        Task<Build> GetBuildByIdAsync(string modelId, int buildId);
        Task<BuildDataStatisticsResponse> GetBuildDataStatisticsAsync(string modelId, int buildId);
        Task<BuildMetricsResponse> GetBuildMetricsAsync(string modelId, int buildId);
        Task<BusinessRule> GetBusinessRuleAsync(string modelId, string ruleId);
        Task<ItemRecommendationResponse> GetItemToItemRecommendationsAsync(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0);
        Task<RecommendationModel> GetModelAsync(string modelId);
        Task<ModelFeatureResponse> GetModelFeaturesAsync(string modelId, int rankBuildId = 0);
        Task<GetOperationStatusResponse> GetOperationStatusAsync(string operationId);
        Task<SearchCatalogItemsResponse> GetSpecificCatalogItemsBySearchTermAsync(string modelId, List<string> ids = null, string searchTerm = "");
        Task<BuildUsageStatisticsResponse> GetUsageStatisticsForABuildAsync(string modelId, int buildId, string interval, List<string> eventTypes);
        Task<ModelUsageStatisticsResponse> GetUsageStatisticsForAModelAsync(string modelId, string interval, List<string> eventTypes);
        Task<ItemRecommendationResponse> GetUserToItemRecommendationsAsync(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0);
        Task<List<UsageFile>> ListUsageFilesAsync(string modelId);
    }
}