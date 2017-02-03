using System.Web.Mvc;
using System.Linq;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class CognitiveUtilityController : Controller
    {
        protected readonly ICognitiveSearchContext Searcher;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected readonly IImageDescriptionFactory ImageDescriptionFactory;
        protected readonly ISetAltTagsAllFactory SetAltTagsAllFactory;
        protected readonly ISitecoreDataService DataService;
        protected readonly IVisionService VisionService;
        
        public CognitiveUtilityController(
            ICognitiveSearchContext searcher,
            ICognitiveImageAnalysisFactory iaFactory,
            IImageDescriptionFactory dFactory,
            ISetAltTagsAllFactory satarFactory,
            ISitecoreDataService dataService,
            IVisionService visionService)
        {
            Assert.IsNotNull(searcher, typeof(ICognitiveSearchContext));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(dFactory, typeof(IImageDescriptionFactory));
            Assert.IsNotNull(satarFactory, typeof(ISetAltTagsAllFactory));
            Assert.IsNotNull(dataService, typeof(ISitecoreDataService));
            Assert.IsNotNull(visionService, typeof(IVisionService));

            Searcher = searcher;
            ImageAnalysisFactory = iaFactory;
            ImageDescriptionFactory = dFactory;
            SetAltTagsAllFactory = satarFactory;
            DataService = dataService;
            VisionService = visionService;
        }

        #region Set Alt Tags

        public ActionResult ViewImageDescription(string id, string language, string db)
        {
            Item item = DataService.GetItemByIdValue(id, db);
            if (item == null)
                return View("ImageDescription");

            MediaItem m = item;
            
            return View("ImageDescription", BuildImageDescription(m, language));
        }
        
        [HttpPost]
        public ActionResult UpdateImageDescription(string descriptionOption, string id, string database, string language)
        {
            if (string.IsNullOrEmpty(descriptionOption))
                return View("ImageDescription");

            Item item = DataService.GetItemByIdValue(id, database);
            if (item == null)
                return View("ImageDescription");

            MediaItem m = item;
            VisionService.SetImageDescription(m, descriptionOption);

            return View("ImageDescription", BuildImageDescription(m, language));
        }

        private IImageDescription BuildImageDescription(MediaItem m, string language)
        {
            ICognitiveSearchResult csr = Searcher
                .GetAnalysis(m.ID.ToString(), language, m.Database.Name);

            Description d = ImageAnalysisFactory
                .Create(csr)?
                .VisionAnalysis?
                .Description 
                ?? new Description();

            return ImageDescriptionFactory
                .Create(d, m.Alt, m.ID.ToString(), m.Database.Name, language);
        }

        #endregion Set Alt Tags

        #region Set Alt Tags All Descendants

        public ActionResult ViewImageDescriptionThreshold(string id, string language, string db)
        {
            var result = SetAltTagsAllFactory.Create(id, db, language, 0, 0, 50, false);
            
            return View("ImageDescriptionThreshold", result);
        }

        [HttpPost]
        public ActionResult UpdateImageDescriptionAll(string id, string language, string db, int threshold, bool overwrite)
        {
            var thresholdDecimal = (double)threshold/100;

            Item item = DataService.GetItemByIdValue(id, db);
            if (item == null)
                return Json(SetAltTagsAllFactory.Create(id, db, language, 0, 0, 50, false));

            var list = item.Axes.GetDescendants()
                .Where(a => !a.TemplateID.Guid.Equals(Sitecore.TemplateIDs.MediaFolder.Guid))
                .ToList();
            
            int modCount = 0;
            foreach (var m in list)
            {
                MediaItem mediaItem = m;
                if (!string.IsNullOrEmpty(mediaItem.Alt) && !overwrite)
                    continue;

                ICognitiveSearchResult csr = Searcher.GetAnalysis(m.ID.ToString(), language, m.Database.Name);
                Caption cap = ImageAnalysisFactory
                    .Create(csr)?
                    .VisionAnalysis?
                    .Description?
                    .Captions.OrderByDescending(a => a.Confidence)
                    .FirstOrDefault(c => c.Confidence >= thresholdDecimal);

                if (cap == null)
                    continue;
                
                VisionService.SetImageDescription(mediaItem, cap.Text);
                modCount++;
            }

            var result = SetAltTagsAllFactory.Create(id, db, language, list.Count, modCount, threshold, overwrite);

            return Json(result);
        }

        #endregion Set Alt Tags All Descendants
    }
}