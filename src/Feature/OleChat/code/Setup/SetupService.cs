using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Setup
{
    public class SetupService : ISetupService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys MSCSApiKeys;
        protected readonly ILuisService LuisService;
        protected readonly IOleSettings OleSettings;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IContentSearchWrapper ContentSearch;
        protected readonly HttpContextBase Context;

        public SetupService(
            IMicrosoftCognitiveServicesApiKeys mscsApiKeys,
            ILuisService luisService,
            IOleSettings oleSettings,
            ISitecoreDataWrapper dataWrapper,
            IContentSearchWrapper contentSearch,
            HttpContextBase context
            )
        {
            MSCSApiKeys = mscsApiKeys;
            LuisService = luisService;
            OleSettings = oleSettings;
            Context = context;
            DataWrapper = dataWrapper;
            ContentSearch = contentSearch;
        }

        public void SaveKeys(string luisApi, string luisApiEndpoint, string textAnalyticsApi,
            string textAnalyticsApiEndpoint)
        {
            var db = Factory.GetDatabase(OleSettings.MasterDatabase);
            using (new DatabaseSwitcher(db))
            {
                //save items to fields
                if (MSCSApiKeys.Luis != luisApi)
                    MSCSApiKeys.Luis = luisApi;
                if (MSCSApiKeys.LuisEndpoint != luisApiEndpoint)
                    MSCSApiKeys.LuisEndpoint = luisApiEndpoint;
                if (MSCSApiKeys.TextAnalytics != textAnalyticsApi)
                    MSCSApiKeys.TextAnalytics = textAnalyticsApi;
                if (MSCSApiKeys.TextAnalyticsEndpoint != textAnalyticsApiEndpoint)
                    MSCSApiKeys.TextAnalyticsEndpoint = textAnalyticsApiEndpoint;
            }
        }

        public bool RestoreOle(bool overwrite)
        {
            var db = Factory.GetDatabase(OleSettings.MasterDatabase);
            using (new DatabaseSwitcher(db))
            {
                var jsonFile = Context.Server.MapPath("~/Areas/SitecoreCognitiveServices/Assets/json/SitecoreCognitiveServices.Feature.OleChat.json");
                if (!File.Exists(jsonFile))
                    return false;
                
                var jsonText = File.ReadAllText(jsonFile);
                var appDefinition = JsonConvert.DeserializeObject<ApplicationDefinition>(jsonText);

                var infoResponse = LuisService.GetApplicationInfo(OleSettings.OleApplicationId);
                bool shouldOverwrite = infoResponse != null && overwrite;
                bool isNoApp = infoResponse == null;
                if (shouldOverwrite)
                    LuisService.DeleteApplication(new Guid(infoResponse.Id));

                Guid appId;
                if (shouldOverwrite || isNoApp)
                {
                    var importResponse = LuisService.ImportApplication(appDefinition, appDefinition.Name);
                    if (!Guid.TryParse(importResponse, out appId))
                        return false;

                    OleSettings.OleApplicationId = Guid.Parse(importResponse);
                }
                else
                {
                    appId = OleSettings.OleApplicationId;
                }
                    
                LuisService.TrainApplicationVersion(appId, appDefinition.VersionId);
                var hasResponse = false;
                do
                {
                    System.Threading.Thread.Sleep(1000);
                        
                    var trainResponse = LuisService.GetApplicationVersionTrainingStatus(appId, appDefinition.VersionId);
                    if (trainResponse != null && trainResponse.Count > 0)
                        hasResponse = true;
                }
                while (!hasResponse);

                PublishRequest pr = new PublishRequest()
                {
                    VersionId = appDefinition.VersionId,
                    IsStaging = false,
                    EndpointRegion = "westus"
                };
                var publishResponse = LuisService.PublishApplication(appId, pr);
            }

            return true;
        }

        public bool QueryOle()
        {
            var db = Factory.GetDatabase(OleSettings.MasterDatabase);
            using (new DatabaseSwitcher(db))
            {
                var response = LuisService.Query(OleSettings.OleApplicationId, "Hello");
                if (response == null)
                    return false;
            }

            return true;
        }

        public void PublishOleContent()
        { 
            //publish the installed content
            var imageSearchFolder = DataWrapper.ContentDatabase.GetItem(OleSettings.OleChatSettingsId);
            ContentSearch.UpdateItemInIndex(imageSearchFolder, ContentSearch.GetSitecoreIndexName(OleSettings.MasterDatabase));
        }
    }
}