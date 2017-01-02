using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Controllers;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class SitecoreCognitiveServicesController : Controller
    {
        public SitecoreCognitiveServicesController()
        {
            Log.Info("hey", this);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}