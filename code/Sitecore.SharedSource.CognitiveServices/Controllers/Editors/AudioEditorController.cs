using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Services;

namespace Sitecore.SharedSource.CognitiveServices.Controllers.Editors
{
    public class AudioEditorController : BaseEditorController
    {
        public AudioEditorController(
            ICognitiveServiceContext cognitiveServiceContext,
            IWebUtilWrapper webUtil) : base(cognitiveServiceContext, webUtil)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}