using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Events
{
    public class MediaItemDeleted
    {
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IImageSearchService SearchService;

        public MediaItemDeleted(
            ISitecoreDataWrapper dataWrapper,
            IImageSearchService searchService)
        {
            DataWrapper = dataWrapper;
            SearchService = searchService;
        }

        public void OnItemDeleted(object sender, EventArgs args)
        {
            var item = Event.ExtractParameter(args, 0) as Item;
            Assert.IsNotNull(item, "No item in parameters");

            if (!DataWrapper.IsMediaFile(item))
                return;

            var analysis = SearchService.GetImageAnalysisItem(item.ID.ToShortID().ToString(), item.Language.Name, item.Database.Name);

            analysis?.Delete();
        }
    }
}