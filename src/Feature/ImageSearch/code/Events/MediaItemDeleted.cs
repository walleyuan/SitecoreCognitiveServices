using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Events
{
    public class MediaItemDeleted
    {
        protected readonly IImageSearchService SearchService;

        public MediaItemDeleted(IImageSearchService searchService)
        {
            SearchService = searchService;
        }

        public void OnItemDeleted(object sender, EventArgs args)
        {
            var item = Event.ExtractParameter(args, 0) as Item;
            Assert.IsNotNull(item, "No item in parameters");

            var analysis = SearchService.GetImageAnalysisItem(item.ID.ToString(), item.Language.Name, item.Database.Name);

            analysis?.Delete();
        }
    }
}