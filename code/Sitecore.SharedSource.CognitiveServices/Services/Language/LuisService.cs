using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Microsoft.SharedSource.CognitiveServices.Repositories.Language;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language {
    public class LuisService : ILuisService
    {

        protected ILuisRepository LuisRepository;
        protected ILogWrapper Logger;

        public LuisService(
            ILuisRepository luisRepository,
            ILogWrapper logger)
        {
            LuisRepository = luisRepository;
            Logger = logger;
        }

        public virtual QueryResult Query(Guid appId, string query)
        {
            try {
                var result = Task.Run(async () => await LuisRepository.QueryAsync(appId, query)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.Query failed", this, ex);
            }

            return null;
        }

        public virtual string AddApplication(AddApplicationRequest request)
        {
            try {
                var result = Task.Run(async () => await LuisRepository.AddApplicationAsync(request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.AddApplication failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteApplication(Guid appId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteApplicationAsync(appId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteApplication failed", this, ex);
            }
        }

        public virtual List<List<string>> DownloadApplicationQueryLogs(Guid appId) {
            try {
                var result = Task.Run(async () => await LuisRepository.DownloadApplicationQueryLogsAsync(appId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.DownloadApplicationQueryLogs failed", this, ex);
            }

            return null;
        }

        public virtual List<ApplicationCulture> GetApplicationCultures() {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationCulturesAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationCultures failed", this, ex);
            }

            return null;
        }

        public virtual List<string> GetApplicationDomains() {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationDomainsAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationDomains failed", this, ex);
            }

            return null;
        }

        public virtual ApplicationInfo GetApplicationInfo(Guid appId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationInfoAsync(appId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationInfo failed", this, ex);
            }

            return null;
        }

        public virtual List<string> GetApplicationUsageScenarios() {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationUsageScenariosAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationUsageScenarios failed", this, ex);
            }

            return null;
        }

        public virtual PersonalAssistantResponse GetPersonalAssistantApplications() {
            try {
                var result = Task.Run(async () => await LuisRepository.GetPersonalAssistantApplicationsAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPersonalAssistantApplications failed", this, ex);
            }

            return null;
        }

        public virtual List<UserApplication> GetUserApplications(int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetUserApplicationsAsync(skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetUserApplications failed", this, ex);
            }

            return null;
        }

        public virtual string ImportApplication(ApplicationDefinition request, string appName = "") {
            try {
                var result = Task.Run(async () => await LuisRepository.ImportApplicationAsync(request, appName)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ImportApplication failed", this, ex);
            }

            return null;
        }

        public virtual PublishResponse PublishApplication(Guid appId, PublishRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.PublishApplicationAsync(appId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.PublishApplication failed", this, ex);
            }

            return null;
        }

        public virtual void RenameApplication(Guid appId, ApplicationRenameRequest request) {
            try {
                Task.Run(async () => await LuisRepository.RenameApplicationAsync(appId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameApplication failed", this, ex);
            }
        }

        public virtual AddLabelResponse AddLabel(Guid appId, string versionId, AddLabelRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.AddLabelAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.AddLabel failed", this, ex);
            }

            return null;
        }

        public virtual List<BatchAddLabelsResponse> BatchAddLabels(Guid appId, string versionId, List<AddLabelRequest> request) {
            try {
                var result = Task.Run(async () => await LuisRepository.BatchAddLabelsAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.BatchAddLabels failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteExampleLabel(Guid appId, string versionId, int exampleId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteExampleLabelAsync(appId, versionId, exampleId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteExampleLabel failed", this, ex);
            }
        }

        public virtual List<LabeledExamples> ReviewLabeledExamples(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.ReviewLabeledExamplesAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ReviewLabeledExamples failed", this, ex);
            }

            return null;
        }

        public virtual int CreatePatternFeature(Guid appId, string versionId, PatternFeature feature) {
            try {
                var result = Task.Run(async () => await LuisRepository.CreatePatternFeatureAsync(appId, versionId, feature)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreatePatternFeature failed", this, ex);
            }

            return -1;
        }

        public virtual int CreatePhraseListFeature(Guid appId, string versionId, PhraseListFeature feature) {
            try {
                var result = Task.Run(async () => await LuisRepository.CreatePhraseListFeatureAsync(appId, versionId, feature)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreatePhraseListFeature failed", this, ex);
            }

            return -1;
        }

        public virtual void DeletePatternFeature(Guid appId, string versionId, int patternId) {
            try {
                Task.Run(async () => await LuisRepository.DeletePatternFeatureAsync(appId, versionId, patternId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePatternFeature failed", this, ex);
            }
        }

        public virtual void DeletePhraseListFeature(Guid appId, string versionId, int phraselistId) {
            try {
                Task.Run(async () => await LuisRepository.DeletePhraseListFeatureAsync(appId, versionId, phraselistId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePhraseListFeature failed", this, ex);
            }
        }

        public virtual ApplicationFeaturesResponse GetApplicationVersionFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionFeaturesAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionFeatures failed", this, ex);
            }

            return null;
        }

        public virtual List<PatternFeature> GetApplicationVersionPatternFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionPatternFeaturesAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionPatternFeatures failed", this, ex);
            }

            return null;
        }

        public virtual List<PhraseListFeature> GetApplicationVersionPhraseListFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionPhraseListFeaturesAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionPhraseListFeatures failed", this, ex);
            }

            return null;
        }

        public virtual PatternFeature GetPatternFeatureInfo(Guid appId, string versionId, int patternId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetPatternFeatureInfoAsync(appId, versionId, patternId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPatternFeatureInfo failed", this, ex);
            }

            return null;
        }

        public virtual PhraseListFeature GetPhraseListFeatureInfo(Guid appId, string versionId, int phraselistId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetPhraseListFeatureInfoAsync(appId, versionId, phraselistId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPhraseListFeatureInfo failed", this, ex);
            }

            return null;
        }

        public virtual void UpdatePatternFeature(Guid appId, string versionId, int patternId, PatternFeature feature) {
            try {
                Task.Run(async () => await LuisRepository.UpdatePatternFeatureAsync(appId, versionId, patternId, feature));
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdatePatternFeature failed", this, ex);
            }
        }

        public virtual void UpdatePhraseListFeature(Guid appId, string versionId, int phraselistId, PhraseListFeature feature) {
            try {
                Task.Run(async () => await LuisRepository.UpdatePhraseListFeatureAsync(appId, versionId, phraselistId, feature));
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdatePhraseListFeature failed", this, ex);
            }
        }

        public virtual List<EntityInfo> AddPrebuiltEntityExtractors(Guid appId, string versionId, List<string> extractorNames) {
            try {
                var result = Task.Run(async () => await LuisRepository.AddPrebuiltEntityExtractorsAsync(appId, versionId, extractorNames)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.AddPrebuiltEntityExtractors failed", this, ex);
            }

            return null;
        }

        public virtual Guid CreateClosedListEntityModel(Guid appId, string versionId, ClosedListEntityRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.CreateClosedListEntityModelAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateClosedListEntityModel failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateCompositeEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.CreateCompositeEntityExtractorAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateCompositeEntityExtractor failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateEntityExtractor(Guid appId, string versionId, NamedEntityRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.CreateEntityExtractorAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateEntityExtractor failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateHeirarchicalEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.CreateHeirarchicalEntityExtractorAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateHeirarchicalEntityExtractor failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateIntentClassifier(Guid appId, string versionId, NamedEntityRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.CreateIntentClassifierAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateIntentClassifier failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual void DeleteClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteClosedListEntityModelAsync(appId, versionId, closedListEntityId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteClosedListEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteCompositeEntityModelAsync(appId, versionId, compositeEntityId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteCompositeEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteEntityModel(Guid appId, string versionId, Guid entityId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteEntityModelAsync(appId, versionId, entityId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteHierarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteHierarchicalEntityModelAsync(appId, versionId, heirarchicalEntityId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteHierarchicalEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteIntentModel(Guid appId, string versionId, Guid intentId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteIntentModelAsync(appId, versionId, intentId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteIntentModel failed", this, ex);
            }
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid prebuiltId) {
            try {
                Task.Run(async () => await LuisRepository.DeletePrebuiltModelAsync(appId, versionId, prebuiltId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePrebuiltModel failed", this, ex);
            }
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid closedListEntityId, int sublistId) {
            try {
                Task.Run(async () => await LuisRepository.DeletePrebuiltModelAsync(appId, versionId, closedListEntityId, sublistId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePrebuiltModel failed", this, ex);
            }
        }

        public virtual ClosedListEntityInfo GetApplicationVersionClosedListInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionClosedListInfosAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionClosedListInfos failed", this, ex);
            }

            return null;
        }

        public virtual ComplexEntityInfo GetApplicationVersionCompositeEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionCompositeEntityInfosAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionCompositeEntityInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionEntityInfosAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionEntityInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<ComplexEntityInfo> GetApplicationVersionHeirarchicalEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionHeirarchicalEntityInfosAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionHeirarchicalEntityInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionIntentInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionIntentInfosAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionIntentInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionModelInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionModelInfosAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionModelInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionPrebuiltInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionPrebuiltInfosAsync(appId, versionId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionPrebuiltInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<PrebuiltEntity> GetAvailablePrebuiltEntityExtractors(Guid appId, string versionId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetAvailablePrebuiltEntityExtractorsAsync(appId, versionId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetAvailablePrebuiltEntityExtractors failed", this, ex);
            }

            return null;
        }

        public virtual ClosedListEntityInfo GetClosedListEntityInfo(Guid appId, string versionId, Guid closedListEntityId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetClosedListEntityInfoAsync(appId, versionId, closedListEntityId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetClosedListEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual ComplexEntityInfo GetCompositeEntityInfo(Guid appId, string versionId, Guid compositeEntityId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetCompositeEntityInfoAsync(appId, versionId, compositeEntityId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetCompositeEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual EntityInfo GetEntityInfo(Guid appId, string versionId, Guid entityId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetEntityInfoAsync(appId, versionId, entityId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual ComplexEntityInfo GetHeirarchicalEntityInfo(Guid appId, string versionId, Guid heirarchicalEntityId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetHeirarchicalEntityInfoAsync(appId, versionId, heirarchicalEntityId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetHeirarchicalEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual EntityInfo GetIntentInfo(Guid appId, string versionId, Guid intentId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetIntentInfoAsync(appId, versionId, intentId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetIntentInfo failed", this, ex);
            }

            return null;
        }

        public virtual EntityInfo GetPrebuiltInfo(Guid appId, string versionId, Guid prebuiltId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetPrebuiltInfoAsync(appId, versionId, prebuiltId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPrebuiltInfo failed", this, ex);
            }

            return null;
        }

        public virtual void PatchClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request) {
            try {
                Task.Run(async () => await LuisRepository.PatchClosedListEntityModelAsync(appId, versionId, closedListEntityId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.PatchClosedListEntityModel failed", this, ex);
            }
        }

        public virtual void RenameEntityModel(Guid appId, string versionId, Guid entityId, NamedEntityRequest request) {
            try {
                Task.Run(async () => await LuisRepository.RenameEntityModelAsync(appId, versionId, entityId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameEntityModel failed", this, ex);
            }
        }

        public virtual void RenameIntentModel(Guid appId, string versionId, Guid intentId, NamedEntityRequest request) {
            try {
                Task.Run(async () => await LuisRepository.RenameIntentModelAsync(appId, versionId, intentId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameIntentModel failed", this, ex);
            }
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForEntities(Guid appId, string versionId, Guid entityId, int take = 10) {
            try {
                var result = Task.Run(async () => await LuisRepository.SuggestEndpointQueriesForEntitiesAsync(appId, versionId, entityId, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.SuggestEndpointQueriesForEntities failed", this, ex);
            }

            return null;
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForIntents(Guid appId, string versionId, Guid intentId, int take = 10) {
            try {
                var response = Task.Run(async () => await LuisRepository.SuggestEndpointQueriesForIntentsAsync(appId, versionId, intentId, take)).Result;

                return response;
            } catch (Exception ex) {
                Logger.Error("LuisService.SuggestEndpointQueriesForIntents failed", this, ex);
            }

            return null;
        }

        public virtual void UpdateClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request) {
            try {
                Task.Run(async () => await LuisRepository.UpdateClosedListEntityModelAsync(appId, versionId, closedListEntityId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateClosedListEntityModel failed", this, ex);
            }
        }

        public virtual void UpdateCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request) {
            try {
                Task.Run(async () => await LuisRepository.UpdateCompositeEntityModelAsync(appId, versionId, compositeEntityId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateCompositeEntityModel failed", this, ex);
            }
        }

        public virtual void UpdateHeirarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request) {
            try {
                Task.Run(async () => await LuisRepository.UpdateHeirarchicalEntityModelAsync(appId, versionId, heirarchicalEntityId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateHeirarchicalEntityModel failed", this, ex);
            }
        }

        public virtual List<ModelTrainingStatus> GetApplicationVersionTrainingStatus(Guid appId, string versionId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionTrainingStatusAsync(appId, versionId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionTrainingStatus failed", this, ex);
            }

            return null;
        }

        public virtual void TrainApplicationVersion(Guid appId, string versionId) {
            try {
                Task.Run(async () => await LuisRepository.TrainApplicationVersionAsync(appId, versionId));
            } catch (Exception ex) {
                Logger.Error("LuisService.TrainApplicationVersion failed", this, ex);
            }
        }

        public virtual void AddExternalApiKey(ExternalApiKeyRequest request) {
            try {
                Task.Run(async () => await LuisRepository.AddExternalApiKeyAsync(request));
            } catch (Exception ex) {
                Logger.Error("LuisService.AddExternalApiKey failed", this, ex);
            }
        }

        public virtual void AddSubscriptionKey(SubscriptionKeySet request) {
            try {
                Task.Run(async () => await LuisRepository.AddSubscriptionKeyAsync(request));
            } catch (Exception ex) {
                Logger.Error("LuisService.AddSubscriptionKey failed", this, ex);
            }
        }

        public virtual void DeleteExternalApiKey(string externalApiKey) {
            try {
                Task.Run(async () => await LuisRepository.DeleteExternalApiKeyAsync(externalApiKey));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteExternalApiKey failed", this, ex);
            }
        }

        public virtual void DeleteSubscriptionKey(string subscriptionKey) {
            try {
                Task.Run(async () => await LuisRepository.DeleteSubscriptionKeyAsync(subscriptionKey));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteSubscriptionKey failed", this, ex);
            }
        }

        public virtual ExternalApiKeySet GetExternalApiKey() {
            try {
                var result = Task.Run(async () => await LuisRepository.GetExternalApiKeyAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetExternalApiKey failed", this, ex);
            }

            return null;
        }

        public virtual List<SubscriptionKeySet> GetSubscriptionKey() {
            try {
                var result = Task.Run(async () => await LuisRepository.GetSubscriptionKeyAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetSubscriptionKey failed", this, ex);
            }

            return null;
        }

        public virtual string ResetProgrammaticKey() {
            try {
                var result = Task.Run(async () => await LuisRepository.ResetProgrammaticKeyAsync()).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ResetProgrammaticKey failed", this, ex);
            }

            return null;
        }

        public virtual void AssignSubscriptionKeyToVersion(Guid appId, string versionId, string subscriptionKey) {
            try {
                Task.Run(async () => await LuisRepository.AssignSubscriptionKeyToVersionAsync(appId, versionId, subscriptionKey));
            } catch (Exception ex) {
                Logger.Error("LuisService.AssignSubscriptionKeyToVersion failed", this, ex);
            }
        }

        public virtual string CloneVersion(Guid appId, string versionId, VersionRequest request) {
            try {
                var result = Task.Run(async () => await LuisRepository.CloneVersionAsync(appId, versionId, request)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CloneVersion failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteApplicationVersion(Guid appId, string versionId) {
            try {
                Task.Run(async () => await LuisRepository.DeleteApplicationVersionAsync(appId, versionId));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteApplicationVersion failed", this, ex);
            }
        }

        public virtual void DeleteApplicationVersionExternalKey(Guid appId, string versionId, string keyType) {
            try {
                Task.Run(async () => await LuisRepository.DeleteApplicationVersionExternalKeyAsync(appId, versionId, keyType));
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteApplicationVersionExternalKey failed", this, ex);
            }
        }

        public virtual ApplicationDefinition ExportApplicationVersion(Guid appId, string versionId) {
            try {
                var result = Task.Run(async () => await LuisRepository.ExportApplicationVersionAsync(appId, versionId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ExportApplicationVersoin failed", this, ex);
            }

            return null;
        }

        public virtual ApplicationVersion GetApplicationVersion(Guid appId, string versionId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionAsync(appId, versionId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersion failed", this, ex);
            }

            return null;
        }

        public virtual List<ExternalApiKeySet> GetApplicationVersionExternalApiKeys(Guid appId, string versionId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionExternalApiKeysAsync(appId, versionId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionExternalApiKeys failed", this, ex);
            }

            return null;
        }

        public virtual SubscriptionKeySet GetApplicationVersionSubscriptionKeys(Guid appId, string versionId) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionSubscriptionKeysAsync(appId, versionId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionSubscriptionKeys failed", this, ex);
            }

            return null;
        }

        public virtual List<ApplicationVersion> GetApplicationVersions(Guid appId, int skip = 0, int take = 100) {
            try {
                var result = Task.Run(async () => await LuisRepository.GetApplicationVersionsAsync(appId, skip, take)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersions failed", this, ex);
            }

            return null;
        }

        public virtual string ImportVersionToApplication(Guid appId, ApplicationDefinition definition, string versionId = "") {
            try {
                var result = Task.Run(async () => await LuisRepository.ImportVersionToApplicationAsync(appId, definition, versionId)).Result;

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersions failed", this, ex);
            }

            return null;
        }

        public virtual void RenameApplicationVersion(Guid appId, string versionId, VersionRequest request) {
            try {
                Task.Run(async () => await LuisRepository.RenameApplicationVersionAsync(appId, versionId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameApplicationVersion failed", this, ex);
            }
        }

        public virtual void UpdateApplicationVersionExternalKey(Guid appId, string versionId, ExternalApiKeyRequest request) {
            try {
                Task.Run(async () => await LuisRepository.UpdateApplicationVersionExternalKeyAsync(appId, versionId, request));
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateApplicationVersionExternalKey failed", this, ex);
            }
        }
    }
}