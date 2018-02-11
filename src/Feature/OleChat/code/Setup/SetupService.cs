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

namespace SitecoreCognitiveServices.Feature.OleChat.Setup
{
    public class SetupService : ISetupService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys MSCSApiKeys;
        protected readonly ILuisService LuisService;
        protected readonly IOleSettings OleSettings;
        protected readonly HttpContextBase Context;

        public SetupService(
            IMicrosoftCognitiveServicesApiKeys mscsApiKeys,
            ILuisService luisService,
            IOleSettings oleSettings,
            HttpContextBase context
            )
        {
            MSCSApiKeys = mscsApiKeys;
            LuisService = luisService;
            OleSettings = oleSettings;
            Context = context;
        }

        public bool SaveKeysAndPingLuis(string luisApi, string luisApiEndpoint, string textAnalyticsApi,
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
                
                var subKeyResponse = LuisService.GetSubscriptionKey();
                var extKeyResponse = LuisService.GetExternalApiKey();
            }

            return true;
        }

        public bool RestoreOle(bool overwrite)
        {
            //if exists skip
            var infoResponse = LuisService.GetApplicationInfo(OleSettings.OleApplicationId);
            if (infoResponse == null)
                return true;

            var jsonFile = Context.Server.MapPath("~/Areas/SitecoreCognitiveServices/Assets/json/SitecoreCognitiveServices.Feature.OleChat.json");
            if (File.Exists(jsonFile))
            {
                var jsonText = File.ReadAllText(jsonFile);
                var appDefinition = JsonConvert.DeserializeObject<ApplicationDefinition>(jsonText);
                //var importResponse = LuisService.ImportApplication(appDefinition);
                //LuisService.TrainApplicationVersion(OleSettings.OleApplicationId, appDefinition.VersionId);
                PublishRequest pr = new PublishRequest();
                pr.VersionId = appDefinition.VersionId;
                pr.IsStaging = "false";
                //LuisService.PublishApplication(OleSettings.OleApplicationId, pr);
            }

            return true;
        }

        public bool QueryOle()
        {
            var response = LuisService.Query(OleSettings.OleApplicationId, "Hello");
            if (response == null)
                return false;

            return true;
        }
    }
}