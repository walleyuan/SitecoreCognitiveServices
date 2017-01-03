using Sitecore.SharedSource.CognitiveServices.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Controllers.Editors
{
    public class AudioEditorController : BaseEditorController
    {
        public AudioEditorController(
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