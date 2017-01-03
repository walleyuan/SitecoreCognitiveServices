using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Controllers;
using Sitecore.SharedSource.CognitiveServices.Api;
using Sitecore.SharedSource.CognitiveServices.Controllers.Editors;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class ImageEditorController : BaseEditorController
    {
        public ImageEditorController(
            ICognitiveContext cognitiveContext,
            IWebUtilWrapper webUtil) : base(cognitiveContext, webUtil)
        {
        }

        public ActionResult Index()
        {
            ICognitiveImage cImage = GetEmptyCognitiveImage();
            return View(cImage);
        }

        public ActionResult Analyze()
        {
            ICognitiveImage cImage = GetEmptyCognitiveImage();

            MediaItem m = Sitecore.Context.ContentDatabase.GetItem(ItemId);
            if (m == null)
                return View("Index");

            cImage.Analysis = CognitiveContext.VisionApi.GetFullAnalysis(m);
            return View("Index", cImage);
        }

        protected ICognitiveImage GetEmptyCognitiveImage()
        {
            ICognitiveImage cImage = new CognitiveImage();
            cImage.Analysis = new AnalysisResult();
            cImage.Database = this.Database;
            cImage.Language = this.Language;
            cImage.ItemId = this.ItemIdValue;

            return cImage;
        }
    }
}