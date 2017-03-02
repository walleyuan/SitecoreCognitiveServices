using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations;
using Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge;

namespace Sitecore.SharedSource.CognitiveServices.Services.Knowledge
{
    public class RecommendationsService : IRecommendationsService
    {
        protected IRecommendationsRepository RecommendationsRepository;
        protected ILogWrapper Logger;

        public RecommendationsService(
            IRecommendationsRepository recommendationsRepository,
            ILogWrapper logger)
        {
            RecommendationsRepository = recommendationsRepository;
            Logger = logger;
        }
        
        #region Post

        public CreateBusinessRuleResponse CreateBusinessRule(string modelId, CreateBusinessRuleRequest request)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.CreateBusinessRuleAsync(modelId, request)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CreateBusinessRule failed", this, ex);
            }

            return null;
        }

        public RecommendationModel CreateModel(CreateModelRequest request)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.CreateModelAsync(request)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CreateModel failed", this, ex);
            }

            return null;
        }

        public CreateBuildResponse CreateBuild(string modelId, CreateBuildRequest request)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.CreateBuildAsync(modelId, request)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CreateBuild failed", this, ex);
            }

            return null;
        }

        public void StartBatchJob(BatchJobRequest request)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.StartBatchJobAsync(request));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.StartBatchJob failed", this, ex);
            }
        }

        public UploadCatalogFileResponse UploadCatalogFile(string modelId, string catalogDisplayName, Stream stream)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.UploadCatalogFileAsync(modelId, catalogDisplayName, stream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UploadCatalogFile failed", this, ex);
            }

            return null;
        }

        public void UploadUsageEvent(string modelId, UploadUsageEventRequest request)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.UploadUsageEventAsync(modelId, request));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UploadUsageEvent failed", this, ex);
            }
        }

        public UploadUsageFileResponse UploadUsageFile(string modelId, string usageDisplayName, Stream stream)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.UploadUsageFileAsync(modelId, usageDisplayName, stream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UploadUsageFile failed", this, ex);
            }

            return null;
        }

        #endregion Post

        #region Delete

        public void CancelOperation(string operationId)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.CancelOperationAsync(operationId));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CancelOperation failed", this, ex);
            }
        }

        public void DeleteAllBusinessRules(string modelId)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.DeleteAllBusinessRulesAsync(modelId));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteAllBusinessRules failed", this, ex);
            }
        }

        public void DeleteAllUsageFiles(string modelId)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.DeleteAllUsageFilesAsync(modelId));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteAllUsageFiles failed", this, ex);
            }
        }

        public void DeleteBuild(string modelId, int buildId)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.DeleteBuildAsync(modelId, buildId));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteBuild failed", this, ex);
            }
        }

        public void DeleteBusinessRule(string modelId, string ruleId)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.DeleteBusinessRuleAsync(modelId, ruleId));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteBusinessRule failed", this, ex);
            }
        }

        public DeleteCatalogItemsResponse DeleteCatalogItems(string modelId, bool deleteAll = false)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.DeleteCatalogItemsAsync(modelId, deleteAll)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteCatalogItems failed", this, ex);
            }

            return null;
        }

        public void DeleteModel(string id)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.DeleteModelAsync(id));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteModel failed", this, ex);
            }
        }

        public void DeleteUsageFile(string modelId, string fileId)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.DeleteUsageFileAsync(modelId, fileId));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteUsageFile failed", this, ex);
            }
        }

        #endregion Delete

        #region Update

        public UpdateCatalogItemsResponse UpdateCatalogItems(string modelId, Stream fileStream)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.UpdateCatalogItemsAsync(modelId, fileStream)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UpdateCatalogItems failed", this, ex);
            }

            return null;
        }

        public void UpdateModel(string modelId, UpdateModelRequest request)
        {
            try
            {
                Task.Run(async () => await RecommendationsRepository.UpdateModelAsync(modelId, request));
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UpdateModel failed", this, ex);
            }
        }

        #endregion Update

        #region Get

        public string DownloadUsageFile(string modelId, string fileId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.DownloadUsageFileAsync(modelId, fileId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DownloadUsageFile failed", this, ex);
            }

            return null;
        }

        public GetBatchJobResponse GetAllBatchJobs(string jobId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetAllBatchJobsAsync(jobId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllBatchJobs failed", this, ex);
            }

            return null;
        }

        public GetAllBuildsResponse GetAllBuilds(string modelId, bool onlyLastRequestedBuild = false)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetAllBuildsAsync(modelId, onlyLastRequestedBuild)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllBuilds failed", this, ex);
            }

            return null;
        }

        public GetAllBusinessRulesResponse GetAllBusinessRules(string modelId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetAllBusinessRulesAsync(modelId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllBusinessRules failed", this, ex);
            }

            return null;
        }

        public GetAllCatalogItemsResponse GetAllCatalogItems(string modelId, int top = 0, int skip = 0, int maxpagesize = 0)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetAllCatalogItemsAsync(modelId, top, skip, maxpagesize)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllCatalogItems failed", this, ex);
            }

            return null;
        }

        public GetAllModelsResponse GetAllModels()
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetAllModelsAsync()).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllModels failed", this, ex);
            }

            return null;
        }

        public Build GetBuildById(string modelId, int buildId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetBuildByIdAsync(modelId, buildId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBuildById failed", this, ex);
            }

            return null;
        }

        public BuildDataStatisticsResponse GetBuildDataStatistics(string modelId, int buildId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetBuildDataStatisticsAsync(modelId, buildId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBuildDataStatistics failed", this, ex);
            }

            return null;
        }

        public BuildMetricsResponse GetBuildMetrics(string modelId, int buildId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetBuildMetricsAsync(modelId, buildId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBuildMetrics failed", this, ex);
            }

            return null;
        }

        public BusinessRule GetBusinessRule(string modelId, string ruleId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetBusinessRuleAsync(modelId, ruleId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBusinessRule failed", this, ex);
            }

            return null;
        }

        public ItemRecommendationResponse GetItemToItemRecommendations(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetItemToItemRecommendationsAsync(modelId, itemIds, numberOfResults, minimalScore, buildId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetItemToItemRecommendations failed", this, ex);
            }

            return null;
        }

        public RecommendationModel GetModel(string modelId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetModelAsync(modelId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetModel failed", this, ex);
            }

            return null;
        }

        public ModelFeatureResponse GetModelFeatures(string modelId, int rankBuildId = 0)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetModelFeaturesAsync(modelId, rankBuildId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetModelFeatures failed", this, ex);
            }

            return null;
        }

        public GetOperationStatusResponse GetOperationStatus(string operationId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetOperationStatusAsync(operationId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetOperationStatus failed", this, ex);
            }

            return null;
        }

        public SearchCatalogItemsResponse GetSpecificCatalogItemsBySearchTerm(string modelId, List<string> ids = null, string searchTerm = "")
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetSpecificCatalogItemsBySearchTermAsync(modelId, ids, searchTerm)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetSpecificCatalogItemsBySearchTerm failed", this, ex);
            }

            return null;
        }

        public BuildUsageStatisticsResponse GetUsageStatisticsForABuild(string modelId, int buildId, string interval, List<string> eventTypes)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetUsageStatisticsForABuildAsync(modelId, buildId, interval, eventTypes)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetUsageStatisticsForABuild failed", this, ex);
            }

            return null;
        }

        public ModelUsageStatisticsResponse GetUsageStatisticsForAModel(string modelId, string interval, List<string> eventTypes)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetUsageStatisticsForAModelAsync(modelId, interval, eventTypes)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetUsageStatisticsForAModel failed", this, ex);
            }

            return null;
        }

        public ItemRecommendationResponse GetUserToItemRecommendations(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.GetUserToItemRecommendationsAsync(modelId, userId, numberOfResults, itemIds, includeMetadata, buildId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetUserToItemRecommendations failed", this, ex);
            }

            return null;
        }

        public List<UsageFile> ListUsageFiles(string modelId)
        {
            try
            {
                var result = Task.Run(async () => await RecommendationsRepository.ListUsageFilesAsync(modelId)).Result;

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.ListUsageFiles failed", this, ex);
            }

            return null;
        }

        #endregion Get
    }
}