using System.Web.Mvc;
using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
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
        public ISitecoreContextDatabase ContextDatabase;
        
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
            ICognitiveTextAnalysisFactory taFactory,
            ISitecoreContextDatabase contextDatabase)
        {
            Assert.IsNotNull(webUtil, typeof(IWebUtilWrapper));
            Assert.IsNotNull(searcher, typeof(ICognitiveSearchContext));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(taFactory, typeof(ICognitiveTextAnalysisFactory));
            Assert.IsNotNull(contextDatabase, typeof(ISitecoreContextDatabase));

            WebUtil = webUtil;
            Searcher = searcher;
            ImageAnalysisFactory = iaFactory;
            TextAnalysisFactory = taFactory;
            ContextDatabase = contextDatabase;
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
            Item item = ContextDatabase.GetItemById(IdParameter);
            if(item == null)
                return View("TextAnalysis", null);
            
            Searcher.UpdateItemInIndex(item);
            
            ICognitiveSearchResult csr = Searcher.GetAnalysis(IdParameter, LanguageParameter);

            return (item.Paths.IsMediaItem)
                ? View("ImageAnalysis", ImageAnalysisFactory.Create(csr))
                : View("TextAnalysis", TextAnalysisFactory.Create(csr));
        }
    }
}