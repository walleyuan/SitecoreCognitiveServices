using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Language;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.Language {
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

        public virtual LuisResult Query(Guid appId, string query)
        {
            try {
                var result = LuisRepository.Query(appId, query);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.Query failed", this, ex);
            }

            return null;
        }

        public virtual string AddApplication(AddApplicationRequest request)
        {
            try {
                var result = LuisRepository.AddApplication(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.AddApplication failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteApplication(Guid appId) {
            try {
                LuisRepository.DeleteApplication(appId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteApplication failed", this, ex);
            }
        }

        public virtual List<List<string>> DownloadApplicationQueryLogs(Guid appId) {
            try {
                var result = LuisRepository.DownloadApplicationQueryLogs(appId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.DownloadApplicationQueryLogs failed", this, ex);
            }

            return null;
        }

        public virtual List<ApplicationCulture> GetApplicationCultures() {
            try {
                var result = LuisRepository.GetApplicationCultures();

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationCultures failed", this, ex);
            }

            return null;
        }

        public virtual List<string> GetApplicationDomains() {
            try {
                var result = LuisRepository.GetApplicationDomains();

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationDomains failed", this, ex);
            }

            return null;
        }

        public virtual ApplicationInfo GetApplicationInfo(Guid appId) {
            try {
                var result = LuisRepository.GetApplicationInfo(appId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationInfo failed", this, ex);
            }

            return null;
        }

        public virtual List<string> GetApplicationUsageScenarios() {
            try {
                var result = LuisRepository.GetApplicationUsageScenarios();

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationUsageScenarios failed", this, ex);
            }

            return null;
        }

        public virtual PersonalAssistantResponse GetPersonalAssistantApplications() {
            try {
                var result = LuisRepository.GetPersonalAssistantApplications();

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPersonalAssistantApplications failed", this, ex);
            }

            return null;
        }

        public virtual List<UserApplication> GetUserApplications(int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetUserApplications(skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetUserApplications failed", this, ex);
            }

            return null;
        }

        public virtual string ImportApplication(ApplicationDefinition request, string appName = "") {
            try {
                var result = LuisRepository.ImportApplication(request, appName);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ImportApplication failed", this, ex);
            }

            return null;
        }

        public virtual PublishResponse PublishApplication(Guid appId, PublishRequest request) {
            try {
                var result = LuisRepository.PublishApplication(appId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.PublishApplication failed", this, ex);
            }

            return null;
        }

        public virtual void RenameApplication(Guid appId, ApplicationRenameRequest request) {
            try {
                LuisRepository.RenameApplication(appId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameApplication failed", this, ex);
            }
        }

        public virtual AddLabelResponse AddLabel(Guid appId, string versionId, AddLabelRequest request) {
            try {
                var result = LuisRepository.AddLabel(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.AddLabel failed", this, ex);
            }

            return null;
        }

        public virtual List<BatchAddLabelsResponse> BatchAddLabels(Guid appId, string versionId, List<AddLabelRequest> request) {
            try {
                var result = LuisRepository.BatchAddLabels(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.BatchAddLabels failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteExampleLabel(Guid appId, string versionId, int exampleId) {
            try {
                LuisRepository.DeleteExampleLabel(appId, versionId, exampleId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteExampleLabel failed", this, ex);
            }
        }

        public virtual List<LabeledExamples> ReviewLabeledExamples(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.ReviewLabeledExamples(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ReviewLabeledExamples failed", this, ex);
            }

            return null;
        }

        public virtual int CreatePatternFeature(Guid appId, string versionId, PatternFeature feature) {
            try {
                var result = LuisRepository.CreatePatternFeature(appId, versionId, feature);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreatePatternFeature failed", this, ex);
            }

            return -1;
        }

        public virtual int CreatePhraseListFeature(Guid appId, string versionId, PhraseListFeature feature) {
            try {
                var result = LuisRepository.CreatePhraseListFeature(appId, versionId, feature);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreatePhraseListFeature failed", this, ex);
            }

            return -1;
        }

        public virtual void DeletePatternFeature(Guid appId, string versionId, int patternId) {
            try {
                LuisRepository.DeletePatternFeature(appId, versionId, patternId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePatternFeature failed", this, ex);
            }
        }

        public virtual void DeletePhraseListFeature(Guid appId, string versionId, int phraselistId) {
            try {
                LuisRepository.DeletePhraseListFeature(appId, versionId, phraselistId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePhraseListFeature failed", this, ex);
            }
        }

        public virtual ApplicationFeaturesResponse GetApplicationVersionFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionFeatures(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionFeatures failed", this, ex);
            }

            return null;
        }

        public virtual List<PatternFeature> GetApplicationVersionPatternFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionPatternFeatures(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionPatternFeatures failed", this, ex);
            }

            return null;
        }

        public virtual List<PhraseListFeature> GetApplicationVersionPhraseListFeatures(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionPhraseListFeatures(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionPhraseListFeatures failed", this, ex);
            }

            return null;
        }

        public virtual PatternFeature GetPatternFeatureInfo(Guid appId, string versionId, int patternId) {
            try {
                var result = LuisRepository.GetPatternFeatureInfo(appId, versionId, patternId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPatternFeatureInfo failed", this, ex);
            }

            return null;
        }

        public virtual PhraseListFeature GetPhraseListFeatureInfo(Guid appId, string versionId, int phraselistId) {
            try {
                var result = LuisRepository.GetPhraseListFeatureInfo(appId, versionId, phraselistId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPhraseListFeatureInfo failed", this, ex);
            }

            return null;
        }

        public virtual void UpdatePatternFeature(Guid appId, string versionId, int patternId, PatternFeature feature) {
            try {
                LuisRepository.UpdatePatternFeature(appId, versionId, patternId, feature);
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdatePatternFeature failed", this, ex);
            }
        }

        public virtual void UpdatePhraseListFeature(Guid appId, string versionId, int phraselistId, PhraseListFeature feature) {
            try {
                LuisRepository.UpdatePhraseListFeature(appId, versionId, phraselistId, feature);
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdatePhraseListFeature failed", this, ex);
            }
        }

        public virtual List<EntityInfo> AddPrebuiltEntityExtractors(Guid appId, string versionId, List<string> extractorNames) {
            try {
                var result = LuisRepository.AddPrebuiltEntityExtractors(appId, versionId, extractorNames);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.AddPrebuiltEntityExtractors failed", this, ex);
            }

            return null;
        }

        public virtual Guid CreateClosedListEntityModel(Guid appId, string versionId, ClosedListEntityRequest request) {
            try {
                var result = LuisRepository.CreateClosedListEntityModel(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateClosedListEntityModel failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateCompositeEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request) {
            try {
                var result = LuisRepository.CreateCompositeEntityExtractor(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateCompositeEntityExtractor failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateEntityExtractor(Guid appId, string versionId, NamedEntityRequest request) {
            try {
                var result = LuisRepository.CreateEntityExtractor(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateEntityExtractor failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateHeirarchicalEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request) {
            try {
                var result = LuisRepository.CreateHeirarchicalEntityExtractor(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateHeirarchicalEntityExtractor failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual Guid CreateIntentClassifier(Guid appId, string versionId, NamedEntityRequest request) {
            try {
                var result = LuisRepository.CreateIntentClassifier(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CreateIntentClassifier failed", this, ex);
            }

            return Guid.Empty;
        }

        public virtual void DeleteClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId) {
            try {
                LuisRepository.DeleteClosedListEntityModel(appId, versionId, closedListEntityId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteClosedListEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId) {
            try {
                LuisRepository.DeleteCompositeEntityModel(appId, versionId, compositeEntityId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteCompositeEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteEntityModel(Guid appId, string versionId, Guid entityId) {
            try {
                LuisRepository.DeleteEntityModel(appId, versionId, entityId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteHierarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId) {
            try {
                LuisRepository.DeleteHierarchicalEntityModel(appId, versionId, heirarchicalEntityId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteHierarchicalEntityModel failed", this, ex);
            }
        }

        public virtual void DeleteIntentModel(Guid appId, string versionId, Guid intentId) {
            try {
                LuisRepository.DeleteIntentModel(appId, versionId, intentId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteIntentModel failed", this, ex);
            }
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid prebuiltId) {
            try {
                LuisRepository.DeletePrebuiltModel(appId, versionId, prebuiltId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePrebuiltModel failed", this, ex);
            }
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid closedListEntityId, int sublistId) {
            try {
                LuisRepository.DeletePrebuiltModel(appId, versionId, closedListEntityId, sublistId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeletePrebuiltModel failed", this, ex);
            }
        }

        public virtual ClosedListEntityInfo GetApplicationVersionClosedListInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionClosedListInfos(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionClosedListInfos failed", this, ex);
            }

            return null;
        }

        public virtual ComplexEntityInfo GetApplicationVersionCompositeEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionCompositeEntityInfos(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionCompositeEntityInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionEntityInfos(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionEntityInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<ComplexEntityInfo> GetApplicationVersionHeirarchicalEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionHeirarchicalEntityInfos(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionHeirarchicalEntityInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionIntentInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionIntentInfos(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionIntentInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionModelInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionModelInfos(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionModelInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityInfo> GetApplicationVersionPrebuiltInfos(Guid appId, string versionId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersionPrebuiltInfos(appId, versionId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionPrebuiltInfos failed", this, ex);
            }

            return null;
        }

        public virtual List<PrebuiltEntity> GetAvailablePrebuiltEntityExtractors(Guid appId, string versionId) {
            try {
                var result = LuisRepository.GetAvailablePrebuiltEntityExtractors(appId, versionId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetAvailablePrebuiltEntityExtractors failed", this, ex);
            }

            return null;
        }

        public virtual ClosedListEntityInfo GetClosedListEntityInfo(Guid appId, string versionId, Guid closedListEntityId) {
            try {
                var result = LuisRepository.GetClosedListEntityInfo(appId, versionId, closedListEntityId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetClosedListEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual ComplexEntityInfo GetCompositeEntityInfo(Guid appId, string versionId, Guid compositeEntityId) {
            try {
                var result = LuisRepository.GetCompositeEntityInfo(appId, versionId, compositeEntityId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetCompositeEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual EntityInfo GetEntityInfo(Guid appId, string versionId, Guid entityId) {
            try {
                var result = LuisRepository.GetEntityInfo(appId, versionId, entityId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual ComplexEntityInfo GetHeirarchicalEntityInfo(Guid appId, string versionId, Guid heirarchicalEntityId) {
            try {
                var result = LuisRepository.GetHeirarchicalEntityInfo(appId, versionId, heirarchicalEntityId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetHeirarchicalEntityInfo failed", this, ex);
            }

            return null;
        }

        public virtual EntityInfo GetIntentInfo(Guid appId, string versionId, Guid intentId) {
            try {
                var result = LuisRepository.GetIntentInfo(appId, versionId, intentId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetIntentInfo failed", this, ex);
            }

            return null;
        }

        public virtual EntityInfo GetPrebuiltInfo(Guid appId, string versionId, Guid prebuiltId) {
            try {
                var result = LuisRepository.GetPrebuiltInfo(appId, versionId, prebuiltId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetPrebuiltInfo failed", this, ex);
            }

            return null;
        }

        public virtual void PatchClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request) {
            try {
                LuisRepository.PatchClosedListEntityModel(appId, versionId, closedListEntityId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.PatchClosedListEntityModel failed", this, ex);
            }
        }

        public virtual void RenameEntityModel(Guid appId, string versionId, Guid entityId, NamedEntityRequest request) {
            try {
                LuisRepository.RenameEntityModel(appId, versionId, entityId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameEntityModel failed", this, ex);
            }
        }

        public virtual void RenameIntentModel(Guid appId, string versionId, Guid intentId, NamedEntityRequest request) {
            try {
                LuisRepository.RenameIntentModel(appId, versionId, intentId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameIntentModel failed", this, ex);
            }
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForEntities(Guid appId, string versionId, Guid entityId, int take = 10) {
            try {
                var result = LuisRepository.SuggestEndpointQueriesForEntities(appId, versionId, entityId, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.SuggestEndpointQueriesForEntities failed", this, ex);
            }

            return null;
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForIntents(Guid appId, string versionId, Guid intentId, int take = 10) {
            try {
                var response = LuisRepository.SuggestEndpointQueriesForIntents(appId, versionId, intentId, take);

                return response;
            } catch (Exception ex) {
                Logger.Error("LuisService.SuggestEndpointQueriesForIntents failed", this, ex);
            }

            return null;
        }

        public virtual void UpdateClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request) {
            try {
                LuisRepository.UpdateClosedListEntityModel(appId, versionId, closedListEntityId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateClosedListEntityModel failed", this, ex);
            }
        }

        public virtual void UpdateCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request) {
            try {
                LuisRepository.UpdateCompositeEntityModel(appId, versionId, compositeEntityId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateCompositeEntityModel failed", this, ex);
            }
        }

        public virtual void UpdateHeirarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request) {
            try {
                LuisRepository.UpdateHeirarchicalEntityModel(appId, versionId, heirarchicalEntityId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateHeirarchicalEntityModel failed", this, ex);
            }
        }

        public virtual List<ModelTrainingStatus> GetApplicationVersionTrainingStatus(Guid appId, string versionId) {
            try {
                var result = LuisRepository.GetApplicationVersionTrainingStatus(appId, versionId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionTrainingStatus failed", this, ex);
            }

            return null;
        }

        public virtual void TrainApplicationVersion(Guid appId, string versionId) {
            try {
                LuisRepository.TrainApplicationVersion(appId, versionId);
            } catch (Exception ex) {
                Logger.Error("LuisService.TrainApplicationVersion failed", this, ex);
            }
        }

        public virtual void AddExternalApiKey(ExternalApiKeyRequest request) {
            try {
                LuisRepository.AddExternalApiKey(request);
            } catch (Exception ex) {
                Logger.Error("LuisService.AddExternalApiKey failed", this, ex);
            }
        }

        public virtual void AddSubscriptionKey(SubscriptionKeySet request) {
            try {
                LuisRepository.AddSubscriptionKey(request);
            } catch (Exception ex) {
                Logger.Error("LuisService.AddSubscriptionKey failed", this, ex);
            }
        }

        public virtual void DeleteExternalApiKey(string externalApiKey) {
            try {
                LuisRepository.DeleteExternalApiKey(externalApiKey);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteExternalApiKey failed", this, ex);
            }
        }

        public virtual void DeleteSubscriptionKey(string subscriptionKey) {
            try {
                LuisRepository.DeleteSubscriptionKey(subscriptionKey);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteSubscriptionKey failed", this, ex);
            }
        }

        public virtual ExternalApiKeySet GetExternalApiKey() {
            try {
                var result = LuisRepository.GetExternalApiKey();

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetExternalApiKey failed", this, ex);
            }

            return null;
        }

        public virtual List<SubscriptionKeySet> GetSubscriptionKey() {
            try {
                var result = LuisRepository.GetSubscriptionKey();

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetSubscriptionKey failed", this, ex);
            }

            return null;
        }

        public virtual string ResetProgrammaticKey() {
            try {
                var result = LuisRepository.ResetProgrammaticKey();

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ResetProgrammaticKey failed", this, ex);
            }

            return null;
        }

        public virtual void AssignSubscriptionKeyToVersion(Guid appId, string versionId, string subscriptionKey) {
            try {
                LuisRepository.AssignSubscriptionKeyToVersion(appId, versionId, subscriptionKey);
            } catch (Exception ex) {
                Logger.Error("LuisService.AssignSubscriptionKeyToVersion failed", this, ex);
            }
        }

        public virtual string CloneVersion(Guid appId, string versionId, VersionRequest request) {
            try {
                var result = LuisRepository.CloneVersion(appId, versionId, request);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.CloneVersion failed", this, ex);
            }

            return null;
        }

        public virtual void DeleteApplicationVersion(Guid appId, string versionId) {
            try {
                LuisRepository.DeleteApplicationVersion(appId, versionId);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteApplicationVersion failed", this, ex);
            }
        }

        public virtual void DeleteApplicationVersionExternalKey(Guid appId, string versionId, string keyType) {
            try {
                LuisRepository.DeleteApplicationVersionExternalKey(appId, versionId, keyType);
            } catch (Exception ex) {
                Logger.Error("LuisService.DeleteApplicationVersionExternalKey failed", this, ex);
            }
        }

        public virtual ApplicationDefinition ExportApplicationVersion(Guid appId, string versionId) {
            try {
                var result = LuisRepository.ExportApplicationVersion(appId, versionId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.ExportApplicationVersoin failed", this, ex);
            }

            return null;
        }

        public virtual ApplicationVersion GetApplicationVersion(Guid appId, string versionId) {
            try {
                var result = LuisRepository.GetApplicationVersion(appId, versionId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersion failed", this, ex);
            }

            return null;
        }

        public virtual List<ExternalApiKeySet> GetApplicationVersionExternalApiKeys(Guid appId, string versionId) {
            try {
                var result = LuisRepository.GetApplicationVersionExternalApiKeys(appId, versionId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionExternalApiKeys failed", this, ex);
            }

            return null;
        }

        public virtual SubscriptionKeySet GetApplicationVersionSubscriptionKeys(Guid appId, string versionId) {
            try {
                var result = LuisRepository.GetApplicationVersionSubscriptionKeys(appId, versionId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersionSubscriptionKeys failed", this, ex);
            }

            return null;
        }

        public virtual List<ApplicationVersion> GetApplicationVersions(Guid appId, int skip = 0, int take = 100) {
            try {
                var result = LuisRepository.GetApplicationVersions(appId, skip, take);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersions failed", this, ex);
            }

            return null;
        }

        public virtual string ImportVersionToApplication(Guid appId, ApplicationDefinition definition, string versionId = "") {
            try {
                var result = LuisRepository.ImportVersionToApplication(appId, definition, versionId);

                return result;
            } catch (Exception ex) {
                Logger.Error("LuisService.GetApplicationVersions failed", this, ex);
            }

            return null;
        }

        public virtual void RenameApplicationVersion(Guid appId, string versionId, VersionRequest request) {
            try {
                LuisRepository.RenameApplicationVersion(appId, versionId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.RenameApplicationVersion failed", this, ex);
            }
        }

        public virtual void UpdateApplicationVersionExternalKey(Guid appId, string versionId, ExternalApiKeyRequest request) {
            try {
                LuisRepository.UpdateApplicationVersionExternalKey(appId, versionId, request);
            } catch (Exception ex) {
                Logger.Error("LuisService.UpdateApplicationVersionExternalKey failed", this, ex);
            }
        }
    }
}