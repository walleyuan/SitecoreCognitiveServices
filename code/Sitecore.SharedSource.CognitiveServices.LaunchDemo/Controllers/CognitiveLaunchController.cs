using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Services.Bing;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;
using Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Controllers
{
    public class CognitiveLaunchController : Controller
    {
        protected readonly IVisionService VisionService;
        protected readonly IAutoSuggestService AutoSuggestService;
        protected readonly IImageSearchService ImageSearchService;
        protected readonly ISpellCheckService SpellCheckService;
        protected readonly IWebSearchService WebSearchService;
        protected readonly INewsSearchService NewsSearchService;
        protected readonly IVideoSearchService VideoSearchService;
        protected readonly IVideoService VideoService;
        protected readonly IEmotionService EmotionService;
        protected readonly IFaceService FaceService;

        public CognitiveLaunchController(
            IVisionService visionService,
            IAutoSuggestService autoSuggestService,
            IImageSearchService imageSearchService,
            ISpellCheckService spellCheckService,
            IWebSearchService webSearchService,
            INewsSearchService newsSearchService,
            IVideoSearchService videoSearchService,
            IVideoService videoService,
            IEmotionService emotionService,
            IFaceService faceService)
        {
            VisionService = visionService;
            AutoSuggestService = autoSuggestService;
            ImageSearchService = imageSearchService;
            SpellCheckService = spellCheckService;
            WebSearchService = webSearchService;
            NewsSearchService = newsSearchService;
            VideoSearchService = videoSearchService;
            VideoService = videoService;
            EmotionService = emotionService;
            FaceService = faceService;
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

            return Json(results.Value);
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

        #region Web Search

        public ActionResult WebSearch()
        {
            return View();
        }

        public ActionResult GetWebSearch(string text)
        {
            var results = WebSearchService.WebSearch(text);

            return Json(results.WebPages.Value);
        }

        #endregion Web Search

        #region News Search

        public ActionResult NewsSearch() {
            return View();
        }

        public ActionResult GetNewsSearch(string text) {
            var results = NewsSearchService.NewsSearch(text);

            return Json(results.Value);
        }

        public ActionResult GetNewsTrendSearch() {
            var results = NewsSearchService.TrendingSearch();

            return Json(results.Value.Take(10));
        }

        public ActionResult GetNewsCatSearch(string category)
        {
            var c = (NewsCategoryOptions)Enum.Parse(typeof(NewsCategoryOptions), category);

            var results = NewsSearchService.CategorySearch(c);

            return Json(results.Value);
        }
        #endregion News Search

        #region Video Search

        public ActionResult VideoSearch() {
            return View();
        }

        public ActionResult GetVideoSearch(string text) {
            var results = VideoSearchService.VideoSearch(text);

            return Json(results.Value);
        }

        public ActionResult GetVideoTrendSearch() {
            var results = VideoSearchService.TrendingSearch();

            return Json(results.Categories.Take(5));
        }

        public ActionResult GetVideoDetailsSearch(string videoId) {
            var results = VideoSearchService.VideoDetailsSearch(videoId, VideoDetailsModulesOptions.All);

            return Json(results.VideoResult);
        }

        #endregion Video Search

        #region Computer Vision

        public ActionResult ComputerVision()
        {
            return View(new ComputerVisionResult());
        }

        [HttpPost]
        public ActionResult ComputerVision(string url)
        {
            ComputerVisionResult cvr = new ComputerVisionResult();
            cvr.ImageUrl = url;
            cvr.Result = VisionService.AnalyzeImage(url, new List<VisualFeature> { VisualFeature.Faces, VisualFeature.Tags });

            return View("ComputerVision", cvr);
        }

        #endregion Computer Vision

        #region Emotion

        public ActionResult Emotion()
        {
            return View(new EmotionResult());
        }

        [HttpPost]
        public ActionResult Emotion(string url)
        {
            EmotionResult er = new EmotionResult();
            er.ImageUrl = url;
            er.Result = EmotionService.Recognize(url);

            return View("Emotion", er);
        }

        #endregion Emotion

        #region Face

        public ActionResult Face()
        {
            return View(new FaceResult());
        }

        [HttpPost]
        public ActionResult Face(string url)
        {
            FaceResult fr = new FaceResult();
            fr.ImageUrl = url;
            fr.Result = FaceService.Detect(url, returnFaceAttributes:new List<FaceAttributeType>()
            {
                FaceAttributeType.Age,
                FaceAttributeType.FacialHair,
                FaceAttributeType.HeadPose,
                FaceAttributeType.Gender,
                FaceAttributeType.Glasses,
                FaceAttributeType.Smile
            }, returnFaceLandmarks:true );

            return View("Face", fr);
        }

        #endregion Face
    }
}