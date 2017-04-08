using System;
using System.Collections.Generic;
using System.IO;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations;
using Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge;

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

        public virtual CreateBusinessRuleResponse CreateBusinessRule(string modelId, CreateBusinessRuleRequest request)
        {
            try
            {
                var result = RecommendationsRepository.CreateBusinessRule(modelId, request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CreateBusinessRule failed", this, ex);
            }

            return null;
        }

        public virtual RecommendationModel CreateModel(CreateModelRequest request)
        {
            try
            {
                var result = RecommendationsRepository.CreateModel(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CreateModel failed", this, ex);
            }

            return null;
        }

        public virtual CreateBuildResponse CreateBuild(string modelId, CreateBuildRequest request)
        {
            try
            {
                var result = RecommendationsRepository.CreateBuild(modelId, request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CreateBuild failed", this, ex);
            }

            return null;
        }

        public virtual void StartBatchJob(BatchJobRequest request)
        {
            try
            {
                RecommendationsRepository.StartBatchJob(request);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.StartBatchJob failed", this, ex);
            }
        }

        public virtual UploadCatalogFileResponse UploadCatalogFile(string modelId, string catalogDisplayName, Stream stream)
        {
            try
            {
                var result = RecommendationsRepository.UploadCatalogFile(modelId, catalogDisplayName, stream);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UploadCatalogFile failed", this, ex);
            }

            return null;
        }

        public virtual void UploadUsageEvent(string modelId, UploadUsageEventRequest request)
        {
            try
            {
                RecommendationsRepository.UploadUsageEvent(modelId, request);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UploadUsageEvent failed", this, ex);
            }
        }

        public virtual UploadUsageFileResponse UploadUsageFile(string modelId, string usageDisplayName, Stream stream)
        {
            try
            {
                var result = RecommendationsRepository.UploadUsageFile(modelId, usageDisplayName, stream);

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

        public virtual void CancelOperation(string operationId)
        {
            try
            {
                RecommendationsRepository.CancelOperation(operationId);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.CancelOperation failed", this, ex);
            }
        }

        public virtual void DeleteAllBusinessRules(string modelId)
        {
            try
            {
                RecommendationsRepository.DeleteAllBusinessRules(modelId);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteAllBusinessRules failed", this, ex);
            }
        }

        public virtual void DeleteAllUsageFiles(string modelId)
        {
            try
            {
                RecommendationsRepository.DeleteAllUsageFiles(modelId);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteAllUsageFiles failed", this, ex);
            }
        }

        public virtual void DeleteBuild(string modelId, int buildId)
        {
            try
            {
                RecommendationsRepository.DeleteBuild(modelId, buildId);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteBuild failed", this, ex);
            }
        }

        public virtual void DeleteBusinessRule(string modelId, string ruleId)
        {
            try
            {
                RecommendationsRepository.DeleteBusinessRule(modelId, ruleId);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteBusinessRule failed", this, ex);
            }
        }

        public virtual DeleteCatalogItemsResponse DeleteCatalogItems(string modelId, bool deleteAll = false)
        {
            try
            {
                var result = RecommendationsRepository.DeleteCatalogItems(modelId, deleteAll);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteCatalogItems failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteModel(string id)
        {
            try
            {
                RecommendationsRepository.DeleteModel(id);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteModel failed", this, ex);
            }
        }

        public virtual void DeleteUsageFile(string modelId, string fileId)
        {
            try
            {
                RecommendationsRepository.DeleteUsageFile(modelId, fileId);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DeleteUsageFile failed", this, ex);
            }
        }

        #endregion Delete

        #region Update

        public virtual UpdateCatalogItemsResponse UpdateCatalogItems(string modelId, Stream fileStream)
        {
            try
            {
                var result = RecommendationsRepository.UpdateCatalogItems(modelId, fileStream);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UpdateCatalogItems failed", this, ex);
            }

            return null;
        }

        public virtual void UpdateModel(string modelId, UpdateModelRequest request)
        {
            try
            {
                RecommendationsRepository.UpdateModel(modelId, request);
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.UpdateModel failed", this, ex);
            }
        }

        #endregion Update

        #region Get

        public virtual string DownloadUsageFile(string modelId, string fileId)
        {
            try
            {
                var result = RecommendationsRepository.DownloadUsageFile(modelId, fileId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.DownloadUsageFile failed", this, ex);
            }

            return null;
        }

        public virtual GetBatchJobResponse GetAllBatchJobs(string jobId)
        {
            try
            {
                var result = RecommendationsRepository.GetAllBatchJobs(jobId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllBatchJobs failed", this, ex);
            }

            return null;
        }

        public virtual GetAllBuildsResponse GetAllBuilds(string modelId, bool onlyLastRequestedBuild = false)
        {
            try
            {
                var result = RecommendationsRepository.GetAllBuilds(modelId, onlyLastRequestedBuild);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllBuilds failed", this, ex);
            }

            return null;
        }

        public virtual GetAllBusinessRulesResponse GetAllBusinessRules(string modelId)
        {
            try
            {
                var result = RecommendationsRepository.GetAllBusinessRules(modelId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllBusinessRules failed", this, ex);
            }

            return null;
        }

        public virtual GetAllCatalogItemsResponse GetAllCatalogItems(string modelId, int top = 0, int skip = 0, int maxpagesize = 0)
        {
            try
            {
                var result = RecommendationsRepository.GetAllCatalogItems(modelId, top, skip, maxpagesize);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllCatalogItems failed", this, ex);
            }

            return null;
        }

        public virtual GetAllModelsResponse GetAllModels()
        {
            try
            {
                var result = RecommendationsRepository.GetAllModels();

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetAllModels failed", this, ex);
            }

            return null;
        }

        public virtual Build GetBuildById(string modelId, int buildId)
        {
            try
            {
                var result = RecommendationsRepository.GetBuildById(modelId, buildId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBuildById failed", this, ex);
            }

            return null;
        }

        public virtual BuildDataStatisticsResponse GetBuildDataStatistics(string modelId, int buildId)
        {
            try
            {
                var result = RecommendationsRepository.GetBuildDataStatistics(modelId, buildId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBuildDataStatistics failed", this, ex);
            }

            return null;
        }

        public virtual BuildMetricsResponse GetBuildMetrics(string modelId, int buildId)
        {
            try
            {
                var result = RecommendationsRepository.GetBuildMetrics(modelId, buildId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBuildMetrics failed", this, ex);
            }

            return null;
        }

        public virtual BusinessRule GetBusinessRule(string modelId, string ruleId)
        {
            try
            {
                var result = RecommendationsRepository.GetBusinessRule(modelId, ruleId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetBusinessRule failed", this, ex);
            }

            return null;
        }

        public virtual ItemRecommendationResponse GetItemToItemRecommendations(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0)
        {
            try
            {
                var result = RecommendationsRepository.GetItemToItemRecommendations(modelId, itemIds, numberOfResults, minimalScore, buildId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetItemToItemRecommendations failed", this, ex);
            }

            return null;
        }

        public virtual RecommendationModel GetModel(string modelId)
        {
            try
            {
                var result = RecommendationsRepository.GetModel(modelId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetModel failed", this, ex);
            }

            return null;
        }

        public virtual ModelFeatureResponse GetModelFeatures(string modelId, int rankBuildId = 0)
        {
            try
            {
                var result = RecommendationsRepository.GetModelFeatures(modelId, rankBuildId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetModelFeatures failed", this, ex);
            }

            return null;
        }

        public virtual GetOperationStatusResponse GetOperationStatus(string operationId)
        {
            try
            {
                var result = RecommendationsRepository.GetOperationStatus(operationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetOperationStatus failed", this, ex);
            }

            return null;
        }

        public virtual SearchCatalogItemsResponse GetSpecificCatalogItemsBySearchTerm(string modelId, List<string> ids = null, string searchTerm = "")
        {
            try
            {
                var result = RecommendationsRepository.GetSpecificCatalogItemsBySearchTerm(modelId, ids, searchTerm);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetSpecificCatalogItemsBySearchTerm failed", this, ex);
            }

            return null;
        }

        public virtual BuildUsageStatisticsResponse GetUsageStatisticsForABuild(string modelId, int buildId, string interval, List<string> eventTypes)
        {
            try
            {
                var result = RecommendationsRepository.GetUsageStatisticsForABuild(modelId, buildId, interval, eventTypes);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetUsageStatisticsForABuild failed", this, ex);
            }

            return null;
        }

        public virtual ModelUsageStatisticsResponse GetUsageStatisticsForAModel(string modelId, string interval, List<string> eventTypes)
        {
            try
            {
                var result = RecommendationsRepository.GetUsageStatisticsForAModel(modelId, interval, eventTypes);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetUsageStatisticsForAModel failed", this, ex);
            }

            return null;
        }

        public virtual ItemRecommendationResponse GetUserToItemRecommendations(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0)
        {
            try
            {
                var result = RecommendationsRepository.GetUserToItemRecommendations(modelId, userId, numberOfResults, itemIds, includeMetadata, buildId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("RecommendationsService.GetUserToItemRecommendations failed", this, ex);
            }

            return null;
        }

        public virtual List<UsageFile> ListUsageFiles(string modelId)
        {
            try
            {
                var result = RecommendationsRepository.ListUsageFiles(modelId);

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