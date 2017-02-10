using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.Web.UI.Sheer;

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

            var ms = MediaSearchFactory.Create(db, lang);

            return View("RTESearch", ms);
        }

        public ActionResult RTESearchQuery(string query, string language, string db)
        {
            List<ICognitiveSearchResult> csr = Searcher.GetMediaResults(query, language, db);
            
            return Json(new
            {
                Results = csr.Select(r => new JsonResult(DataService, r)),
                ResultCount = csr.Count
            });
            
            //SheerResponse.Eval("scCancel()");
            //SheerResponse.Eval("scClose('helloworld')");

            /*{"commands":[{"command":"Eval","value":"scClose(\"<img height=\\\"550\\\" Alt=\\\"a woman holding a cell
             phone\\\" width=\\\"1600\\\" _languageInserted=\\\"true\\\" Src=\\\"-/media/04dad0fddb664070881f17264ca257e1
            .ashx?la=en\\\"/>\")"},{"command":"RegisterKey","value":"javascript:scForm.browser.getControl('OK').click
            ()","keycode":"13","group":""},{"command":"RegisterKey","value":"javascript:scForm.browser.getControl
            ('Cancel').click()","keycode":"27","group":""}]}*/
        }
        
        public class JsonResult
        {
            public string url;
            public string path;
            public string id;

            public JsonResult(ISitecoreDataService dataService, ICognitiveSearchResult result)
            {
                try
                {
                    url = MediaManager.GetMediaUrl(dataService.GetItemByUri(result.UniqueId));
                }
                catch (Exception ex)
                {
                    url = string.Empty;
                }
                try
                {
                    path = result.Path;
                }
                catch (Exception ex)
                {
                    path = string.Empty;
                }
                try
                {
                    id = ItemUri.Parse(result.UniqueId).ItemID.ToString();
                }
                catch (Exception ex)
                {
                    id = string.Empty;
                }
            }
        }
    }
}
 