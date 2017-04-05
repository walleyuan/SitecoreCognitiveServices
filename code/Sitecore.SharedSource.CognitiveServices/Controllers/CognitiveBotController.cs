using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Managers;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Ole;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Controllers {

    public class CognitiveBotController : Controller
    {
        protected readonly IIntentProvider IntentProvider;
        protected readonly ILuisService LuisService;
        protected readonly ITextTranslator TextTranslator;
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly IApplicationSettings ApplicationSettings;

        public CognitiveBotController(
            IIntentProvider intentProvider, 
            ILuisService luisService,
            ITextTranslator textTranslator,
            IWebUtilWrapper webUtil,
            IApplicationSettings applicationSettings)
        {
            IntentProvider = intentProvider;
            LuisService = luisService;
            TextTranslator = textTranslator;
            WebUtil = webUtil;
            ApplicationSettings = applicationSettings;

            //warm up ole icon
            ThemeManager.GetImage("Office/32x32/man_8.png", 32, 32);
        }

        public ActionResult OleChat()
        {
            return View("OleChat");
        }

        public ActionResult OleChatRequest(string query)
        {
            var appId = ApplicationSettings.OleApplicationId;
            var result = LuisService.Query(appId, query);
            
            var defaultResponse = IntentProvider.GetIntent(appId, "default")?.Respond(TextTranslator, result, null) ?? string.Empty;
            
            var intent = IntentProvider.GetIntent(appId, result.TopScoringIntent.Intent);

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"id", WebUtil.GetQueryString("id")},
                {"language", WebUtil.GetQueryString("language")},
                {"db", WebUtil.GetQueryString("db")}
            };

            return (intent != null)
                ? Json(intent.Respond(TextTranslator, result, parameters))
                : Json(defaultResponse);
        }
    }
}