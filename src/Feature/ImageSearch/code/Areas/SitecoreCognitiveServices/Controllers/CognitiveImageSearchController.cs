using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Jobs;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Setup;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Feature.ImageSearch.Setup;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Controllers
{
    public class CognitiveImageSearchController : Controller
    {
        #region Constructor

        protected readonly IImageSearchService SearchService;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly ICognitiveImageSearchFactory MediaSearchFactory;
        protected readonly ISetAltTagsAllFactory SetAltTagsAllFactory;
        protected readonly IAnalyzeAllFactory AnalyzeAllFactory;
        protected readonly IImageAnalysisService AnalysisService;
        protected readonly IAnalysisJobResultFactory JobResultFactory;
        protected readonly ISetupInformationFactory SetupFactory;
        protected readonly ISetupService SetupService;
        protected readonly IImageSearchSettings SearchSettings;

        public CognitiveImageSearchController(
            IImageSearchService searchService,
            ISitecoreDataWrapper dataWrapper,
            IWebUtilWrapper webUtil,
            ICognitiveImageSearchFactory msFactory,
            ISetAltTagsAllFactory satarFactory,
            IAnalyzeAllFactory pFactory,
            IImageAnalysisService analysisService,
            IAnalysisJobResultFactory jobResultFactory,
            ISetupInformationFactory setupFactory,
            ISetupService setupService,
            IImageSearchSettings searchSettings)
        {
            Assert.IsNotNull(searchService, typeof(IImageSearchService));
            Assert.IsNotNull(dataWrapper, typeof(ISitecoreDataWrapper));
            Assert.IsNotNull(webUtil, typeof(IWebUtilWrapper));
            Assert.IsNotNull(msFactory, typeof(ICognitiveImageSearchFactory));
            Assert.IsNotNull(satarFactory, typeof(ISetAltTagsAllFactory));
            Assert.IsNotNull(pFactory, typeof(IAnalyzeAllFactory));
            Assert.IsNotNull(analysisService, typeof(IImageAnalysisService));
            Assert.IsNotNull(jobResultFactory, typeof(IAnalysisJobResultFactory));
            Assert.IsNotNull(setupFactory, typeof(ISetupInformationFactory));
            Assert.IsNotNull(setupService, typeof(ISetupService));
            Assert.IsNotNull(searchSettings, typeof(IImageSearchSettings));

            SearchService = searchService;
            DataWrapper = dataWrapper;
            WebUtil = webUtil;
            MediaSearchFactory = msFactory;
            SetAltTagsAllFactory = satarFactory;
            AnalyzeAllFactory = pFactory;
            AnalysisService = analysisService;
            JobResultFactory = jobResultFactory;
            SetupFactory = setupFactory;
            SetupService = setupService;
            SearchSettings = searchSettings;
        }

        #endregion

        #region Image Search

        public ActionResult SearchForm()
        {
            if (!IsSitecoreUser())
                return LoginPage();

            var lang = WebUtil.GetQueryString("lang");
            var db = WebUtil.GetQueryString("db", "master");

            var ms = MediaSearchFactory.Create(db, lang, SearchService);

            return View("SearchForm", ms);
        }

        public ActionResult RTESearchQuery(
            Dictionary<string, string[]> tagParameters,
            Dictionary<string, string[]> rangeParameters,
            int gender,
            int glasses,
            int size,
            string language,
            List<string> colors,
            string db,
            int page,
            int pageLength)
        {
            if (!IsSitecoreUser())
                return new EmptyResult();

            List<ICognitiveImageSearchResult> csr = SearchService.GetFilteredCognitiveSearchResults(
                tagParameters,
                rangeParameters,
                gender,
                glasses,
                size,
                language,
                colors,
                db);

            var skipCount = (page - 1) * pageLength;
            var trimList = csr.Skip(skipCount).Take(pageLength);

            return Json(new
            {
                Results = trimList.Select(r => MediaSearchFactory.CreateMediaSearchJsonResult(DataWrapper, r)),
                ResultCount = csr.Count
            });
        }

        #endregion Image Search

        #region Set Alt Tags

        public ActionResult ViewImageDescription(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            Item item = DataWrapper.GetItemByIdValue(id, db);
            if (item == null)
                return View("ImageDescription");

            MediaItem m = item;

            var desc = SearchService.GetImageDescription(m, language);

            return View("ImageDescription", desc);
        }

        [HttpPost]
        public ActionResult UpdateImageDescription(string descriptionOption, string id, string database,
            string language)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            if (string.IsNullOrEmpty(descriptionOption))
                return View("ImageDescription");

            Item item = DataWrapper.GetItemByIdValue(id, database);
            if (item == null)
                return View("ImageDescription");

            MediaItem m = item;
            DataWrapper.SetImageAlt(m, descriptionOption);

            return View("ImageDescription", SearchService.GetImageDescription(m, language));
        }

        public ActionResult ViewImageDescriptionThreshold(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            var result = SetAltTagsAllFactory.Create(id, db, language, 0, 0, 50, false);

            return View("ImageDescriptionThreshold", result);
        }

        [HttpPost]
        public ActionResult UpdateImageDescriptionAll(string id, string language, string db, int threshold,
            bool overwrite)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            IEnumerable<MediaItem> fullList = DataWrapper
                .GetMediaFileDescendents(id, db)
                .ToList();

            IEnumerable<MediaItem> list = fullList
                .Where(a => !string.IsNullOrEmpty(a.Alt) && !overwrite)
                .ToList();

            if (!list.Any())
                return Json(SetAltTagsAllFactory.Create(id, db, language, 0, 0, 50, false));

            var thresholdDouble = (double) threshold / 100;
            foreach (var m in list)
            {
                Caption cap = SearchService.GetTopImageCaption(m, language, thresholdDouble);
                if (cap != null)
                    DataWrapper.SetImageAlt(m, cap.Text);
            }

            var result = SetAltTagsAllFactory.Create(id, db, language, fullList.Count(), list.Count(), threshold,
                overwrite);

            return Json(result);
        }

        #endregion Set Alt Tags

        #region Analysis

        public ActionResult ImageAnalysis(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            ICognitiveImageAnalysis cia = SearchService.GetImageAnalysis(id, language, db);

            return View("ImageAnalysis", cia);
        }

        public ActionResult Analyze(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            Item item = DataWrapper.GetItemByIdValue(id, db);

            var analysis = AnalysisService.AnalyzeImage(item);

            return View("ImageAnalysis", analysis);
        }

        public ActionResult ViewAnalyzeAll(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            var result = AnalyzeAllFactory.Create(id, db, language, "");

            return View("AnalyzeAll", result);
        }

        public ActionResult AnalyzeAll(string id, string language, string database, bool overwrite)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            Item item = DataWrapper.GetItemByIdValue(id, database);
            if (item == null)
                return ViewAnalyzeAll(id, language, database);

            string handleName = $"BatchImageAnalysis{new Random(DateTime.Now.Millisecond).Next(0, 100)}";

            var jobOptions = new JobOptions(
                handleName,
                "Cognitive Image Analysis",
                Sitecore.Context.Site.Name,
                AnalysisService,
                "AnalyzeImagesRecursively",
                new object[] {item, database, overwrite});

            JobManager.Start(jobOptions);

            var result = AnalyzeAllFactory.Create(id, database, language, handleName);

            return Json(result);
        }

        public ActionResult GetJobStatus(string handleName)
        {
            Job j = JobManager.GetJob(handleName);

            var result = JobResultFactory.Create(j?.Status.Processed ?? 0, j?.Status.Total ?? 0, j?.IsDone ?? true);

            return Json(result);
        }

        #endregion Analysis

        #region Setup

        public ActionResult Setup()
        {
            if (!IsSitecoreUser())
                return LoginPage();


            var db = Sitecore.Configuration.Factory.GetDatabase(SearchSettings.MasterDatabase);
            using (new DatabaseSwitcher(db))
            {
                ISetupInformation info = SetupFactory.Create();

                return View("Setup", info);
            }
        }

        public ActionResult SetupSubmit(string indexOption, string faceApi, string faceApiEndpoint, string computerVisionApi, string computerVisionApiEndpoint)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            ICognitiveImageAnalysis analysis = SetupService.SaveKeysAndAnalyze(faceApi, faceApiEndpoint, computerVisionApi, computerVisionApiEndpoint);
            var items = new List<string>();
            if (analysis == null || analysis.FacialAnalysis?.Length < 1)
                items.Add("Face API");
            if (analysis?.TextAnalysis?.Regions == null || analysis?.VisionAnalysis?.Description == null)
                items.Add("Computer Vision API");

            string err = SetupService.SetFieldsFolderTemplate();
            if(!string.IsNullOrEmpty(err))
                items.Add(err);

            if(!indexOption.Equals("Skip"))
                SetupService.ConfigureIndexes(indexOption);
            
            return Json(new
            {
                Failed = (analysis == null || items.Count > 0),
                Items = string.Join(",", items)
            });
        }
        
        #endregion

        #region Shared

        public bool IsSitecoreUser()
        {
            return DataWrapper.ContextUser.IsAuthenticated 
                && DataWrapper.ContextUser.Domain.Name.ToLower().Equals("sitecore");
        }

        public ActionResult LoginPage()
        {
            return new RedirectResult("/sitecore/login");
        }

        #endregion
    }
}
 