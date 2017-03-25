using System;
using Microsoft.ProjectOxford.Text.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language {
    public class LuisRepository : TextClient, ILuisRepository {

        protected static readonly string luisUrl = "https://westus.api.cognitive.microsoft.com/luis/api/v2.0/apps/";

        protected readonly IRepositoryClient RepositoryClient;
        protected readonly ICSVParser CSVParser;

        public LuisRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient,
            ICSVParser csvParser)
            : base(apiKeys.Luis) {

            RepositoryClient = repoClient;
            CSVParser = csvParser;
        }

        public string GetSkipTakeQuerystring(int skip, int take)
        {
            StringBuilder sb = new StringBuilder();
            if (skip > 0)
                sb.Append($"?skip={skip}");

            if (take != 100) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}take={take}");
            }

            return sb.ToString();
        }

        #region Apps

        public virtual async Task<string> AddApplicationAsync(AddApplicationRequest request) {
            var response = await SendPostAsync(luisUrl, JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task DeleteApplicationAsync(Guid appId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}");
        }

        public virtual async Task<List<List<string>>> DownloadApplicationQueryLogsAsync(Guid appId) {
            var response = await SendGetAsync($"{luisUrl}{appId}/querylogs");

            return CSVParser.ParseCSV(response);
        }

        public virtual async Task<List<ApplicationCulture>> GetApplicationCulturesAsync() {
            var response = await SendGetAsync($"{luisUrl}cultures");

            return JsonConvert.DeserializeObject<List<ApplicationCulture>>(response);
        }

        public virtual async Task<List<string>> GetApplicationDomainsAsync() {
            var response = await SendGetAsync($"{luisUrl}domains");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<ApplicationInfo> GetApplicationInfoAsync(Guid appId) {
            var response = await SendGetAsync($"{luisUrl}{appId}");

            return JsonConvert.DeserializeObject<ApplicationInfo>(response);
        }

        public virtual async Task<List<string>> GetApplicationUsageScenariosAsync() {
            var response = await SendGetAsync($"{luisUrl}usagescenarios");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<PersonalAssistantResponse> GetPersonalAssistantApplicationsAsync() {
            var response = await SendGetAsync($"{luisUrl}assistants");

            return JsonConvert.DeserializeObject<PersonalAssistantResponse>(response);
        }

        public virtual async Task<List<UserApplication>> GetUserApplicationsAsync(int skip = 0, int take = 100) {
            
            var response = await SendGetAsync($"{luisUrl}{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<UserApplication>>(response);
        }

        public virtual async Task<string> ImportApplicationAsync(ImportApplicationRequest request, string appName = "") {
            var appQS = string.IsNullOrEmpty(appName) ? "" : $"?appName={appName}";

            var response = await SendPostAsync($"{luisUrl}import{appQS}", JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task<PublishResponse> PublishApplicationAsync(Guid appId, PublishRequest request) {
            var response = await SendPostAsync($"{luisUrl}{appId}/publish", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<PublishResponse>(response);
        }

        public virtual async Task RenameApplication(Guid appId, ApplicationRenameRequest request) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKey, $"{luisUrl}{appId}", JsonConvert.SerializeObject(request));
        }

        #endregion Apps

        #region Examples

        public virtual async Task<AddLabelResponse> AddLabelAsync(Guid appId, string versionId, AddLabelRequest request) 
        {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/example", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<AddLabelResponse>(response);
        }

        public virtual async Task<List<BatchAddLabelsResponse>> BatchAddLabelsAsync(Guid appId, string versionId, List<AddLabelRequest> request) 
        {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/examples", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<BatchAddLabelsResponse>>(response);
        }

        public virtual async Task DeleteExampleLabelAsync(Guid appId, string versionId, int exampleId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/examples/{exampleId}");
        }

        public virtual async Task<List<LabeledExamples>>  ReviewLabeledExamplesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {
            
            var response = await SendGetAsync($"{luisUrl}{appId}/versions/{versionId}/examples{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        #endregion Examples

        #region Features

        public virtual async Task<int> CreatePatternFeatureAsync(Guid appId, string versionId, PatternFeature feature) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/patterns", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual async Task<int> CreatePhraseListFeatureAsync(Guid appId, string versionId, PhraseListFeature feature) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/phraselists", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual async Task DeletePatternFeatureAsync(Guid appId, string versionId, int patternId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");
        }

        public virtual async Task DeletePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");
        }

        public virtual async Task<ApplicationFeaturesResponse> GetApplicationVersionFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {
            
            var response = await SendGetAsync($"{luisUrl}{appId}/versions/{versionId}/feature{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ApplicationFeaturesResponse>(response);
        }

        public virtual async Task<List<PatternFeature>> GetApplicationVersionPatternFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {
            
            var response = await SendGetAsync($"{luisUrl}{appId}/versions/{versionId}/patterns{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PatternFeature>>(response);
        }

        public virtual async Task<List<PhraseListFeature>> GetApplicationVersionPhraseListFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await SendGetAsync($"{luisUrl}{appId}/versions/{versionId}/phraselists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PhraseListFeature>>(response);
        }

        public virtual async Task<PatternFeature> GetPatternFeatureInfoAsync(Guid appId, string versionId, int patternId) {

            var response = await SendGetAsync($"{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");

            return JsonConvert.DeserializeObject<PatternFeature>(response);
        }

        public virtual async Task<PhraseListFeature> GetPhraseListFeatureInfoAsync(Guid appId, string versionId, int phraselistId) {

            var response = await SendGetAsync($"{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");

            return JsonConvert.DeserializeObject<PhraseListFeature>(response);
        }

        public virtual async Task UpdatePatternFeatureAsync(Guid appId, string versionId, int patternId, PatternFeature feature) {

            var response = await RepositoryClient.SendJsonUpdateAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}", JsonConvert.SerializeObject(feature));
        }

        public virtual async Task UpdatePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId, PhraseListFeature feature) {

            var response = await RepositoryClient.SendJsonUpdateAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}", JsonConvert.SerializeObject(feature));
        }

        #endregion Features

        #region Models

        public virtual async Task<List<EntityExtractorInfo>> AddPrebuiltEntityExtractorsAsync(Guid appId, string versionId, List<string> extractorNames) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/prebuilts", JsonConvert.SerializeObject(extractorNames));

            return JsonConvert.DeserializeObject<List<EntityExtractorInfo>>(response);
        }

        public virtual async Task<Guid> CreateCloseListEntityModelAsync(Guid appId, string versionId, CreateCloseListEntityModelRequest request) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/closedlists", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateCompositeEntityExtractorAsync(Guid appId, string versionId, CreateStructuredEntityExtractorRequest request) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/compositeentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateEntityExtractorAsync(Guid appId, string versionId, CreateNamedEntityRequest request) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/entities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateHeirarchicalEntityExtractorAsync(Guid appId, string versionId, CreateStructuredEntityExtractorRequest request) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/hierarchicalentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateIntentClassifierAsync(Guid appId, string versionId, CreateNamedEntityRequest request) {
            var response = await SendPostAsync($"{luisUrl}{appId}/versions/{versionId}/intents", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task DeleteClosedListEntityModelAsync(Guid appId, string versionId, Guid closeListEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/closedlists/{closeListEntityId}");
        }

        public virtual async Task DeleteCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}");
        }

        public virtual async Task DeleteEntityModelAsync(Guid appId, string versionId, Guid entityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/entities/{entityId}");
        }

        public virtual async Task DeleteHierarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}");
        }

        public virtual async Task DeleteIntentModelAsync(Guid appId, string versionId, Guid intentId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/intents/{intentId}");
        }

        public virtual async Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid prebuiltId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/prebuilts/{prebuiltId}");
        }

        public virtual async Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid closedListEntityId, int sublistId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKey, $"{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}/sublists/{sublistId}");
        }

        public virtual async Task<EntityExtractorInfo> GetApplicationVersionClosedListInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {
            
            var response = await SendGetAsync($"{luisUrl}{appId}/versions/{versionId}/closedlists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<EntityExtractorInfo>(response);
        }


        #endregion Models

        #region Train

        #endregion Train

        #region User

        #endregion User

        #region Versions

        #endregion Versions
    }
}