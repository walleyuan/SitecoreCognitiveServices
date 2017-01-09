using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Search;
using System.Web.Script.Serialization;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Controllers.Modals
{
    public class CognitiveAnalysisModalController : Controller
    {
        public IWebUtilWrapper WebUtil;
        public ICognitiveSearchContext Searcher;

        public static readonly string idParam = "id";
        public static readonly string langParam = "lang";

        public CognitiveAnalysisModalController(
            IWebUtilWrapper webUtil,
            ICognitiveSearchContext searcher)
        {
            WebUtil = webUtil;
            Searcher = searcher;
        }

        public ActionResult ImageAnalysis()
        {
            string idValue = WebUtil.GetQueryString(idParam, string.Empty);
            string langCode = WebUtil.GetQueryString(langParam, "en");
            ICognitiveSearchResult csr = Searcher.GetAnalysis(idValue, langCode);
            
            var model = new JavaScriptSerializer().Deserialize<CognitiveImageAnalysis>(csr.ImageItemAnalysis);

            return View("ImageAnalysis", model);
        }

        public ActionResult TextAnalysis()
        {
            string idValue = WebUtil.GetQueryString(idParam, string.Empty);
            string langCode = WebUtil.GetQueryString(langParam, "en");
            ICognitiveSearchResult csr = Searcher.GetAnalysis(idValue, langCode);

            var model = new JavaScriptSerializer().Deserialize<CognitiveTextAnalysis>(csr.TextFieldAnalysis);

            return View("TextAnalysis", model);
        }
    }
}