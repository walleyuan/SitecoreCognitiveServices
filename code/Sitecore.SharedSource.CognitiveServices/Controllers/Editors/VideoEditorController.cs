using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.SharedSource.CognitiveServices.Api;
using Sitecore.SharedSource.CognitiveServices.Controllers.Editors;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class VideoEditorController : BaseEditorController
    {
        public VideoEditorController(
            ICognitiveContext cognitiveContext,
            IWebUtilWrapper webUtil) : base(cognitiveContext, webUtil)
        {
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}