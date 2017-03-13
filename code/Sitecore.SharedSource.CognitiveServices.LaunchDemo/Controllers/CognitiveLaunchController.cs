using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Services.Bing;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;
using Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Language;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;
using Sitecore.SharedSource.CognitiveServices.Services.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Services.Language;
using Microsoft.ProjectOxford.Video.Contract;

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
        protected readonly ILinguisticService LinguisticService;
        protected readonly ISentimentService SentimentService;
        protected readonly IEntityLinkingService EntityLinkingService;
        protected readonly ILanguageService LanguageService;
        protected readonly IContentModeratorService ContentModeratorService;

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
            IFaceService faceService,
            ILinguisticService linguisticService,
            ISentimentService sentimentService,
            IEntityLinkingService entityLinkingService,
            ILanguageService languageService,
            IContentModeratorService contentModeratorService)
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
            LinguisticService = linguisticService;
            SentimentService = sentimentService;
            EntityLinkingService = entityLinkingService;
            LanguageService = languageService;
            ContentModeratorService = contentModeratorService;
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

        public ActionResult ContentModerator()
        {
            return View(new EvaluateResponse());
        }
        
        [HttpPost]
        public ActionResult ContentModerator(string url)
        {
            var result = ContentModeratorService.Evaluate(url);

            return View("ContentModerator", result);
        }


        #endregion Moderator
        #region Video

        public ActionResult Video()
        {
            return View(new VideoResult());
        }

        [HttpPost]
        public ActionResult Video(string url)
        {
            var vr = new VideoResult();
            vr.Operation = VideoService.CreateOperation(url, new FaceDetectionOperationSettings());
            
            return View("Video", vr);
        }

        public ActionResult VideoOperation()
        {
            return Video();
        }

        [HttpPost]
        public ActionResult VideoOperation(string operationUrl)
        {
            var vr = new VideoResult();
            vr.Operation = new Operation(operationUrl);
            vr.OperationResult = VideoService.GetOperationResult(new Operation(operationUrl));
            
            return View("Video", vr);
        }

        #endregion Video

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

        #region Linguistic

        public ActionResult Linguistic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Linguistic(string text)
        {
            TextAnalysisRequest tar = new TextAnalysisRequest()
            {
                Language = "en",
                Text = text
            };
            
            var result = LinguisticService.GetConstituencyTreeTextAnalysis(tar);
            var value = new LinguisticAnalysisResult()
            {
                FieldName = "Sample Text",
                FieldValue = text,
                POSTagsAnalysis = null,
                ConstituencyTreeAnalysis = result,
                TokensAnalysis = null
            };

            return View("Linguistic", value);
        }

        #endregion Linguistic

        #region Key Phrase

        public ActionResult KeyPhrase()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KeyPhrase(string text)
        {
            var sr = new SentimentRequest();
            
            sr.Documents.Add(new Document()
            {
                Text = text,
                Id = "Sample Text"
            });
            
            var result = SentimentService.GetKeyPhrases(sr);
            
            List<KeyPhraseAnalysisResult> fieldResults = result
                .Documents
                .Select(d => new KeyPhraseAnalysisResult()
                {
                    FieldName = d.Id,
                    FieldValue = text,
                    KeyPhraseAnalysis = d
                })
                .ToList();
            
            return View("KeyPhrase", fieldResults);
        }

        #endregion Key Phrase

        #region Link Analysis

        public ActionResult Link()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Link(string text)
        {
            var result = EntityLinkingService.Link(text);

            List<LinkAnalysisResult> fieldResults = new List<LinkAnalysisResult>()
            {
                new LinkAnalysisResult()
                {
                    EntityAnalysis = result,
                    FieldName = "Sample Text",
                    FieldValue = text
                }
            };
            
            return View("Link", fieldResults);
        }

        #endregion Link Analysis

        #region Sentiment Analysis

        public ActionResult Sentiment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sentiment(string text)
        {
            var sr = new SentimentRequest();
            sr.Documents.Add(new Document()
            {
                Text = text,
                Id = "Sample Text"
            });

            var result = SentimentService.GetSentiment(sr);
            
            return View("Sentiment", result);
        }

        #endregion Sentiment Analysis

        #region Language Analysis

        public ActionResult Language()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Language(string text)
        {
            LanguageRequest lr = new LanguageRequest();

            lr.Documents.Add(new Document()
            {
                Text = text,
                Id = "Sample Text"
            });

            var result = LanguageService.GetLanguages(lr);
            return View("Language", result);
        }

        #endregion Language Analysis
    }
}