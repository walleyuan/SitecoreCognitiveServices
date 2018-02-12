using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.CSV;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language {
    public class LuisRepository : ILuisRepository
    {
        protected static readonly string luisQueryUrl = "v2.0/apps/";
        protected static readonly string luisRoot = "api/v2.0/";
        protected static readonly string luisUrl = $"{luisRoot}apps/";
        protected static readonly string luisApiKeyUrl = $"{luisRoot}externalKeys/";
        protected static readonly string luisSubKeyUrl = $"{luisRoot}subscriptions/";
        protected static readonly string luisProgKeyUrl = $"{luisRoot}programmatickey";

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;
        protected readonly ICSVParser CSVParser;

        public LuisRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient,
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

        public virtual LuisResult Query(Guid appId, string query) {
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisQueryUrl}{appId}?subscription-key={ApiKeys.Luis}&verbose=true&q={query}");

            return JsonConvert.DeserializeObject<LuisResult>(response);
        }

        public virtual async Task<LuisResult> QueryAsync(Guid appId, string query)
        {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisQueryUrl}{appId}?subscription-key={ApiKeys.Luis}&verbose=true&q={query}");

            return JsonConvert.DeserializeObject<LuisResult>(response);
        }

        #endregion Querying

        #region Apps

        public virtual string AddApplication(AddApplicationRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, luisUrl, JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual async Task<string> AddApplicationAsync(AddApplicationRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, luisUrl, JsonConvert.SerializeObject(request));

            return response;
        }

        public virtual void DeleteApplication(Guid appId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}");
        }

        public virtual async Task DeleteApplicationAsync(Guid appId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}");
        }
        
        public virtual List<List<string>> DownloadApplicationQueryLogs(Guid appId) {
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/querylogs");

            return CSVParser.ParseCSV(response);
        }

        public virtual async Task<List<List<string>>> DownloadApplicationQueryLogsAsync(Guid appId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/querylogs");

            return CSVParser.ParseCSV(response);
        }

        public virtual List<ApplicationCulture> GetApplicationCultures() {
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}cultures");

            return JsonConvert.DeserializeObject<List<ApplicationCulture>>(response);
        }

        public virtual async Task<List<ApplicationCulture>> GetApplicationCulturesAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}cultures");

            return JsonConvert.DeserializeObject<List<ApplicationCulture>>(response);
        }

        public virtual List<string> GetApplicationDomains() {
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}domains");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<List<string>> GetApplicationDomainsAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}domains");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual ApplicationInfo GetApplicationInfo(Guid appId) {
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}");

            return JsonConvert.DeserializeObject<ApplicationInfo>(response);
        }

        public virtual async Task<ApplicationInfo> GetApplicationInfoAsync(Guid appId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}");

            return JsonConvert.DeserializeObject<ApplicationInfo>(response);
        }

        public virtual List<string> GetApplicationUsageScenarios() {
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}usagescenarios");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual async Task<List<string>> GetApplicationUsageScenariosAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}usagescenarios");

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        public virtual PersonalAssistantResponse GetPersonalAssistantApplications() {
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}assistants");

            return JsonConvert.DeserializeObject<PersonalAssistantResponse>(response);
        }

        public virtual async Task<PersonalAssistantResponse> GetPersonalAssistantApplicationsAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}assistants");

            return JsonConvert.DeserializeObject<PersonalAssistantResponse>(response);
        }

        public virtual List<UserApplication> GetUserApplications(int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<UserApplication>>(response);
        }

        public virtual async Task<List<UserApplication>> GetUserApplicationsAsync(int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<UserApplication>>(response);
        }

        protected virtual string GetImportQuerystring(string appName)
        {
            return string.IsNullOrEmpty(appName) ? "" : $"?appName={appName}";
        }

        public virtual string ImportApplication(ApplicationDefinition request, string appName = "")
        {
            var appQS = GetImportQuerystring(appName);
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}import{appQS}", JsonConvert.SerializeObject(request));
            
            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual async Task<string> ImportApplicationAsync(ApplicationDefinition request, string appName = "") {
            var appQS = GetImportQuerystring(appName);
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}import{appQS}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual PublishResponse PublishApplication(Guid appId, PublishRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/publish", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<PublishResponse>(response);
        }

        public virtual async Task<PublishResponse> PublishApplicationAsync(Guid appId, PublishRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/publish", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<PublishResponse>(response);
        }

        public virtual void RenameApplication(Guid appId, ApplicationRenameRequest request) {
            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task RenameApplicationAsync(Guid appId, ApplicationRenameRequest request) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}", JsonConvert.SerializeObject(request));
        }

        #endregion Apps

        #region Examples

        public virtual AddLabelResponse AddLabel(Guid appId, string versionId, AddLabelRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/example", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<AddLabelResponse>(response);
        }

        public virtual async Task<AddLabelResponse> AddLabelAsync(Guid appId, string versionId, AddLabelRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/example", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<AddLabelResponse>(response);
        }

        public virtual List<BatchAddLabelsResponse> BatchAddLabels(Guid appId, string versionId, List<AddLabelRequest> request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/examples", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<BatchAddLabelsResponse>>(response);
        }

        public virtual async Task<List<BatchAddLabelsResponse>> BatchAddLabelsAsync(Guid appId, string versionId, List<AddLabelRequest> request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/examples", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<BatchAddLabelsResponse>>(response);
        }

        public virtual void DeleteExampleLabel(Guid appId, string versionId, int exampleId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/examples/{exampleId}");
        }

        public virtual async Task DeleteExampleLabelAsync(Guid appId, string versionId, int exampleId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/examples/{exampleId}");
        }

        public virtual List<LabeledExamples> ReviewLabeledExamples(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/examples{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        public virtual async Task<List<LabeledExamples>> ReviewLabeledExamplesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/examples{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        #endregion Examples

        #region Features

        public virtual int CreatePatternFeature(Guid appId, string versionId, PatternFeature feature) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual async Task<int> CreatePatternFeatureAsync(Guid appId, string versionId, PatternFeature feature) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual int CreatePhraseListFeature(Guid appId, string versionId, PhraseListFeature feature) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual async Task<int> CreatePhraseListFeatureAsync(Guid appId, string versionId, PhraseListFeature feature) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists", JsonConvert.SerializeObject(feature));

            return JsonConvert.DeserializeObject<int>(response);
        }

        public virtual void DeletePatternFeature(Guid appId, string versionId, int patternId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");
        }

        public virtual async Task DeletePatternFeatureAsync(Guid appId, string versionId, int patternId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");
        }

        public virtual void DeletePhraseListFeature(Guid appId, string versionId, int phraselistId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");
        }

        public virtual async Task DeletePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");
        }

        public virtual ApplicationFeaturesResponse GetApplicationVersionFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/feature{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ApplicationFeaturesResponse>(response);
        }

        public virtual async Task<ApplicationFeaturesResponse> GetApplicationVersionFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/feature{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ApplicationFeaturesResponse>(response);
        }

        public virtual List<PatternFeature> GetApplicationVersionPatternFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PatternFeature>>(response);
        }

        public virtual async Task<List<PatternFeature>> GetApplicationVersionPatternFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PatternFeature>>(response);
        }

        public virtual List<PhraseListFeature> GetApplicationVersionPhraseListFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PhraseListFeature>>(response);
        }

        public virtual async Task<List<PhraseListFeature>> GetApplicationVersionPhraseListFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<PhraseListFeature>>(response);
        }

        public virtual PatternFeature GetPatternFeatureInfo(Guid appId, string versionId, int patternId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");

            return JsonConvert.DeserializeObject<PatternFeature>(response);
        }

        public virtual async Task<PatternFeature> GetPatternFeatureInfoAsync(Guid appId, string versionId, int patternId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}");

            return JsonConvert.DeserializeObject<PatternFeature>(response);
        }

        public virtual PhraseListFeature GetPhraseListFeatureInfo(Guid appId, string versionId, int phraselistId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");

            return JsonConvert.DeserializeObject<PhraseListFeature>(response);
        }

        public virtual async Task<PhraseListFeature> GetPhraseListFeatureInfoAsync(Guid appId, string versionId, int phraselistId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}");

            return JsonConvert.DeserializeObject<PhraseListFeature>(response);
        }

        public virtual void UpdatePatternFeature(Guid appId, string versionId, int patternId, PatternFeature feature) {

            var response = RepositoryClient.SendJsonUpdate(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}", JsonConvert.SerializeObject(feature));
        }

        public virtual async Task UpdatePatternFeatureAsync(Guid appId, string versionId, int patternId, PatternFeature feature) {

            var response = await RepositoryClient.SendJsonUpdateAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/patterns/{patternId}", JsonConvert.SerializeObject(feature));
        }

        public virtual void UpdatePhraseListFeature(Guid appId, string versionId, int phraselistId, PhraseListFeature feature) {

            var response = RepositoryClient.SendJsonUpdate(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}", JsonConvert.SerializeObject(feature));
        }

        public virtual async Task UpdatePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId, PhraseListFeature feature) {

            var response = await RepositoryClient.SendJsonUpdateAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/phraselists/{phraselistId}", JsonConvert.SerializeObject(feature));
        }

        #endregion Features

        #region Models

        public virtual List<EntityInfo> AddPrebuiltEntityExtractors(Guid appId, string versionId, List<string> extractorNames) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts", JsonConvert.SerializeObject(extractorNames));

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> AddPrebuiltEntityExtractorsAsync(Guid appId, string versionId, List<string> extractorNames) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts", JsonConvert.SerializeObject(extractorNames));

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual Guid CreateClosedListEntityModel(Guid appId, string versionId, ClosedListEntityRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateClosedListEntityModelAsync(Guid appId, string versionId, ClosedListEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual Guid CreateCompositeEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateCompositeEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual Guid CreateEntityExtractor(Guid appId, string versionId, NamedEntityRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateEntityExtractorAsync(Guid appId, string versionId, NamedEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual Guid CreateHeirarchicalEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateHeirarchicalEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual Guid CreateIntentClassifier(Guid appId, string versionId, NamedEntityRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual async Task<Guid> CreateIntentClassifierAsync(Guid appId, string versionId, NamedEntityRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<Guid>(response);
        }

        public virtual void DeleteClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}");
        }

        public virtual async Task DeleteClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}");
        }

        public virtual void DeleteCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}");
        }

        public virtual async Task DeleteCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}");
        }

        public virtual void DeleteEntityModel(Guid appId, string versionId, Guid entityId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}");
        }

        public virtual async Task DeleteEntityModelAsync(Guid appId, string versionId, Guid entityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}");
        }

        public virtual void DeleteHierarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}");
        }

        public virtual async Task DeleteHierarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}");
        }

        public virtual void DeleteIntentModel(Guid appId, string versionId, Guid intentId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}");
        }

        public virtual async Task DeleteIntentModelAsync(Guid appId, string versionId, Guid intentId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}");
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid prebuiltId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts/{prebuiltId}");
        }

        public virtual async Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid prebuiltId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts/{prebuiltId}");
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid closedListEntityId, int sublistId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}/sublists/{sublistId}");
        }

        public virtual async Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid closedListEntityId, int sublistId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}/sublists/{sublistId}");
        }

        public virtual ClosedListEntityInfo GetApplicationVersionClosedListInfos(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ClosedListEntityInfo>(response);
        }

        public virtual async Task<ClosedListEntityInfo> GetApplicationVersionClosedListInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ClosedListEntityInfo>(response);
        }

        public virtual ComplexEntityInfo GetApplicationVersionCompositeEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual async Task<ComplexEntityInfo> GetApplicationVersionCompositeEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual List<EntityInfo> GetApplicationVersionEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual List<ComplexEntityInfo> GetApplicationVersionHeirarchicalEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<ComplexEntityInfo>>(response);
        }

        public virtual async Task<List<ComplexEntityInfo>> GetApplicationVersionHeirarchicalEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<ComplexEntityInfo>>(response);
        }

        public virtual List<EntityInfo> GetApplicationVersionIntentInfos(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionIntentInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual List<EntityInfo> GetApplicationVersionModelInfos(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/models{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionModelInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/models{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual List<EntityInfo> GetApplicationVersionPrebuiltInfos(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual async Task<List<EntityInfo>> GetApplicationVersionPrebuiltInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<EntityInfo>>(response);
        }

        public virtual List<PrebuiltEntity> GetAvailablePrebuiltEntityExtractors(Guid appId, string versionId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/listprebuilts");

            return JsonConvert.DeserializeObject<List<PrebuiltEntity>>(response);
        }

        public virtual async Task<List<PrebuiltEntity>> GetAvailablePrebuiltEntityExtractorsAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/listprebuilts");

            return JsonConvert.DeserializeObject<List<PrebuiltEntity>>(response);
        }

        public virtual ClosedListEntityInfo GetClosedListEntityInfo(Guid appId, string versionId, Guid closedListEntityId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}");

            return JsonConvert.DeserializeObject<ClosedListEntityInfo>(response);
        }

        public virtual async Task<ClosedListEntityInfo> GetClosedListEntityInfoAsync(Guid appId, string versionId, Guid closedListEntityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}");

            return JsonConvert.DeserializeObject<ClosedListEntityInfo>(response);
        }

        public virtual ComplexEntityInfo GetCompositeEntityInfo(Guid appId, string versionId, Guid compositeEntityId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual async Task<ComplexEntityInfo> GetCompositeEntityInfoAsync(Guid appId, string versionId, Guid compositeEntityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual EntityInfo GetEntityInfo(Guid appId, string versionId, Guid entityId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual async Task<EntityInfo> GetEntityInfoAsync(Guid appId, string versionId, Guid entityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual ComplexEntityInfo GetHeirarchicalEntityInfo(Guid appId, string versionId, Guid heirarchicalEntityId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual async Task<ComplexEntityInfo> GetHeirarchicalEntityInfoAsync(Guid appId, string versionId, Guid heirarchicalEntityId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}");

            return JsonConvert.DeserializeObject<ComplexEntityInfo>(response);
        }

        public virtual EntityInfo GetIntentInfo(Guid appId, string versionId, Guid intentId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual async Task<EntityInfo> GetIntentInfoAsync(Guid appId, string versionId, Guid intentId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual EntityInfo GetPrebuiltInfo(Guid appId, string versionId, Guid prebuiltId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts/{prebuiltId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual async Task<EntityInfo> GetPrebuiltInfoAsync(Guid appId, string versionId, Guid prebuiltId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/prebuilts/{prebuiltId}");

            return JsonConvert.DeserializeObject<EntityInfo>(response);
        }

        public virtual void PatchClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request) {

            var response = RepositoryClient.SendJsonPatch(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task PatchClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request) {

            var response = await RepositoryClient.SendJsonPatchAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual void RenameEntityModel(Guid appId, string versionId, Guid entityId, NamedEntityRequest request) {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task RenameEntityModelAsync(Guid appId, string versionId, Guid entityId, NamedEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}", JsonConvert.SerializeObject(request));
        }

        public virtual void RenameIntentModel(Guid appId, string versionId, Guid intentId, NamedEntityRequest request) {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task RenameIntentModelAsync(Guid appId, string versionId, Guid intentId, NamedEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}", JsonConvert.SerializeObject(request));
        }

        protected virtual string GetTakeQuerystring(int take)
        {
            StringBuilder sb = new StringBuilder();
            if (take != 10 && take > 0)
                sb.Append($"?take={take}");

            return sb.ToString();
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForEntities(Guid appId, string versionId, Guid entityId, int take = 10) {
            var qs = GetTakeQuerystring(take);
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}/suggest{qs}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        public virtual async Task<List<LabeledExamples>> SuggestEndpointQueriesForEntitiesAsync(Guid appId, string versionId, Guid entityId, int take = 10)
        {
            var qs = GetTakeQuerystring(take);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/entities/{entityId}/suggest{qs}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForIntents(Guid appId, string versionId, Guid intentId, int take = 10) {
            var qs = GetTakeQuerystring(take);
            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}/suggest{qs}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        public virtual async Task<List<LabeledExamples>> SuggestEndpointQueriesForIntentsAsync(Guid appId, string versionId, Guid intentId, int take = 10) {
            var qs = GetTakeQuerystring(take);
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/intents/{intentId}/suggest{qs}");

            return JsonConvert.DeserializeObject<List<LabeledExamples>>(response);
        }

        public virtual void UpdateClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request) {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/closedlists/{closedListEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual void UpdateCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request) {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/compositeentities/{compositeEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual void UpdateHeirarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request) {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateHeirarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/hierarchicalentities/{heirarchicalEntityId}", JsonConvert.SerializeObject(request));
        }

        #endregion Models

        #region Train

        public virtual List<ModelTrainingStatus> GetApplicationVersionTrainingStatus(Guid appId, string versionId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/train");

            return JsonConvert.DeserializeObject<List<ModelTrainingStatus>>(response);
        }

        public virtual async Task<List<ModelTrainingStatus>> GetApplicationVersionTrainingStatusAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/train");

            return JsonConvert.DeserializeObject<List<ModelTrainingStatus>>(response);
        }

        public virtual void TrainApplicationVersion(Guid appId, string versionId) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/train", "{}");
        }

        public virtual async Task TrainApplicationVersionAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/train", "{}");
        }

        #endregion Train

        #region User

        public virtual void AddExternalApiKey(ExternalApiKeyRequest request) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task AddExternalApiKeyAsync(ExternalApiKeyRequest request) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}", JsonConvert.SerializeObject(request));
        }

        public virtual void AddSubscriptionKey(SubscriptionKeySet request) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisSubKeyUrl}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task AddSubscriptionKeyAsync(SubscriptionKeySet request) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisSubKeyUrl}", JsonConvert.SerializeObject(request));
        }

        public virtual void DeleteExternalApiKey(string externalApiKey) {

            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}{externalApiKey}");
        }

        public virtual async Task DeleteExternalApiKeyAsync(string externalApiKey) {

            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}{externalApiKey}");
        }

        public virtual void DeleteSubscriptionKey(string subscriptionKey) {

            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisSubKeyUrl}{subscriptionKey}");
        }

        public virtual async Task DeleteSubscriptionKeyAsync(string subscriptionKey) {

            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisSubKeyUrl}{subscriptionKey}");
        }

        public virtual List<ExternalApiKeySet> GetExternalApiKey() {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}");

            return JsonConvert.DeserializeObject<List<ExternalApiKeySet>>(response);
        }

        public virtual async Task<List<ExternalApiKeySet>> GetExternalApiKeyAsync() {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}");

            return JsonConvert.DeserializeObject<List<ExternalApiKeySet>>(response);
        }

        public virtual List<SubscriptionKeySet> GetSubscriptionKey() {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}");

            return JsonConvert.DeserializeObject<List<SubscriptionKeySet>>(response);
        }

        public virtual async Task<List<SubscriptionKeySet>> GetSubscriptionKeyAsync() {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisApiKeyUrl}");

            return JsonConvert.DeserializeObject<List<SubscriptionKeySet>>(response);
        }

        public virtual string ResetProgrammaticKey() {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisProgKeyUrl}", "");

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual async Task<string> ResetProgrammaticKeyAsync() {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisProgKeyUrl}", "");

            return JsonConvert.DeserializeObject<string>(response);
        }

        #endregion User

        #region Versions

        public virtual void AssignSubscriptionKeyToVersion(Guid appId, string versionId, string subscriptionKey) {
            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/assignedkey", subscriptionKey);
        }

        public virtual async Task AssignSubscriptionKeyToVersionAsync(Guid appId, string versionId, string subscriptionKey) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/assignedkey", subscriptionKey);
        }

        public virtual string CloneVersion(Guid appId, string versionId, VersionRequest request) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/clone", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual async Task<string> CloneVersionAsync(Guid appId, string versionId, VersionRequest request) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/clone", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual void DeleteApplicationVersion(Guid appId, string versionId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}");
        }

        public virtual async Task DeleteApplicationVersionAsync(Guid appId, string versionId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}");
        }

        public virtual void DeleteApplicationVersionExternalKey(Guid appId, string versionId, string keyType) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/externalKeys/{keyType}");
        }

        public virtual async Task DeleteApplicationVersionExternalKeyAsync(Guid appId, string versionId, string keyType) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/externalKeys/{keyType}");
        }

        public virtual ApplicationDefinition ExportApplicationVersion(Guid appId, string versionId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/export");

            return JsonConvert.DeserializeObject<ApplicationDefinition>(response);
        }

        public virtual async Task<ApplicationDefinition> ExportApplicationVersionAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/export");

            return JsonConvert.DeserializeObject<ApplicationDefinition>(response);
        }

        public virtual ApplicationVersion GetApplicationVersion(Guid appId, string versionId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}");

            return JsonConvert.DeserializeObject<ApplicationVersion>(response);
        }

        public virtual async Task<ApplicationVersion> GetApplicationVersionAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}");

            return JsonConvert.DeserializeObject<ApplicationVersion>(response);
        }

        public virtual List<ExternalApiKeySet> GetApplicationVersionExternalApiKeys(Guid appId, string versionId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}");

            return JsonConvert.DeserializeObject<List<ExternalApiKeySet>>(response);
        }

        public virtual async Task<List<ExternalApiKeySet>> GetApplicationVersionExternalApiKeysAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}");

            return JsonConvert.DeserializeObject<List<ExternalApiKeySet>>(response);
        }

        public virtual SubscriptionKeySet GetApplicationVersionSubscriptionKeys(Guid appId, string versionId) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/assignedkey");

            return JsonConvert.DeserializeObject<SubscriptionKeySet>(response);
        }

        public virtual async Task<SubscriptionKeySet> GetApplicationVersionSubscriptionKeysAsync(Guid appId, string versionId) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/assignedkey");

            return JsonConvert.DeserializeObject<SubscriptionKeySet>(response);
        }

        public virtual List<ApplicationVersion> GetApplicationVersions(Guid appId, int skip = 0, int take = 100) {

            var response = RepositoryClient.SendGet(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<ApplicationVersion>>(response);
        }

        public virtual async Task<List<ApplicationVersion>> GetApplicationVersionsAsync(Guid appId, int skip = 0, int take = 100) {

            var response = await RepositoryClient.SendGetAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions{GetSkipTakeQuerystring(skip, take)}");

            return JsonConvert.DeserializeObject<List<ApplicationVersion>>(response);
        }

        protected virtual string GetAppVersionQuerystring(string versionId)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(versionId))
                sb.Append($"versionId={versionId}");

            return sb.ToString();
        }

        public virtual string ImportVersionToApplication(Guid appId, ApplicationDefinition definition, string versionId = "") {

            var qs = GetAppVersionQuerystring(versionId);
            var response = RepositoryClient.SendJsonPost(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/import{qs}", JsonConvert.SerializeObject(definition));

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual async Task<string> ImportVersionToApplicationAsync(Guid appId, ApplicationDefinition definition, string versionId = "")
        {

            var qs = GetAppVersionQuerystring(versionId);
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/import{qs}", JsonConvert.SerializeObject(definition));

            return JsonConvert.DeserializeObject<string>(response);
        }

        public virtual void RenameApplicationVersion(Guid appId, string versionId, VersionRequest request) {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}", JsonConvert.SerializeObject(request));
        }

        public virtual async Task RenameApplicationVersionAsync(Guid appId, string versionId, VersionRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}", JsonConvert.SerializeObject(request));
        }

        public virtual void UpdateApplicationVersionExternalKey(Guid appId, string versionId, ExternalApiKeyRequest request) {

            var response = RepositoryClient.SendJsonPut(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/externalKeys", JsonConvert.SerializeObject(request));
        }

        public virtual async Task UpdateApplicationVersionExternalKeyAsync(Guid appId, string versionId, ExternalApiKeyRequest request) {

            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Luis, $"{ApiKeys.LuisEndpoint}{luisUrl}{appId}/versions/{versionId}/externalKeys", JsonConvert.SerializeObject(request));
        }

        #endregion Versions
    }
}