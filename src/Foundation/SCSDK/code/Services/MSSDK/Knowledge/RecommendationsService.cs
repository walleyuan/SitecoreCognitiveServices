using System;
using System.Collections.Generic;
using System.IO;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Knowledge;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge
{
    public class RecommendationsService : IRecommendationsService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IRecommendationsRepository RecommendationsRepository;
        protected readonly ILogWrapper Logger;

        public RecommendationsService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IRecommendationsRepository recommendationsRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            RecommendationsRepository = recommendationsRepository;
            Logger = logger;
        }
        
        #region Post

        public virtual CreateBusinessRuleResponse CreateBusinessRule(string modelId, CreateBusinessRuleRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.CreateBusinessRule",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.CreateBusinessRule(modelId, request);
                    return result;
                },
                null);
        }

        public virtual RecommendationModel CreateModel(CreateModelRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.CreateModel",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.CreateModel(request);
                    return result;
                },
                null);
        }

        public virtual CreateBuildResponse CreateBuild(string modelId, CreateBuildRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.CreateBuild",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.CreateBuild(modelId, request);
                    return result;
                },
                null);
        }

        public virtual void StartBatchJob(BatchJobRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.StartBatchJob",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.StartBatchJob(request);
                    return true;
                },
                false);
        }

        public virtual UploadCatalogFileResponse UploadCatalogFile(string modelId, string catalogDisplayName, Stream stream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.UploadCatalogFile",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.UploadCatalogFile(modelId, catalogDisplayName, stream);
                    return result;
                },
                null);
        }

        public virtual void UploadUsageEvent(string modelId, UploadUsageEventRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.UploadUsageEvent",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.UploadUsageEvent(modelId, request);
                    return true;
                },
                false);
        }

        public virtual UploadUsageFileResponse UploadUsageFile(string modelId, string usageDisplayName, Stream stream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.UploadUsageFile",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.UploadUsageFile(modelId, usageDisplayName, stream);
                    return result;
                },
                null);
        }

        #endregion Post

        #region Delete

        public virtual void CancelOperation(string operationId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.CancelOperation",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.CancelOperation(operationId);
                    return true;
                },
                false);
        }

        public virtual void DeleteAllBusinessRules(string modelId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DeleteAllBusinessRules",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.DeleteAllBusinessRules(modelId);
                    return true;
                },
                false);
        }

        public virtual void DeleteAllUsageFiles(string modelId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DeleteAllUsageFiles",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.DeleteAllUsageFiles(modelId);
                    return true;
                },
                false);
        }

        public virtual void DeleteBuild(string modelId, int buildId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DeleteBuild",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.DeleteBuild(modelId, buildId);
                    return true;
                },
                false);
        }

        public virtual void DeleteBusinessRule(string modelId, string ruleId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DeleteBusinessRule",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.DeleteBusinessRule(modelId, ruleId);
                    return true;
                },
                false);
        }

        public virtual DeleteCatalogItemsResponse DeleteCatalogItems(string modelId, bool deleteAll = false)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DeleteCatalogItems",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.DeleteCatalogItems(modelId, deleteAll);
                    return result;
                },
                null);
        }

        public virtual void DeleteModel(string id)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DeleteModel",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.DeleteModel(id);
                    return true;
                },
                false);
        }

        public virtual void DeleteUsageFile(string modelId, string fileId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DeleteUsageFile",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.DeleteUsageFile(modelId, fileId);
                    return true;
                },
                false);
        }

        #endregion Delete

        #region Update

        public virtual UpdateCatalogItemsResponse UpdateCatalogItems(string modelId, Stream fileStream)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.UpdateCatalogItems",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.UpdateCatalogItems(modelId, fileStream);
                    return result;
                },
                null);
        }

        public virtual void UpdateModel(string modelId, UpdateModelRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.UpdateModel",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    RecommendationsRepository.UpdateModel(modelId, request);
                    return true;
                },
                false);
        }

        #endregion Update

        #region Get

        public virtual string DownloadUsageFile(string modelId, string fileId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.DownloadUsageFile",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.DownloadUsageFile(modelId, fileId);
                    return result;
                },
                null);
        }

        public virtual GetBatchJobResponse GetAllBatchJobs(string jobId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetAllBatchJobs",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetAllBatchJobs(jobId);
                    return result;
                },
                null);
        }

        public virtual GetAllBuildsResponse GetAllBuilds(string modelId, bool onlyLastRequestedBuild = false)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetAllBuilds",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetAllBuilds(modelId, onlyLastRequestedBuild);
                    return result;
                },
                null);
        }

        public virtual GetAllBusinessRulesResponse GetAllBusinessRules(string modelId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetAllBusinessRules",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetAllBusinessRules(modelId);
                    return result;
                },
                null);
        }

        public virtual GetAllCatalogItemsResponse GetAllCatalogItems(string modelId, int top = 0, int skip = 0, int maxpagesize = 0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetAllCatalogItems",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetAllCatalogItems(modelId, top, skip, maxpagesize);
                    return result;
                },
                null);
        }

        public virtual GetAllModelsResponse GetAllModels()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetAllModels",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetAllModels();
                    return result;
                },
                null);
        }

        public virtual Build GetBuildById(string modelId, int buildId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetBuildById",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetBuildById(modelId, buildId);
                    return result;
                },
                null);
        }

        public virtual BuildDataStatisticsResponse GetBuildDataStatistics(string modelId, int buildId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetBuildDataStatistics",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetBuildDataStatistics(modelId, buildId);
                    return result;
                },
                null);
        }

        public virtual BuildMetricsResponse GetBuildMetrics(string modelId, int buildId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetBuildMetrics",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetBuildMetrics(modelId, buildId);
                    return result;
                },
                null);
        }

        public virtual BusinessRule GetBusinessRule(string modelId, string ruleId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetBusinessRule",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetBusinessRule(modelId, ruleId);
                    return result;
                },
                null);
        }

        public virtual ItemRecommendationResponse GetItemToItemRecommendations(string modelId, List<string> itemIds, int numberOfResults, int minimalScore, int buildId = 0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetItemToItemRecommendations",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetItemToItemRecommendations(modelId, itemIds, numberOfResults, minimalScore, buildId);
                    return result;
                },
                null);
        }

        public virtual RecommendationModel GetModel(string modelId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetModel",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetModel(modelId);
                    return result;
                },
                null);
        }

        public virtual ModelFeatureResponse GetModelFeatures(string modelId, int rankBuildId = 0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetModelFeatures",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetModelFeatures(modelId, rankBuildId);
                    return result;
                },
                null);
        }

        public virtual GetOperationStatusResponse GetOperationStatus(string operationId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetOperationStatus",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetOperationStatus(operationId);
                    return result;
                },
                null);
        }

        public virtual SearchCatalogItemsResponse GetSpecificCatalogItemsBySearchTerm(string modelId, List<string> ids = null, string searchTerm = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetSpecificCatalogItemsBySearchTerm",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetSpecificCatalogItemsBySearchTerm(modelId, ids, searchTerm);
                    return result;
                },
                null);
        }

        public virtual BuildUsageStatisticsResponse GetUsageStatisticsForABuild(string modelId, int buildId, string interval, List<string> eventTypes)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetUsageStatisticsForABuild",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetUsageStatisticsForABuild(modelId, buildId, interval, eventTypes);
                    return result;
                },
                null);
        }

        public virtual ModelUsageStatisticsResponse GetUsageStatisticsForAModel(string modelId, string interval, List<string> eventTypes)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetUsageStatisticsForAModel",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetUsageStatisticsForAModel(modelId, interval, eventTypes);
                    return result;
                },
                null);
        }

        public virtual ItemRecommendationResponse GetUserToItemRecommendations(string modelId, string userId, int numberOfResults, List<string> itemIds = null, bool includeMetadata = false, int buildId = 0)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.GetUserToItemRecommendations",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.GetUserToItemRecommendations(modelId, userId, numberOfResults, itemIds, includeMetadata, buildId);
                    return result;
                },
                null);
        }

        public virtual List<UsageFile> ListUsageFiles(string modelId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "RecommendationsService.ListUsageFiles",
                ApiKeys.RecommendationsRetryInSeconds,
                () =>
                {
                    var result = RecommendationsRepository.ListUsageFiles(modelId);
                    return result;
                },
                null);
        }

        #endregion Get
    }
}