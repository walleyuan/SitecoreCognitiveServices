using System.Web.Mvc;
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
        protected readonly ISitecoreDataService DataService;
        protected readonly IVisionService VisionService;
        
        public CognitiveUtilityController(
            ICognitiveSearchContext searcher,
            ICognitiveImageAnalysisFactory iaFactory,
            IImageDescriptionFactory dFactory,
            ISitecoreDataService dataService,
            IVisionService visionService)
        {
            Assert.IsNotNull(searcher, typeof(ICognitiveSearchContext));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(dFactory, typeof(IImageDescriptionFactory));
            Assert.IsNotNull(dataService, typeof(ISitecoreDataService));
            Assert.IsNotNull(visionService, typeof(IVisionService));

            Searcher = searcher;
            ImageAnalysisFactory = iaFactory;
            ImageDescriptionFactory = dFactory;
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
            Item item = DataService.GetItemByIdValue(id, db);
            if (item == null)
                return View("ImageDescriptionThreshold");

            MediaItem m = item;

            return View("ImageDescriptionThreshold");
        }

        [HttpPost]
        public ActionResult UpdateImageDescriptionAll(string id, string database, string language)
        {
            Item item = DataService.GetItemByIdValue(id, database);
            if (item == null)
                return View("ImageDescriptionThreshold");
            
            return View("ImageDescriptionThreshold");
        }

        #endregion Set Alt Tags All Descendants
    }
}