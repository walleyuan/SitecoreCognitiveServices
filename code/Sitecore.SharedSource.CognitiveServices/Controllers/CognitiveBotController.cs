using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Intents;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Controllers {

    public class CognitiveBotController : Controller
    {
        protected readonly IIntentProvider IntentProvider;
        protected readonly ILuisService LuisService;
        protected readonly ITextTranslator TextTranslator;

        public CognitiveBotController(
            IIntentProvider intentProvider, 
            ILuisService luisService,
            ITextTranslator textTranslator)
        {
            IntentProvider = intentProvider;
            LuisService = luisService;
            TextTranslator = textTranslator;
        }

        public ActionResult OleChat()
        {
            return View("OleChat");
        }

        public ActionResult OleChatRequest(string query)
        {
            var appId = new Guid("a9b7f39c-692a-499c-bcee-b1e57232b93a");
            var result = LuisService.Query(appId, query);

            var defaultResponse = IntentProvider.GetIntent(appId, "default")?.Respond(TextTranslator, result) ?? string.Empty;

            var intentRecommendation = result?.Intents?.OrderByDescending(a => a.Score).FirstOrDefault();
            if (intentRecommendation == null)
                return Json(defaultResponse);

            var intentName = intentRecommendation.Intent.ToLower();
            var intent = IntentProvider.GetIntent(appId, intentName);

            return (intent != null)
                ? Json(intent.Respond(TextTranslator, result))
                : Json(defaultResponse);
        }
    }
}