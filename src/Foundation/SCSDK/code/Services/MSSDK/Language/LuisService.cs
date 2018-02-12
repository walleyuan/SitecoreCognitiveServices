using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language;
using SitecoreCognitiveServices.Foundation.SCSDK.Policies;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language {
    public class LuisService : ILuisService
    {

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly ILuisRepository LuisRepository;
        protected readonly ILogWrapper Logger;

        public LuisService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            ILuisRepository luisRepository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            LuisRepository = luisRepository;
            Logger = logger;
        }

        public virtual LuisResult Query(Guid appId, string query)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.Query",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.Query(appId, query);
                    return result;
                },
                null);
        }

        public virtual string AddApplication(AddApplicationRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.AddApplication",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.AddApplication(request);
                    return result;
                },
                null);
        }

        public virtual void DeleteApplication(Guid appId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteApplication",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteApplication(appId);
                    return true;
                },
                false);
        }

        public virtual List<List<string>> DownloadApplicationQueryLogs(Guid appId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DownloadApplicationQueryLogs",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.DownloadApplicationQueryLogs(appId);
                    return result;
                },
                null);
        }

        public virtual List<ApplicationCulture> GetApplicationCultures()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationCultures",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationCultures();
                    return result;
                },
                null);
        }

        public virtual List<string> GetApplicationDomains()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationDomains",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationDomains();
                    return result;
                },
                null);
        }

        public virtual ApplicationInfo GetApplicationInfo(Guid appId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationInfo(appId);
                    return result;
                },
                null);
        }

        public virtual List<string> GetApplicationUsageScenarios()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationUsageScenarios",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationUsageScenarios();
                    return result;
                },
                null);
        }

        public virtual PersonalAssistantResponse GetPersonalAssistantApplications()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetPersonalAssistantApplications",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetPersonalAssistantApplications();
                    return result;
                },
                null);
        }

        public virtual List<UserApplication> GetUserApplications(int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetUserApplications",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetUserApplications(skip, take);
                    return result;
                },
                null);
        }

        public virtual string ImportApplication(ApplicationDefinition request, string appName = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.ImportApplication",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.ImportApplication(request, appName);
                    return result;
                },
                null);
        }

        public virtual PublishResponse PublishApplication(Guid appId, PublishRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.PublishApplication",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.PublishApplication(appId, request);
                    return result;
                },
                null);
        }

        public virtual void RenameApplication(Guid appId, ApplicationRenameRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.RenameApplication",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.RenameApplication(appId, request);
                    return true;
                },
                false);
        }

        public virtual AddLabelResponse AddLabel(Guid appId, string versionId, AddLabelRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.AddLabel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.AddLabel(appId, versionId, request);
                    return result;
                },
                null);
        }

        public virtual List<BatchAddLabelsResponse> BatchAddLabels(Guid appId, string versionId, List<AddLabelRequest> request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.BatchAddLabels",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.BatchAddLabels(appId, versionId, request);
                    return result;
                },
                null);
        }

        public virtual void DeleteExampleLabel(Guid appId, string versionId, int exampleId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteExampleLabel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteExampleLabel(appId, versionId, exampleId);
                    return true;
                },
                false);
        }

        public virtual List<LabeledExamples> ReviewLabeledExamples(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.ReviewLabeledExamples",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.ReviewLabeledExamples(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual int CreatePatternFeature(Guid appId, string versionId, PatternFeature feature)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CreatePatternFeature",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CreatePatternFeature(appId, versionId, feature);
                    return result;
                },
                -1);
        }

        public virtual int CreatePhraseListFeature(Guid appId, string versionId, PhraseListFeature feature)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CreatePhraseListFeature",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CreatePhraseListFeature(appId, versionId, feature);
                    return result;
                },
                -1);
        }

        public virtual void DeletePatternFeature(Guid appId, string versionId, int patternId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeletePatternFeature",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeletePatternFeature(appId, versionId, patternId);
                    return true;
                },
                false);
        }

        public virtual void DeletePhraseListFeature(Guid appId, string versionId, int phraselistId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.Query",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeletePhraseListFeature(appId, versionId, phraselistId);
                    return true;
                },
                false);
        }

        public virtual ApplicationFeaturesResponse GetApplicationVersionFeatures(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionFeatures",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionFeatures(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<PatternFeature> GetApplicationVersionPatternFeatures(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionPatternFeatures",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionPatternFeatures(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<PhraseListFeature> GetApplicationVersionPhraseListFeatures(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionPhraseListFeatures",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionPhraseListFeatures(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual PatternFeature GetPatternFeatureInfo(Guid appId, string versionId, int patternId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetPatternFeatureInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetPatternFeatureInfo(appId, versionId, patternId);
                    return result;
                },
                null);
        }

        public virtual PhraseListFeature GetPhraseListFeatureInfo(Guid appId, string versionId, int phraselistId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetPhraseListFeatureInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetPhraseListFeatureInfo(appId, versionId, phraselistId);
                    return result;
                },
                null);
        }

        public virtual void UpdatePatternFeature(Guid appId, string versionId, int patternId, PatternFeature feature)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.UpdatePatternFeature",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.UpdatePatternFeature(appId, versionId, patternId, feature);
                    return true;
                },
                false);
        }

        public virtual void UpdatePhraseListFeature(Guid appId, string versionId, int phraselistId, PhraseListFeature feature)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.UpdatePhraseListFeature",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.UpdatePhraseListFeature(appId, versionId, phraselistId, feature);
                    return true;
                },
                false);
        }

        public virtual List<EntityInfo> AddPrebuiltEntityExtractors(Guid appId, string versionId, List<string> extractorNames)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.AddPrebuiltEntityExtractors",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.AddPrebuiltEntityExtractors(appId, versionId, extractorNames);
                    return result;
                },
                null);
        }

        public virtual Guid CreateClosedListEntityModel(Guid appId, string versionId, ClosedListEntityRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CreateClosedListEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CreateClosedListEntityModel(appId, versionId, request);
                    return result;
                },
                Guid.Empty);
        }

        public virtual Guid CreateCompositeEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CreateCompositeEntityExtractor",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CreateCompositeEntityExtractor(appId, versionId, request);
                    return result;
                },
                Guid.Empty);
        }

        public virtual Guid CreateEntityExtractor(Guid appId, string versionId, NamedEntityRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CreateEntityExtractor",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CreateEntityExtractor(appId, versionId, request);
                    return result;
                },
                Guid.Empty);
        }

        public virtual Guid CreateHeirarchicalEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CreateHeirarchicalEntityExtractor",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CreateHeirarchicalEntityExtractor(appId, versionId, request);
                    return result;
                },
                Guid.Empty);
        }

        public virtual Guid CreateIntentClassifier(Guid appId, string versionId, NamedEntityRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CreateIntentClassifier",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CreateIntentClassifier(appId, versionId, request);
                    return result;
                },
                Guid.Empty);
        }

        public virtual void DeleteClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteClosedListEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteClosedListEntityModel(appId, versionId, closedListEntityId);
                    return true;
                },
                false);
        }

        public virtual void DeleteCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteCompositeEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteCompositeEntityModel(appId, versionId, compositeEntityId);
                    return true;
                },
                false);
        }

        public virtual void DeleteEntityModel(Guid appId, string versionId, Guid entityId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteEntityModel(appId, versionId, entityId);
                    return true;
                },
                false);
        }

        public virtual void DeleteHierarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteHierarchicalEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteHierarchicalEntityModel(appId, versionId, heirarchicalEntityId);
                    return true;
                },
                false);
        }

        public virtual void DeleteIntentModel(Guid appId, string versionId, Guid intentId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteIntentModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteIntentModel(appId, versionId, intentId);
                    return true;
                },
                false);
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid prebuiltId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeletePrebuiltModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeletePrebuiltModel(appId, versionId, prebuiltId);
                    return true;
                },
                false);
        }

        public virtual void DeletePrebuiltModel(Guid appId, string versionId, Guid closedListEntityId, int sublistId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeletePrebuiltModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeletePrebuiltModel(appId, versionId, closedListEntityId, sublistId);
                    return true;
                },
                false);
        }

        public virtual ClosedListEntityInfo GetApplicationVersionClosedListInfos(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionClosedListInfos",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionClosedListInfos(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual ComplexEntityInfo GetApplicationVersionCompositeEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionCompositeEntityInfos",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionCompositeEntityInfos(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<EntityInfo> GetApplicationVersionEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionEntityInfos",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionEntityInfos(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<ComplexEntityInfo> GetApplicationVersionHeirarchicalEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionHeirarchicalEntityInfos",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionHeirarchicalEntityInfos(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<EntityInfo> GetApplicationVersionIntentInfos(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionIntentInfos",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionIntentInfos(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<EntityInfo> GetApplicationVersionModelInfos(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionModelInfos",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionModelInfos(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<EntityInfo> GetApplicationVersionPrebuiltInfos(Guid appId, string versionId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionPrebuiltInfos",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionPrebuiltInfos(appId, versionId, skip, take);
                    return result;
                },
                null);
        }

        public virtual List<PrebuiltEntity> GetAvailablePrebuiltEntityExtractors(Guid appId, string versionId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetAvailablePrebuiltEntityExtractors",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetAvailablePrebuiltEntityExtractors(appId, versionId);
                    return result;
                },
                null);
        }

        public virtual ClosedListEntityInfo GetClosedListEntityInfo(Guid appId, string versionId, Guid closedListEntityId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetClosedListEntityInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetClosedListEntityInfo(appId, versionId, closedListEntityId);
                    return result;
                },
                null);
        }

        public virtual ComplexEntityInfo GetCompositeEntityInfo(Guid appId, string versionId, Guid compositeEntityId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetCompositeEntityInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetCompositeEntityInfo(appId, versionId, compositeEntityId);
                    return result;
                },
                null);
        }

        public virtual EntityInfo GetEntityInfo(Guid appId, string versionId, Guid entityId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetEntityInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetEntityInfo(appId, versionId, entityId);
                    return result;
                },
                null);
        }

        public virtual ComplexEntityInfo GetHeirarchicalEntityInfo(Guid appId, string versionId, Guid heirarchicalEntityId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetHeirarchicalEntityInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetHeirarchicalEntityInfo(appId, versionId, heirarchicalEntityId);
                    return result;
                },
                null);
        }

        public virtual EntityInfo GetIntentInfo(Guid appId, string versionId, Guid intentId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetIntentInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetIntentInfo(appId, versionId, intentId);
                    return result;
                },
                null);
        }

        public virtual EntityInfo GetPrebuiltInfo(Guid appId, string versionId, Guid prebuiltId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetPrebuiltInfo",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetPrebuiltInfo(appId, versionId, prebuiltId);
                    return result;
                },
                null);
        }

        public virtual void PatchClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.PatchClosedListEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.PatchClosedListEntityModel(appId, versionId, closedListEntityId, request);
                    return true;
                },
                false);
        }

        public virtual void RenameEntityModel(Guid appId, string versionId, Guid entityId, NamedEntityRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.RenameEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.RenameEntityModel(appId, versionId, entityId, request);
                    return true;
                },
                false);
        }

        public virtual void RenameIntentModel(Guid appId, string versionId, Guid intentId, NamedEntityRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.Query",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.RenameIntentModel(appId, versionId, intentId, request);
                    return true;
                },
                false);
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForEntities(Guid appId, string versionId, Guid entityId, int take = 10)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.SuggestEndpointQueriesForEntities",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.SuggestEndpointQueriesForEntities(appId, versionId, entityId, take);
                    return result;
                },
                null);
        }

        public virtual List<LabeledExamples> SuggestEndpointQueriesForIntents(Guid appId, string versionId, Guid intentId, int take = 10)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.SuggestEndpointQueriesForIntents",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.SuggestEndpointQueriesForIntents(appId, versionId, intentId, take);
                    return result;
                },
                null);
        }

        public virtual void UpdateClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.UpdateClosedListEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.UpdateClosedListEntityModel(appId, versionId, closedListEntityId, request);
                    return true;
                },
                false);
        }

        public virtual void UpdateCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.UpdateCompositeEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.UpdateCompositeEntityModel(appId, versionId, compositeEntityId, request);
                    return true;
                },
                false);
        }

        public virtual void UpdateHeirarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.UpdateHeirarchicalEntityModel",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.UpdateHeirarchicalEntityModel(appId, versionId, heirarchicalEntityId, request);
                    return true;
                },
                false);
        }

        public virtual List<ModelTrainingStatus> GetApplicationVersionTrainingStatus(Guid appId, string versionId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionTrainingStatus",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionTrainingStatus(appId, versionId);
                    return result;
                },
                null);
        }

        public virtual void TrainApplicationVersion(Guid appId, string versionId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.TrainApplicationVersion",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.TrainApplicationVersion(appId, versionId);
                    return true;
                },
                false);
        }

        public virtual void AddExternalApiKey(ExternalApiKeyRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.AddExternalApiKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.AddExternalApiKey(request);
                    return true;
                },
                false);
        }

        public virtual void AddSubscriptionKey(SubscriptionKeySet request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.AddSubscriptionKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.AddSubscriptionKey(request);
                    return true;
                },
                false);
        }

        public virtual void DeleteExternalApiKey(string externalApiKey)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteExternalApiKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteExternalApiKey(externalApiKey);
                    return true;
                },
                false);
        }

        public virtual void DeleteSubscriptionKey(string subscriptionKey)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteSubscriptionKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteSubscriptionKey(subscriptionKey);
                    return true;
                },
                false);
        }

        public virtual List<ExternalApiKeySet> GetExternalApiKey()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetExternalApiKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetExternalApiKey();
                    return result;
                },
                null);
        }

        public virtual List<SubscriptionKeySet> GetSubscriptionKey()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetSubscriptionKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetSubscriptionKey();
                    return result;
                },
                null);
        }

        public virtual string ResetProgrammaticKey()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.ResetProgrammaticKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.ResetProgrammaticKey();
                    return result;
                },
                null);
        }

        public virtual void AssignSubscriptionKeyToVersion(Guid appId, string versionId, string subscriptionKey)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.AssignSubscriptionKeyToVersion",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.AssignSubscriptionKeyToVersion(appId, versionId, subscriptionKey);
                    return true;
                },
                false);
        }

        public virtual string CloneVersion(Guid appId, string versionId, VersionRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.CloneVersion",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.CloneVersion(appId, versionId, request);
                    return result;
                },
                null);
        }

        public virtual void DeleteApplicationVersion(Guid appId, string versionId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteApplicationVersion",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteApplicationVersion(appId, versionId);
                    return true;
                },
                false);
        }

        public virtual void DeleteApplicationVersionExternalKey(Guid appId, string versionId, string keyType)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.DeleteApplicationVersionExternalKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.DeleteApplicationVersionExternalKey(appId, versionId, keyType);
                    return true;
                },
                false);
        }

        public virtual ApplicationDefinition ExportApplicationVersion(Guid appId, string versionId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.ExportApplicationVersion",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.ExportApplicationVersion(appId, versionId);
                    return result;
                },
                null);
        }

        public virtual ApplicationVersion GetApplicationVersion(Guid appId, string versionId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersion",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersion(appId, versionId);
                    return result;
                },
                null);
        }

        public virtual List<ExternalApiKeySet> GetApplicationVersionExternalApiKeys(Guid appId, string versionId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionExternalApiKeys",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionExternalApiKeys(appId, versionId);
                    return result;
                },
                null);
        }

        public virtual SubscriptionKeySet GetApplicationVersionSubscriptionKeys(Guid appId, string versionId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersionSubscriptionKeys",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersionSubscriptionKeys(appId, versionId);
                    return result;
                },
                null);
        }

        public virtual List<ApplicationVersion> GetApplicationVersions(Guid appId, int skip = 0, int take = 100)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.GetApplicationVersions",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.GetApplicationVersions(appId, skip, take);
                    return result;
                },
                null);
        }

        public virtual string ImportVersionToApplication(Guid appId, ApplicationDefinition definition, string versionId = "")
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.ImportVersionToApplication",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    var result = LuisRepository.ImportVersionToApplication(appId, definition, versionId);
                    return result;
                },
                null);
        }

        public virtual void RenameApplicationVersion(Guid appId, string versionId, VersionRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.RenameApplicationVersion",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.RenameApplicationVersion(appId, versionId, request);
                    return true;
                },
                false);
        }

        public virtual void UpdateApplicationVersionExternalKey(Guid appId, string versionId, ExternalApiKeyRequest request)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                "LuisService.UpdateApplicationVersionExternalKey",
                ApiKeys.LuisRetryInSeconds,
                () =>
                {
                    LuisRepository.UpdateApplicationVersionExternalKey(appId, versionId, request);
                    return true;
                },
                false);
        }
    }
}