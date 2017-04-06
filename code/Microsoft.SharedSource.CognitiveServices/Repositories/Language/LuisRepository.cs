using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.CSV;
using Newtonsoft.Json;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language {
    public class LuisRepository : ILuisRepository
    {

        protected static readonly string luisQueryUrl = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/";
        protected static readonly string luisRoot =     "https://westus.api.cognitive.microsoft.com/luis/api/v2.0/";
        protected static readonly string luisUrl = $"{luisRoot}apps/";
        protected static readonly string luisApiKeyUrl = $"{luisRoot}externalKeys/";
        protected static readonly string luisSubKeyUrl = $"{luisRoot}subscriptions/";
        protected static readonly string luisProgKeyUrl = $"{luisRoot}programmatickey";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;
        protected readonly ICSVParser CSVParser;

        public LuisRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient,
            ICSVParser csvParser)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
            CSVParser = csvParser;
        }

        public string GetSkipTakeQuerystring(int skip, int take) {
            StringBuilder sb = new StringBuilder();
            if (skip > 0)
                sb.Append($"?skip={skip}");

            if (take != 100) {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}take={take}");
            }

            return sb.ToString();
        }

        #region Querying

        public virtual async Task<QueryResult> QueryAsync(Guid appId, string query)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisQueryUrl}{appId}?subscription-key={ApiKeys.Luis}&verbose=true&q={query}");

            return JsonConvert.DeserializeObject<QueryResult>(response);
        }

        #endregion Querying

        #region Apps

        public virtual async Task<string> AddApplicationAsync(AddApplicationRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, luisUrl, JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task DeleteApplicationAsync(Guid appId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}");
        }

        public virtual async Task<List<List<string>>> DownloadApplicationQueryLogsAsync(Guid appId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/querylogs");

            return CSVParser.ParseCSV(response);
        }

        public virtual async Task<List<ApplicationCulture>> GetApplicationCulturesAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}cultures");

            return JsonConvert.DeserializeObject<List<ApplicationCulture>>(response);
        }

        public virtual async Task<List<string>> GetApplicationDomainsAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}domains");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<ApplicationInfo> GetApplicationInfoAsync(Guid appId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}");

            return JsonConvert.DeserializeObject<ApplicationInfo>(response);
        }

        public virtual async Task<List<string>> GetApplicationUsageScenariosAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}usagescenarios");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<PersonalAssistantResponse> GetPersonalAssistantApplicationsAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}assistants");

            return JsonConvert.DeserializeObject<PersonalAssistantResponse>(response);
        }

        public virtual async Task<List<UserApplication>> GetUserApplicationsAsync(int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<UserApplication>>(response);
        }

        public virtual async Task<string> ImportApplicationAsync(ApplicationDefinition request, string appName = "") {
            var appQS = string.IsNullOrEmpty(appName) ? "" : $"?appName={appName}";

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}import{appQS}", JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task<PublishResponse> PublishApplicationAsync(Guid appId, PublishRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/publish", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<PublishResponse>(response);
        }

        public virtual async Task RenameApplicationAsync(Guid appId, ApplicationRenameRequest request) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}", JsonConvert.SerializeObject(request));
        }

        #endregion Apps

        #region Examples

        public virtual async Task<AddLabelResponse> AddLabelAsync(Guid appId, string versionId, AddLabelRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/example", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<AddLabelResponse>(response);
        }

        public virtual async Task<List<BatchAddLabelsResponse>> BatchAddLabelsAsync(Guid appId, string versionId, List<AddLabelRequest> request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/examples", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<BatchAddLabelsResponse>>(response);
        }

        public virtual async Task DeleteExampleLabelAsync(Guid appId, string versionId, int exampleId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/examples/{exampleId}");
        }

        public virtual async Task<List<LabeledExamples>> ReviewLabeledExamplesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/examples{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        #endregion Examples

        #region Features

        public virtual async Task<int> CreatePatternFeatureAsync(Guid appId, string versionId, PatternFeature feature) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/patterns", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual async Task<int> CreatePhraseListFeatureAsync(Guid appId, string versionId, PhraseListFeature feature) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/phraselists", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual async Task DeletePatternFeatureAsync(Guid appId, string versionId, int patternId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");
        }

        public virtual async Task DeletePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");
        }

        public virtual async Task<ApplicationFeaturesResponse> GetApplicationVersionFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/feature{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ApplicationFeaturesResponse>(response);
        }

        public virtual async Task<List<PatternFeature>> GetApplicationVersionPatternFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/patterns{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PatternFeature>>(response);
        }

        public virtual async Task<List<PhraseListFeature>> GetApplicationVersionPhraseListFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/phraselists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PhraseListFeature>>(response);
        }

        public virtual async Task<PatternFeature> GetPatternFeatureInfoAsync(Guid appId, string versionId, int patternId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");

            return JsonConvert.DeserializeObject<PatternFeature>(response);
        }

        public virtual async Task<PhraseListFeature> GetPhraseListFeatureInfoAsync(Guid appId, string versionId, int phraselistId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");

            return JsonConvert.DeserializeObject<PhraseListFeature>(response);
        }

        public virtual async Task UpdatePatternFeatureAsync(Guid appId, string versionId, int patternId, PatternFeature feature) {

            var response = await RepositoryClient.SendJsonUpdateAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}", JsonConvert.SerializeObject(feature));
        }

        public virtual async Task UpdatePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId, PhraseListFeature feature) {

            var response = await RepositoryClient.SendJsonUpdateAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}", JsonConvert.SerializeObject(feature));
        }

        #endregion Features

        #region Models

        public virtual async Task<List<EntityInfo>> AddPrebuiltEntityExtractorsAsync(Guid appId, string versionId, List<string> extractorNames) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/prebuilts", JsonConvert.SerializeObject(extractorNames));

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<Guid> CreateClosedListEntityModelAsync(Guid appId, string versionId, ClosedListEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/closedlists", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateCompositeEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/compositeentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateEntityExtractorAsync(Guid appId, string versionId, NamedEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/entities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateHeirarchicalEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/hierarchicalentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateIntentClassifierAsync(Guid appId, string versionId, NamedEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/intents", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task DeleteClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}");
        }

        public virtual async Task DeleteCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}");
        }

        public virtual async Task DeleteEntityModelAsync(Guid appId, string versionId, Guid entityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/entities/{entityId}");
        }

        public virtual async Task DeleteHierarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}");
        }

        public virtual async Task DeleteIntentModelAsync(Guid appId, string versionId, Guid intentId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/intents/{intentId}");
        }

        public virtual async Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid prebuiltId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/prebuilts/{prebuiltId}");
        }

        public virtual async Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid closedListEntityId, int sublistId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}/sublists/{sublistId}");
        }

        public virtual async Task<ClosedListEntityInfo> GetApplicationVersionClosedListInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/closedlists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ClosedListEntityInfo>(response);
        }

        public virtual async Task<ComplexEntityInfo> GetApplicationVersionCompositeEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/compositeentities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/entities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<ComplexEntityInfo>> GetApplicationVersionHeirarchicalEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/hierarchicalentities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<ComplexEntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionIntentInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/intents{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionModelInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/models{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionPrebuiltInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/prebuilts{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<PrebuiltEntity>> GetAvailablePrebuiltEntityExtractorsAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/listprebuilts");

            return JsonConvert.DeserializeObject<List<PrebuiltEntity>>(response);
        }

        public virtual async Task<ClosedListEntityInfo> GetClosedListEntityInfoAsync(Guid appId, string versionId, Guid closedListEntityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}");

            return JsonConvert.DeserializeObject<ClosedListEntityInfo>(response);
        }

        public virtual async Task<ComplexEntityInfo> GetCompositeEntityInfoAsync(Guid appId, string versionId, Guid compositeEntityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual async Task<EntityInfo> GetEntityInfoAsync(Guid appId, string versionId, Guid entityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/entities/{entityId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual async Task<ComplexEntityInfo> GetHeirarchicalEntityInfoAsync(Guid appId, string versionId, Guid heirarchicalEntityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual async Task<EntityInfo> GetIntentInfoAsync(Guid appId, string versionId, Guid intentId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/intents/{intentId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual async Task<EntityInfo> GetPrebuiltInfoAsync(Guid appId, string versionId, Guid prebuiltId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/prebuilts/{prebuiltId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual async Task PatchClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request) {

            var response = await RepositoryClient.SendJsonPatchAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task RenameEntityModelAsync(Guid appId, string versionId, Guid entityId, NamedEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/entities/{entityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task RenameIntentModelAsync(Guid appId, string versionId, Guid intentId, NamedEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/intents/{intentId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task<List<LabeledExamples>> SuggestEndpointQueriesForEntitiesAsync(Guid appId, string versionId, Guid entityId, int take = 10) {

            StringBuilder sb = new StringBuilder();
            if (take != 10 && take > 0)
                sb.Append($"?take={take}");

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/entities/{entityId}/suggest{sb}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        public virtual async Task<List<LabeledExamples>> SuggestEndpointQueriesForIntentsAsync(Guid appId, string versionId, Guid intentId, int take = 10) {

            StringBuilder sb = new StringBuilder();
            if (take != 10 && take > 0)
                sb.Append($"?take={take}");

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/intents/{intentId}/suggest{sb}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        public virtual async Task UpdateClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateHeirarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}", JsonConvert.SerializeObject(request));
        }

        #endregion Models

        #region Train

        public virtual async Task<List<ModelTrainingStatus>> GetApplicationVersionTrainingStatusAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/train");

            return JsonConvert.DeserializeObject<List<ModelTrainingStatus>>(response);
        }

        public virtual async Task TrainApplicationVersionAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/train");
        }

        #endregion Train

        #region User

        public virtual async Task AddExternalApiKeyAsync(ExternalApiKeyRequest request) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, luisApiKeyUrl, JsonConvert.SerializeObject(request));
        }

        public virtual async Task AddSubscriptionKeyAsync(SubscriptionKeySet request) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, luisSubKeyUrl, JsonConvert.SerializeObject(request));
        }

        public virtual async Task DeleteExternalApiKeyAsync(string externalApiKey) {

            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisApiKeyUrl}{externalApiKey}");
        }

        public virtual async Task DeleteSubscriptionKeyAsync(string subscriptionKey) {

            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisSubKeyUrl}{subscriptionKey}");
        }

        public virtual async Task<ExternalApiKeySet> GetExternalApiKeyAsync() {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, luisApiKeyUrl);

            return JsonConvert.DeserializeObject<ExternalApiKeySet>(response);
        }

        public virtual async Task<List<SubscriptionKeySet>> GetSubscriptionKeyAsync() {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, luisApiKeyUrl);

            return JsonConvert.DeserializeObject<List<SubscriptionKeySet>>(response);
        }

        public virtual async Task<string> ResetProgrammaticKeyAsync() {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, luisProgKeyUrl, "");

            return JsonConvert.DeserializeObject<string>(response);
        }

        #endregion User

        #region Versions

        public virtual async Task AssignSubscriptionKeyToVersionAsync(Guid appId, string versionId, string subscriptionKey) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/assignedkey", subscriptionKey);
        }

        public virtual async Task<string> CloneVersionAsync(Guid appId, string versionId, VersionRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/clone", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual async Task DeleteApplicationVersionAsync(Guid appId, string versionId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}");
        }

        public virtual async Task DeleteApplicationVersionExternalKeyAsync(Guid appId, string versionId, string keyType) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/externalKeys/{keyType}");
        }

        public virtual async Task<ApplicationDefinition> ExportApplicationVersionAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/export");

            return JsonConvert.DeserializeObject<ApplicationDefinition>(response);
        }

        public virtual async Task<ApplicationVersion> GetApplicationVersionAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}");

            return JsonConvert.DeserializeObject<ApplicationVersion>(response);
        }

        public virtual async Task<List<ExternalApiKeySet>> GetApplicationVersionExternalApiKeysAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}");

            return JsonConvert.DeserializeObject<List<ExternalApiKeySet>>(response);
        }

        public virtual async Task<SubscriptionKeySet> GetApplicationVersionSubscriptionKeysAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/assignedkey");

            return JsonConvert.DeserializeObject<SubscriptionKeySet>(response);
        }

        public virtual async Task<List<ApplicationVersion>> GetApplicationVersionsAsync(Guid appId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<ApplicationVersion>>(response);
        }

        public virtual async Task<string> GetApplicationVersionsAsync(Guid appId, ApplicationDefinition definition, string versionId = "") {

            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(versionId))
                sb.Append($"versionId={versionId}");

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/import{sb}", JsonConvert.SerializeObject(definition));

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual async Task RenameApplicationVersionAsync(Guid appId, string versionId, VersionRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateApplicationVersionExternalKeyAsync(Guid appId, string versionId, ExternalApiKeyRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{luisUrl}{appId}/versions/{versionId}/externalKeys", JsonConvert.SerializeObject(request));
        }

        #endregion Versions
    }
}