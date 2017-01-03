using Sitecore.SharedSource.CognitiveServices.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.SharedSource.CognitiveServices.Controllers.Editors
{
    public class AudioEditorController : BaseEditorController
    {
        public AudioEditorController(
            ICognitiveContext cognitiveContext) : base(cognitiveContext)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}