using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using Sitecore.Data.Items;
using Sitecore.Security.Authentication;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Controllers
{
    public class CognitiveImageSearchController : Controller
    {
        #region Constructor

        protected readonly IImageSearchService SearchService;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly ICognitiveImageSearchFactory MediaSearchFactory;
        protected readonly ISetAltTagsAllFactory SetAltTagsAllFactory;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected readonly IAnalyzeAllFactory AnalyzeAllFactory;
        protected readonly IImageAnalysisService AnalysisService;

        public CognitiveImageSearchController(
            IImageSearchService searchService,
            ISitecoreDataWrapper dataWrapper,
            IWebUtilWrapper webUtil,
            ICognitiveImageSearchFactory msFactory,
            ISetAltTagsAllFactory satarFactory,
            ICognitiveImageAnalysisFactory iaFactory,
            IAnalyzeAllFactory pFactory,
            IImageAnalysisService analysisService)
        {
            Assert.IsNotNull(searchService, typeof(IImageSearchService));
            Assert.IsNotNull(dataWrapper, typeof(ISitecoreDataWrapper));
            Assert.IsNotNull(webUtil, typeof(IWebUtilWrapper));
            Assert.IsNotNull(msFactory, typeof(ICognitiveImageSearchFactory));
            Assert.IsNotNull(satarFactory, typeof(ISetAltTagsAllFactory));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(pFactory, typeof(IAnalyzeAllFactory));
            Assert.IsNotNull(analysisService, typeof(IImageAnalysisService));

            SearchService = searchService;
            DataWrapper = dataWrapper;
            WebUtil = webUtil;
            MediaSearchFactory = msFactory;
            SetAltTagsAllFactory = satarFactory;
            ImageAnalysisFactory = iaFactory;
            AnalyzeAllFactory = pFactory;
            AnalysisService = analysisService;
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
            string color, 
            string db,
            int page,
            int pageLength)
        {
            if (!IsSitecoreUser())
                return new EmptyResult();

            List<ICognitiveImageSearchResult> csr = SearchService.GetMediaResults(
                tagParameters, 
                rangeParameters, 
                gender, 
                glasses,
                size,
                language,
                color,
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
        public ActionResult UpdateImageDescription(string descriptionOption, string id, string database, string language)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            if (string.IsNullOrEmpty(descriptionOption))
                return View("ImageDescription");

            Item item = DataWrapper.GetItemByIdValue(id, database);
            if (item == null)
                return View("ImageDescription");

            MediaItem m = item;
            DataWrapper.SetImageDescription(m, descriptionOption);

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
        public ActionResult UpdateImageDescriptionAll(string id, string language, string db, int threshold, bool overwrite)
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

            var thresholdDouble = (double)threshold / 100;
            foreach (var m in list) {
                Caption cap = SearchService.GetTopImageCaption(m, language, thresholdDouble);
                if (cap != null)
                    DataWrapper.SetImageDescription(m, cap.Text);
            }

            var result = SetAltTagsAllFactory.Create(id, db, language, fullList.Count(), list.Count(), threshold, overwrite);

            return Json(result);
        }

        #endregion Set Alt Tags

        #region Analysis

        public ActionResult ImageAnalysis(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            ICognitiveImageSearchResult csr = SearchService.GetCognitiveSearchResult(id, language, db);

            return View("ImageAnalysis", ImageAnalysisFactory.Create(csr));
        }

        public ActionResult Analyze(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            Item item = DataWrapper.GetItemByIdValue(id, db);

            AnalysisService.AnalyzeImage(item);
            SearchService.UpdateItemInIndex(item, db);

            return View("ImageAnalysis", SearchService.GetImageAnalysis(id, language, db));
        }

        public ActionResult ViewAnalyzeAll(string id, string language, string db)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            var result = AnalyzeAllFactory.Create(id, db, language, 0);

            return View("AnalyzeAll", result);
        }

        public ActionResult AnalyzeAll(string id, string language, string database)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            Item item = DataWrapper.GetItemByIdValue(id, database);
            if (item == null)
                return ViewAnalyzeAll(id, language, database);

            AnalysisService.AnalyzeImagesRecursively(item, database);
            var count = SearchService.UpdateItemInIndexRecursively(item, database);

            var result = AnalyzeAllFactory.Create(id, database, language, count);

            return Json(result);
        }

        #endregion Analysis

        #region Shared

        public bool IsSitecoreUser()
        {
            return DataWrapper.ContextUser.IsAuthenticated 
                && DataWrapper.ContextDomain.Name.ToLower().Equals("sitecore");
        }

        public ActionResult LoginPage()
        {
            return new RedirectResult("/sitecore/login");
        }

        #endregion
    }
}
 