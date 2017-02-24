using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Services.Bing;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Controllers
{
    public class CognitiveLaunchController : Controller
    {
        protected readonly IVisionService VisionService;
        protected readonly IAutoSuggestService AutoSuggestService;
        protected readonly IImageSearchService ImageSearchService;
        protected readonly ISpellCheckService SpellCheckService;

        public CognitiveLaunchController(
            IVisionService visionService,
            IAutoSuggestService autoSuggestService,
            IImageSearchService imageSearchService,
            ISpellCheckService spellCheckService)
        {
            VisionService = visionService;
            AutoSuggestService = autoSuggestService;
            ImageSearchService = imageSearchService;
            SpellCheckService = spellCheckService;
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

        #region Image Search

        public ActionResult ImageSearch()
        {
            return View();
        }

        public ActionResult GetImages(string query)
        {
            var results = ImageSearchService.GetImages(query);

            return Json(results.value);
        }

        public ActionResult GetTrendingImages(string query)
        {
            var results = ImageSearchService.GetTrendingImages();

            return Json(results.Categories);
        }

        public ActionResult GetImageInsights(string url)
        {
            var modules = new List<ModulesRequestedOptions> {ModulesRequestedOptions.All};
            var results = ImageSearchService.GetImageInsights(imgUrl:url, modulesRequested:modules);

            return Json(results.VisuallySimilarImages);
        }

        #endregion Image Search

        #region Spell Check

        public ActionResult SpellCheck()
        {
            return View();
        }

        public ActionResult CheckSpelling(string text)
        {
            var results = SpellCheckService.SpellCheck(text);

            return Json(results.FlaggedTokens);
        }

        #endregion Spell Check
    }
}