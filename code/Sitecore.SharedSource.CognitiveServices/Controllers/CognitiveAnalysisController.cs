using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class CognitiveAnalysisController : Controller
    {
        protected readonly ICognitiveSearchContext Searcher;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected readonly ICognitiveTextAnalysisFactory TextAnalysisFactory;
        protected readonly IReanalyzeAllFactory ReanalyzeAllFactory;
        protected readonly ISitecoreDataService DataService;
        
        public CognitiveAnalysisController(
            ICognitiveSearchContext searcher,
            ICognitiveImageAnalysisFactory iaFactory,
            ICognitiveTextAnalysisFactory taFactory,
            IReanalyzeAllFactory pFactory,
            ISitecoreDataService dataService)
        {
            Assert.IsNotNull(searcher, typeof(ICognitiveSearchContext));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(taFactory, typeof(ICognitiveTextAnalysisFactory));
            Assert.IsNotNull(pFactory, typeof(IReanalyzeAllFactory));
            Assert.IsNotNull(dataService, typeof(ISitecoreDataService));

            Searcher = searcher;
            ImageAnalysisFactory = iaFactory;
            TextAnalysisFactory = taFactory;
            ReanalyzeAllFactory = pFactory;
            DataService = dataService;
        }

        public ActionResult ImageAnalysis(string id, string language, string db)
        {
            ICognitiveSearchResult csr = Searcher.GetAnalysis(id, language, db);

            return View("ImageAnalysis", ImageAnalysisFactory.Create(csr));
        }

        public ActionResult TextAnalysis(string id, string language, string db)
        {
            ICognitiveSearchResult csr = Searcher.GetAnalysis(id, language, db);
            
            return View("TextAnalysis", TextAnalysisFactory.Create(csr));
        }

        public ActionResult Reanalyze(string id, string language, string db)
        {
            Item item = DataService.GetItemByIdValue(id, db);
            if(item == null)
                return View("TextAnalysis", null);

            Searcher.UpdateItemInIndex(item, db);
            
            ICognitiveSearchResult csr = Searcher.GetAnalysis(id, language, db);

            return (item.Paths.IsMediaItem)
                ? View("ImageAnalysis", ImageAnalysisFactory.Create(csr))
                : View("TextAnalysis", TextAnalysisFactory.Create(csr));
        }

        public ActionResult ViewReanalyzeAll(string id, string language, string db)
        {
            var result = ReanalyzeAllFactory.Create();

            return View("ReanalyzeAll", result);
        }

        public ActionResult ReanalyzeAll(string id, string language, string db)
        {
            Item item = DataService.GetItemByIdValue(id, db);
            if (item == null)
                return View("ReanalyzeAll", ReanalyzeAllFactory.Create());

            var list = item.Axes.GetDescendants()
                .Where(a => !a.TemplateID.Guid.Equals(Sitecore.TemplateIDs.MediaFolder.Guid))
                .ToList();
            
            list.ForEach(b => Searcher.UpdateItemInIndex(b, db));

            var result = ReanalyzeAllFactory.Create(list.Count, db, language, id);

            return Json(result);
        }
    }
}