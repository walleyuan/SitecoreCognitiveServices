using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.SharedSource.CognitiveServices.Api;
using Sitecore.SharedSource.CognitiveServices.Controllers.Editors;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class VideoEditorController : BaseEditorController
    {
        public VideoEditorController(
            ICognitiveContext cognitiveContext) : base(cognitiveContext)
        {
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}