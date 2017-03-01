using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge
{
    public class RecommendationsRepository : TextClient, IRecommendationsRepository
    {
        protected static readonly string recOperationsUrl = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/operations/";
        protected static readonly string recModelsUrls = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0/models/";

        protected readonly IRepositoryClient RepositoryClient;

        public RecommendationsRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient)
            : base(apiKeys.Recommendations)
        {
            RepositoryClient = repoClient;
        }

        #region Create
        
        public async Task<CreateBusinessRuleResponse> CreateBusinessRuleAsync(string modelId, CreateBusinessRuleRequest request)
        {
            var response = await SendPostAsync($"{recModelsUrls}/{modelId}/rules", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBusinessRuleResponse>(response);
        }
        
        public async Task<CreateModelResponse> CreateModelAsync(CreateModelRequest request)
        {
            var response = await SendPostAsync(recModelsUrls, JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateModelResponse>(response);
        }

        public async Task<CreateBuildResponse> CreateBuildAsync(string modelId, CreateBuildRequest request)
        {
            var response = await SendPostAsync($"{recModelsUrls}/{modelId}/builds", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<CreateBuildResponse>(response);

        }

        public async void StartBatchJobAsync() { }

        public async void UploadCatalogFileAsync() { }

        public async void UploadUsageEventAsync() { }

        public async void UploadUsageFileAsync() { }

        #endregion Create

        #region Delete
        
        public async Task CancelOperationAsync(string operationId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recOperationsUrl}?id={operationId}", string.Empty);
        }

        public async Task DeleteAllBusinessRulesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recModelsUrls}{modelId}/rules", string.Empty);
        }

        public async Task DeleteAllUsageFilesAsync(string modelId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recModelsUrls}{modelId}/usage", string.Empty);
        }

        public async Task DeleteBuildAsync(string modelId, string buildId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recModelsUrls}{modelId}/builds/{buildId}", string.Empty);
        }

        public async Task DeleteBusinessRuleAsync(string modelId, string ruleId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recModelsUrls}{modelId}/rules/{ruleId}", string.Empty);
        }

        public async Task<DeleteCatalogItemsResponse> DeleteCatalogItemsAsync(string modelId, bool deleteAll = false)
        {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recModelsUrls}{modelId}/catalog?deleteAll={deleteAll}", string.Empty);

            return JsonConvert.DeserializeObject<DeleteCatalogItemsResponse>(response);
        }

        public async Task DeleteModelAsync(string id)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recModelsUrls}{id}", string.Empty);
        }

        public async Task DeleteUsageFileAsync(string modelId, string fileId)
        {
            await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{recModelsUrls}{modelId}/usage/{fileId}", string.Empty);
        }

        #endregion Delete

        #region Patch

        public async Task<UpdateCatalogItemsResponse> UpdateCatalogItemsAsync(string modelId, Stream fileStream)
        {
            var response = await RepositoryClient.SendOctetStreamUpdateAsync(ApiKey, $"{recModelsUrls}{modelId}/catalog", fileStream);

            return JsonConvert.DeserializeObject<UpdateCatalogItemsResponse>(response);
        }

        public async Task UpdateModelAsync(string modelId, UpdateModelRequest request)
        {
            await RepositoryClient.SendJsonUpdateAsync(ApiKey, $"{recModelsUrls}{modelId}", JsonConvert.SerializeObject(request));
        }

        #endregion Patch

        #region Get

        public async void DownloadUsageFileAsync() { }

        public async void GetAllBatchJobsAsync() { }

        public async void GetAllBuildsAsync() { }

        public async void GetAllBusinessRulesAsync() { }

        public async void GetAllCatalogItemsAsync() { }

        public async void GetAllModelsAsync() { }

        public async void GetBuildByIdAsync() { }

        public async void GetBuildDataStatisticsAsync() { }

        public async void GetBuildMetricsAsync() { }

        public async void GetBusinessRuleAsync() { }
        
        public async void GetToItemRecommendationsAsync() { }

        public async void GetModelAsync() { }

        public async void GetModelFeaturesAsync() { }

        public async void GetOperationStatusAsync() { }

        public async void GetSpecificCatalogItemsBySearchTermAsync() { }

        public async void GetUsageStatisticsForABuildAsync() { }

        public async void GetUserToItemRecommendationsAsync() { }

        public async void ListUsageFilesAsync() { }

        #endregion Get
    }
}