using System.Web.Mvc;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class CognitiveUtilityController : Controller
    {
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly ICognitiveSearchContext Searcher;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected readonly IImageDescriptionFactory ImageDescriptionFactory;
        protected readonly ISitecoreDataService DataService;
        protected readonly IVisionService VisionService;
        
        public string IdParameter => WebUtil.GetQueryString("id", string.Empty);
        public string LanguageParameter => WebUtil.GetQueryString("lang", "en");
        public string DbParameter => WebUtil.GetQueryString("db", "master");
        
        public CognitiveUtilityController(
            IWebUtilWrapper webUtil,
            ICognitiveSearchContext searcher,
            ICognitiveImageAnalysisFactory iaFactory,
            IImageDescriptionFactory dFactory,
            ISitecoreDataService dataService,
            IVisionService visionService)
        {
            Assert.IsNotNull(webUtil, typeof(IWebUtilWrapper));
            Assert.IsNotNull(searcher, typeof(ICognitiveSearchContext));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(dFactory, typeof(IImageDescriptionFactory));
            Assert.IsNotNull(dataService, typeof(ISitecoreDataService));
            Assert.IsNotNull(visionService, typeof(IVisionService));

            WebUtil = webUtil;
            Searcher = searcher;
            ImageAnalysisFactory = iaFactory;
            ImageDescriptionFactory = dFactory;
            DataService = dataService;
            VisionService = visionService;
        }
        
        public ActionResult ViewImageDescription()
        {
            Item item = DataService.GetItemByIdValue(IdParameter, DbParameter);
            if (item == null)
                return View("ImageDescription");

            MediaItem m = item;
            
            return View("ImageDescription", BuildImageDescription(m, LanguageParameter));
        }

        public ActionResult UpdateImageDescription(string descriptionOption, string itemId, string database, string language)
        {
            if (string.IsNullOrEmpty(descriptionOption))
                return View("ImageDescription");

            Item item = DataService.GetItemByIdValue(itemId, database);
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
    }
}