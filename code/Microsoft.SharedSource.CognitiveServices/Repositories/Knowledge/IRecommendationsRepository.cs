﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge {
    public interface IRecommendationsRepository
    {
        CreateBusinessRuleResponse CreateBusinessRule(string modelId, CreateBusinessRuleRequest request);
        Task<CreateBusinessRuleResponse> CreateBusinessRuleAsync(string modelId, CreateBusinessRuleRequest request);
        RecommendationModel CreateModel(CreateModelRequest request);
        Task<RecommendationModel> CreateModelAsync(CreateModelRequest request);
        CreateBuildResponse CreateBuild(string modelId, CreateBuildRequest request);
        Task<CreateBuildResponse> CreateBuildAsync(string modelId, CreateBuildRequest request);
        void StartBatchJob(BatchJobRequest request);
        Task StartBatchJobAsync(BatchJobRequest request);
        UploadCatalogFileResponse UploadCatalogFile(string modelId, string catalogDisplayName, Stream stream);
        Task<UploadCatalogFileResponse> UploadCatalogFileAsync(string modelId, string catalogDisplayName, Stream stream);
        void UploadUsageEvent(string modelId, UploadUsageEventRequest request);
        Task UploadUsageEventAsync(string modelId, UploadUsageEventRequest request);
        UploadUsageFileResponse UploadUsageFile(string modelId, string usageDisplayName, Stream stream);
        Task<UploadUsageFileResponse> UploadUsageFileAsync(string modelId, string usageDisplayName, Stream stream);
        void CancelOperation(string operationId);
        Task CancelOperationAsync(string operationId);
        void DeleteAllBusinessRules(string modelId);
        Task DeleteAllBusinessRulesAsync(string modelId);
        void DeleteAllUsageFiles(string modelId);
        Task DeleteAllUsageFilesAsync(string modelId);
        void DeleteBuild(string modelId, int buildId);
        Task DeleteBuildAsync(string modelId, int buildId);
        void DeleteBusinessRule(string modelId, string ruleId);
        Task DeleteBusinessRuleAsync(string modelId, string ruleId);
        DeleteCatalogItemsResponse DeleteCatalogItems(string modelId, bool deleteAll = false);
        Task<DeleteCatalogItemsResponse> DeleteCatalogItemsAsync(string modelId, bool deleteAll = false);
        void DeleteModel(string id);
        Task DeleteModelAsync(string id);
        void DeleteUsageFile(string modelId, string fileId);
        Task DeleteUsageFileAsync(string modelId, string fileId);
        UpdateCatalogItemsResponse UpdateCatalogItems(string modelId, Stream fileStream);
        Task<UpdateCatalogItemsResponse> UpdateCatalogItemsAsync(string modelId, Stream fileStream);
        void UpdateModel(string modelId, UpdateModelRequest request);
        Task UpdateModelAsync(string modelId, UpdateModelRequest request);
        string DownloadUsageFile(string modelId, string fileId);
        Task<string> DownloadUsageFileAsync(string modelId, string fileId);
        GetBatchJobResponse GetAllBatchJobs(string jobId);
        Task<GetBatchJobResponse> GetAllBatchJobsAsync(string jobId);
        GetAllBuildsResponse GetAllBuilds(string modelId, bool onlyLastRequestedBuild = false);
        Task<GetAllBuildsResponse> GetAllBuildsAsync(string modelId, bool onlyLastRequestedBuild = false);
        GetAllBusinessRulesResponse GetAllBusinessRules(string modelId);
        Task<GetAllBusinessRulesResponse> GetAllBusinessRulesAsync(string modelId);
        GetAllCatalogItemsResponse GetAllCatalogItems(string modelId, int top = 0, int skip = 0, int maxpagesize = 0);
        Task<GetAllCatalogItemsResponse> GetAllCatalogItemsAsync(string modelId, int top = 0, int skip = 0, int maxpagesize = 0);
        GetAllModelsResponse GetAllModels();
        Task<GetAllModelsResponse> GetAllModelsAsync();
        Build GetBuildById(string modelId, int buildId);
        Task<Build> GetBuildByIdAsync(string modelId, int buildId);
        BuildDataStatisticsResponse GetBuildDataStatistics(string modelId, int buildId);
        Task<BuildDataStatisticsResponse> GetBuildDataStatisticsAsync(string modelId, int buildId);
        BuildMetricsResponse GetBuildMetrics(string modelId, int buildId);
        Task<BuildMetricsResponse> GetBuildMetricsAsync(string modelId, int buildId);
        BusinessRule GetBusinessRule(string modelId, string ruleId);
        Task<BusinessRule> GetBusinessRuleAsync(string modelId, string ruleId);
        ItemRecommendationResponse GetItemToItemRecommendations(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0);
        Task<ItemRecommendationResponse> GetItemToItemRecommendationsAsync(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0);
        RecommendationModel GetModel(string modelId);
        Task<RecommendationModel> GetModelAsync(string modelId);
        ModelFeatureResponse GetModelFeatures(string modelId, int rankBuildId = 0);
        Task<ModelFeatureResponse> GetModelFeaturesAsync(string modelId, int rankBuildId = 0);
        GetOperationStatusResponse GetOperationStatus(string operationId);
        Task<GetOperationStatusResponse> GetOperationStatusAsync(string operationId);
        SearchCatalogItemsResponse GetSpecificCatalogItemsBySearchTerm(string modelId, List<string> ids = null, string searchTerm = "");
        Task<SearchCatalogItemsResponse> GetSpecificCatalogItemsBySearchTermAsync(string modelId, List<string> ids = null, string searchTerm = "");
        BuildUsageStatisticsResponse GetUsageStatisticsForABuild(string modelId, int buildId, string interval, List<string> eventTypes);
        Task<BuildUsageStatisticsResponse> GetUsageStatisticsForABuildAsync(string modelId, int buildId, string interval, List<string> eventTypes);
        ModelUsageStatisticsResponse GetUsageStatisticsForAModel(string modelId, string interval, List<string> eventTypes);
        Task<ModelUsageStatisticsResponse> GetUsageStatisticsForAModelAsync(string modelId, string interval, List<string> eventTypes);
        ItemRecommendationResponse GetUserToItemRecommendations(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0);
        Task<ItemRecommendationResponse> GetUserToItemRecommendationsAsync(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0);
        List<UsageFile> ListUsageFiles(string modelId);
        Task<List<UsageFile>> ListUsageFilesAsync(string modelId);
    }
}