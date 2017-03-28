using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Controllers {

    public class CognitiveBotController : Controller
    {
        protected readonly ILuisService LuisService;

        public CognitiveBotController(ILuisService luisService)
        {
            LuisService = luisService;
        }

        public ActionResult OleChat()
        {
            return View("OleChat");
        }

        public ActionResult OleChatRequest(string query)
        {


            var result = LuisService.Query(new Guid("a9b7f39c-692a-499c-bcee-b1e57232b93a"), query);
            var intent = result.Intents.OrderByDescending(a => a.Score).FirstOrDefault().Intent.ToLower();

            if (intent == "greet")
                return Json("Hi, how can I help you?");
            if (intent == "version")
                return Json($"My version is {GetVersion()}");
            if (intent == "cursing")
                return Json("You really shouldn't talk like that");

            return Json("Sorry, can you try again? I didn't quite understand you.");
        }

        public string GetVersion()
        {
            var path = Server.MapPath("~/sitecore/shell/sitecore.version.xml");
            if (!System.IO.File.Exists(path))
                return string.Empty;

            string xmlText = System.IO.File.ReadAllText(path);
            XDocument xdoc = XDocument.Parse(xmlText);

            var version = xdoc.Descendants("version").First();
            var major = version.Descendants("major").First().Value;
            var minor = version.Descendants("minor").First().Value;
            var revision = version.Descendants("revision").First().Value;

            return $"{major}.{minor} rev {revision}";
        }
    }
}