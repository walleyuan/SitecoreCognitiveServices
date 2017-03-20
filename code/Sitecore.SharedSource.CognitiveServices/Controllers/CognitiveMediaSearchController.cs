using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class CognitiveMediaSearchController : Controller
    {
        protected readonly ICognitiveSearchContext Searcher;
        protected readonly ISitecoreDataService DataService;
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly ICognitiveMediaSearchFactory MediaSearchFactory;
        
        public CognitiveMediaSearchController(
            ICognitiveSearchContext searcher,
            ISitecoreDataService dataService,
            IWebUtilWrapper webUtil,
            ICognitiveMediaSearchFactory msFactory)
        {
            Assert.IsNotNull(searcher, typeof(ICognitiveSearchContext));
            Assert.IsNotNull(dataService, typeof(ISitecoreDataService));
            Assert.IsNotNull(webUtil, typeof(IWebUtilWrapper));
            Assert.IsNotNull(msFactory, typeof(ICognitiveMediaSearchFactory));

            Searcher = searcher;
            DataService = dataService;
            WebUtil = webUtil;
            MediaSearchFactory = msFactory;
        }
        
        public ActionResult RTESearch()
        {
            var lang = WebUtil.GetQueryString("lang");
            var db = WebUtil.GetQueryString("db", "master");

            var ms = MediaSearchFactory.Create(db, lang, Searcher);

            return View("RTESearch", ms);
        }

        public ActionResult RTESearchQuery(
            Dictionary<string, string[]> tagParameters, 
            Dictionary<string, string[]> rangeParameters, 
            int gender, 
            int glasses,
            int size,
            string language, 
            string db)
        {
            List<ICognitiveSearchResult> csr = Searcher.GetMediaResults(
                tagParameters, 
                rangeParameters, 
                gender, 
                glasses,
                size,
                language, 
                db);

            return Json(new
            {
                Results = csr.Select(r => MediaSearchFactory.CreateMediaSearchJsonResult(DataService, r)),
                ResultCount = csr.Count
            });
        }
    }
}
 