using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Managers;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Ole;
using Sitecore.SharedSource.CognitiveServices.Ole;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Controllers {

    public class CognitiveBotController : Controller
    {
        protected readonly IIntentProvider IntentProvider;
        protected readonly ILuisService LuisService;
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly IApplicationSettings ApplicationSettings;

        protected readonly ItemContextParameters Parameters;

        public CognitiveBotController(
            IIntentProvider intentProvider, 
            ILuisService luisService,
            IWebUtilWrapper webUtil,
            IApplicationSettings applicationSettings)
        {
            IntentProvider = intentProvider;
            LuisService = luisService;
            WebUtil = webUtil;
            ApplicationSettings = applicationSettings;

            Parameters = new ItemContextParameters()
            {
                Id = WebUtil.GetQueryString("id"),
                Language = WebUtil.GetQueryString("language"),
                Database = WebUtil.GetQueryString("db")
            };

            ThemeManager.GetImage("Office/32x32/man_8.png", 32, 32);
        }

        public ActionResult OleChat()
        {
            return View("OleChat", Parameters);
        }

        public ActionResult OleChatRequest(string query, string language, string database, string id)
        {
            ItemContextParameters parameters = new ItemContextParameters() {
                Id = id,
                Language = language,
                Database = database
            };

            var appId = ApplicationSettings.OleApplicationId;
            var result = LuisService.Query(appId, query);
            
            var defaultResponse = IntentProvider.GetIntent(appId, "default")?.Respond(result, null) ?? string.Empty;
            
            var intent = IntentProvider.GetIntent(appId, result.TopScoringIntent.Intent);
            
            return (intent != null)
                ? Json(intent.Respond(result, parameters))
                : Json(defaultResponse);
        }
    }
}