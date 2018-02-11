using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language;

namespace SitecoreCognitiveServices.Feature.OleChat.Setup
{
    public class SetupService : ISetupService
    {
        //protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ILuisService LuisService;
        protected readonly IOleSettings OleSettings;
        protected readonly HttpContextBase Context;

        public SetupService(
            //ISitecoreDataWrapper dataWrapper,
            ILuisService luisService,
            IOleSettings oleSettings,
            HttpContextBase context
            )
        {
            //DataWrapper = dataWrapper;
            LuisService = luisService;
            OleSettings = oleSettings;
            Context = context;
        }

        public bool PingLuis()
        {
            var subKeyResponse = LuisService.GetSubscriptionKey();
            var extKeyResponse = LuisService.GetExternalApiKey();

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