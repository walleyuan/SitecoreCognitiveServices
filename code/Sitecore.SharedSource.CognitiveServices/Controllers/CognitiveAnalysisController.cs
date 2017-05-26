using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Services.Search;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class CognitiveAnalysisController : Controller
    {
        protected readonly ISearchService SearchService;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected readonly ICognitiveTextAnalysisFactory TextAnalysisFactory;
        protected readonly IReanalyzeAllFactory ReanalyzeAllFactory;
        protected readonly ISitecoreDataWrapper DataWrapper;
        
        public CognitiveAnalysisController(
            ISearchService searchService,
            ICognitiveImageAnalysisFactory iaFactory,
            ICognitiveTextAnalysisFactory taFactory,
            IReanalyzeAllFactory pFactory,
            ISitecoreDataWrapper dataWrapper)
        {
            Assert.IsNotNull(searchService, typeof(ISearchService));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(taFactory, typeof(ICognitiveTextAnalysisFactory));
            Assert.IsNotNull(pFactory, typeof(IReanalyzeAllFactory));
            Assert.IsNotNull(dataWrapper, typeof(ISitecoreDataWrapper));

            SearchService = searchService;
            ImageAnalysisFactory = iaFactory;
            TextAnalysisFactory = taFactory;
            ReanalyzeAllFactory = pFactory;
            DataWrapper = dataWrapper;
        }

        public ActionResult ImageAnalysis(string id, string language, string db)
        {
            ICognitiveSearchResult csr = SearchService.GetCognitiveSearchResult(id, language, db);

            return View("ImageAnalysis", ImageAnalysisFactory.Create(csr));
        }

        public ActionResult TextAnalysis(string id, string language, string db)
        {
            ICognitiveSearchResult csr = SearchService.GetCognitiveSearchResult(id, language, db);
            
            return View("TextAnalysis", TextAnalysisFactory.Create(csr));
        }

        public ActionResult Reanalyze(string id, string language, string db)
        {
            Item item = DataWrapper.GetItemByIdValue(id, db);
            if(item == null)
                return View("TextAnalysis", null);

            SearchService.UpdateItemInIndex(item, db);
            
            return (item.Paths.IsMediaItem)
                ? View("ImageAnalysis", SearchService.GetImageAnalysis(id, language, db))
                : View("TextAnalysis", SearchService.GetTextAnalysis(id, language, db));
        }

        public ActionResult ViewReanalyzeAll(string id, string language, string db)
        {
            var result = ReanalyzeAllFactory.Create(id, db, language, 0);

            return View("ReanalyzeAll", result);
        }

        public ActionResult ReanalyzeAll(string id, string language, string db)
        {
            Item item = DataWrapper.GetItemByIdValue(id, db);
            if (item == null)
                return ViewReanalyzeAll(id, language, db);
            
            var count = SearchService.UpdateItemInIndexRecursively(item, db);

            var result = ReanalyzeAllFactory.Create(id, db, language, count);

            return Json(result);
        }
    }
}