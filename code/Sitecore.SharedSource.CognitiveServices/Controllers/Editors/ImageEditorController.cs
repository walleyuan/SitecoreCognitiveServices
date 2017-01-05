using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Controllers;
using Sitecore.SharedSource.CognitiveServices.Controllers.Editors;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Services;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class ImageEditorController : BaseEditorController
    {
        public ICognitiveImageFactory CognitiveImageFactory;

        public ImageEditorController(
            ICognitiveServiceContext cognitiveServiceContext,
            IWebUtilWrapper webUtil,
            ICognitiveImageFactory cognitiveImageFactory) : base(cognitiveServiceContext, webUtil)
        {
            CognitiveImageFactory = cognitiveImageFactory;
        }

        public ActionResult Index()
        {
            ICognitiveImage cImage = GetCognitiveImage();
            return View(cImage);
        }

        public ActionResult Analyze(string database, string itemId, string language) 
        {
            ICognitiveImage cImage = CognitiveImageFactory.Create();

            Sitecore.Data.ID mID = ID.Null;
            if (!ID.TryParse(itemId, out mID))
                return View("Index", cImage);

            Database db = Sitecore.Configuration.Factory.GetDatabase(database);
            if (db == null)
                return View("Index", cImage);

            MediaItem m = db.GetItem(mID);
            if (m == null)
                return View("Index", cImage);

            //AnalysisResult r = CognitiveServiceContext.VisionService.GetFullAnalysis(m);
            //cImage.DominantColorForeground = r.Color.DominantColorForeground;
            return View("Index", cImage);
        }

        public ICognitiveImage GetCognitiveImage()
        {
            ICognitiveImage cImage = CognitiveImageFactory.Create();
            cImage.Language = this.Language;
            cImage.Database = this.Database;
            cImage.ItemId = this.ItemIdValue;

            return cImage;
        }
    }
}