using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Services.Search;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class CognitiveUtilityController : Controller
    {
        protected readonly ISearchService SearchService;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected readonly IImageDescriptionFactory ImageDescriptionFactory;
        protected readonly ISetAltTagsAllFactory SetAltTagsAllFactory;
        protected readonly ISitecoreDataService DataService;
        
        public CognitiveUtilityController(
            ISearchService searchService,
            ICognitiveImageAnalysisFactory iaFactory,
            IImageDescriptionFactory dFactory,
            ISetAltTagsAllFactory satarFactory,
            ISitecoreDataService dataService)
        {
            Assert.IsNotNull(searchService, typeof(ISearchService));
            Assert.IsNotNull(iaFactory, typeof(ICognitiveImageAnalysisFactory));
            Assert.IsNotNull(dFactory, typeof(IImageDescriptionFactory));
            Assert.IsNotNull(satarFactory, typeof(ISetAltTagsAllFactory));
            Assert.IsNotNull(dataService, typeof(ISitecoreDataService));
            
            SearchService = searchService;
            ImageAnalysisFactory = iaFactory;
            ImageDescriptionFactory = dFactory;
            SetAltTagsAllFactory = satarFactory;
            DataService = dataService;
        }

        #region Set Alt Tags

        public ActionResult ViewImageDescription(string id, string language, string db)
        {
            Item item = DataService.GetItemByIdValue(id, db);
            if (item == null)
                return View("ImageDescription");

            MediaItem m = item;
            
            return View("ImageDescription", SearchService.GetImageDescription(m, language));
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
            DataService.SetImageDescription(m, descriptionOption);

            return View("ImageDescription", SearchService.GetImageDescription(m, language));
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
            IEnumerable<MediaItem> fullList = DataService
                .GetMediaFileDescendents(id, db)
                .ToList();
                
            IEnumerable<MediaItem> list = fullList
                .Where(a => !string.IsNullOrEmpty(a.Alt) && !overwrite)
                .ToList();

            if (!list.Any())
                return Json(SetAltTagsAllFactory.Create(id, db, language, 0, 0, 50, false));

            var thresholdDouble = (double)threshold / 100;
            foreach (var m in list)
            {   
                Caption cap = SearchService.GetTopImageCaption(m, language, thresholdDouble);
                if (cap != null)
                    DataService.SetImageDescription(m, cap.Text);
            }

            var result = SetAltTagsAllFactory.Create(id, db, language, fullList.Count(), list.Count(), threshold, overwrite);

            return Json(result);
        }

        #endregion Set Alt Tags All Descendants
    }
}