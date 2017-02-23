using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Services.Bing;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Controllers
{
    public class CognitiveLaunchController : Controller
    {
        protected readonly IVisionService VisionService;
        protected readonly IAutoSuggestService AutoSuggestService;

        public CognitiveLaunchController(
            IVisionService visionService,
            IAutoSuggestService autoSuggestService)
        {
            VisionService = visionService;
            AutoSuggestService = autoSuggestService;
        }
        
        #region Moderator

        public ActionResult Moderator()
        {
            return View();
        }

        public ActionResult ModerateImage(string url)
        {
            AnalysisResult ar = VisionService.AnalyzeImage(url, new List<VisualFeature>() {VisualFeature.Adult});

            return Json(ar.Adult);
        }

        #endregion Moderator
        
        #region Auto Suggest

        public ActionResult Suggestions()
        {
            return View();
        }

        public ActionResult GetSuggestions(string text)
        {
            var results = AutoSuggestService.GetSuggestions(text).SuggestionGroups.FirstOrDefault()?.SearchSuggestions;
            
            return Json(results.Take(5));
        }

        #endregion Auto Suggest
    }
}