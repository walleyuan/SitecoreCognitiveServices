using System.Collections.Generic;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge
{
    public interface IRecommendationsService
    {
        CreateBusinessRuleResponse CreateBusinessRule(string modelId, CreateBusinessRuleRequest request);
        RecommendationModel CreateModel(CreateModelRequest request);
        CreateBuildResponse CreateBuild(string modelId, CreateBuildRequest request);
        void StartBatchJob(BatchJobRequest request);
        UploadCatalogFileResponse UploadCatalogFile(string modelId, string catalogDisplayName, Stream stream);
        void UploadUsageEvent(string modelId, UploadUsageEventRequest request);
        UploadUsageFileResponse UploadUsageFile(string modelId, string usageDisplayName, Stream stream);
        void CancelOperation(string operationId);
        void DeleteAllBusinessRules(string modelId);
        void DeleteAllUsageFiles(string modelId);
        void DeleteBuild(string modelId, int buildId);
        void DeleteBusinessRule(string modelId, string ruleId);
        DeleteCatalogItemsResponse DeleteCatalogItems(string modelId, bool deleteAll = false);
        void DeleteModel(string id);
        void DeleteUsageFile(string modelId, string fileId);
        UpdateCatalogItemsResponse UpdateCatalogItems(string modelId, Stream fileStream);
        void UpdateModel(string modelId, UpdateModelRequest request);
        string DownloadUsageFile(string modelId, string fileId);
        GetBatchJobResponse GetAllBatchJobs(string jobId);
        GetAllBuildsResponse GetAllBuilds(string modelId, bool onlyLastRequestedBuild = false);
        GetAllBusinessRulesResponse GetAllBusinessRules(string modelId);
        GetAllCatalogItemsResponse GetAllCatalogItems(string modelId, int top = 0, int skip = 0, int maxpagesize = 0);
        GetAllModelsResponse GetAllModels();
        Build GetBuildById(string modelId, int buildId);
        BuildDataStatisticsResponse GetBuildDataStatistics(string modelId, int buildId);
        BuildMetricsResponse GetBuildMetrics(string modelId, int buildId);
        BusinessRule GetBusinessRule(string modelId, string ruleId);
        ItemRecommendationResponse GetItemToItemRecommendations(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0);
        RecommendationModel GetModel(string modelId);
        ModelFeatureResponse GetModelFeatures(string modelId, int rankBuildId = 0);
        GetOperationStatusResponse GetOperationStatus(string operationId);
        SearchCatalogItemsResponse GetSpecificCatalogItemsBySearchTerm(string modelId, List<string> ids = null, string searchTerm = "");
        BuildUsageStatisticsResponse GetUsageStatisticsForABuild(string modelId, int buildId, string interval, List<string> eventTypes);
        ModelUsageStatisticsResponse GetUsageStatisticsForAModel(string modelId, string interval, List<string> eventTypes);
        ItemRecommendationResponse GetUserToItemRecommendations(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0);
        List<UsageFile> ListUsageFiles(string modelId);

    }
}