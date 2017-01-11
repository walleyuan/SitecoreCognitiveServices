using System.Web.Mvc;
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

            var model = ImageAnalysisFactory.Create(csr.ImageItemAnalysis);

            return View("ImageAnalysis", model);
        }

        public ActionResult TextAnalysis()
        {
            ICognitiveSearchResult csr = Searcher.GetAnalysis(IdParameter, LanguageParameter);

            var model = TextAnalysisFactory.Create(csr.TextFieldAnalysis);

            return View("TextAnalysis", model);
        }
    }
}