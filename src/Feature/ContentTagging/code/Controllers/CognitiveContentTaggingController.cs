using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Managers;
using SitecoreCognitiveServices.Feature.ContentTagging.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.ContentTagging.Controllers {

    public class CognitiveContentTaggingController : Controller
    {
        protected readonly IWebUtilWrapper WebUtil;

        protected readonly CreateClassifierModel Parameters;


        public CognitiveContentTaggingController(
            IWebUtilWrapper webUtil)
        {
            WebUtil = webUtil;
            
            Parameters = new CreateClassifierModel()
            {
                Id = WebUtil.GetQueryString("id"),
                Language = WebUtil.GetQueryString("language"),
                Database = WebUtil.GetQueryString("db")
            };

            ThemeManager.GetImage("Office/32x32/man_8.png", 32, 32);
        }

        public ActionResult CreateClassifier()
        {
            return View("CreateClassifier", Parameters);
        }

        public ActionResult Post()
        {
            return null;
        }
    }
}