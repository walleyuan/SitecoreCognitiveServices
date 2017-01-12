using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;

namespace Sitecore.SharedSource.CognitiveServices.Controllers.Modals
{
    public class CognitiveAnalysisModalController : Controller
    {
        public IWebUtilWrapper WebUtil;
        public ICognitiveSearchContext Searcher;
        public ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        public ICognitiveTextAnalysisFactory TextAnalysisFactory;
        
        public string IdParameter
        {
            get
            {
                return WebUtil.GetQueryString("id", string.Empty);
            }
        }
        public string LanguageParameter
        {
            get
            {
                return WebUtil.GetQueryString("lang", "en");
            }
        }

        public CognitiveAnalysisModalController(
            IWebUtilWrapper webUtil,
            ICognitiveSearchContext searcher,
            ICognitiveImageAnalysisFactory iaFactory,
            ICognitiveTextAnalysisFactory taFactory)
        {
            WebUtil = webUtil;
            Searcher = searcher;
            ImageAnalysisFactory = iaFactory;
            TextAnalysisFactory = taFactory;
        }

        public ActionResult ImageAnalysis()
        {
            ICognitiveSearchResult csr = Searcher.GetAnalysis(IdParameter, LanguageParameter);

            return View("ImageAnalysis", ImageAnalysisFactory.Create(csr));
        }

        public ActionResult TextAnalysis()
        {
            ICognitiveSearchResult csr = Searcher.GetAnalysis(IdParameter, LanguageParameter);
            
            return View("TextAnalysis", TextAnalysisFactory.Create(csr));
        }

        public ActionResult Reanalyze()
        {
            Item item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(IdParameter);
            if(item == null)
                return View("TextAnalysis", null);

            item.Database.Engines.HistoryEngine.RegisterItemSaved(item, new ItemChanges(item));
            item.Database.Engines.HistoryEngine.RegisterItemCreated(item);
            item.Database.Engines.HistoryEngine.RegisterItemMoved(item, item.ParentID);
            
            ICognitiveSearchResult csr = Searcher.GetAnalysis(IdParameter, LanguageParameter);

            return (item.Paths.IsMediaItem)
                ? View("ImageAnalysis", ImageAnalysisFactory.Create(csr))
                : View("TextAnalysis", TextAnalysisFactory.Create(csr));
        }
    }
}