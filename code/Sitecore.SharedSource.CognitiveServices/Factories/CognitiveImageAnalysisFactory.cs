using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveImageAnalysisFactory : ICognitiveImageAnalysisFactory
    {
        protected readonly ISitecoreDataService DataService;

        public CognitiveImageAnalysisFactory(ISitecoreDataService dataService)
        {
            DataService = dataService;
        }

        public ICognitiveImageAnalysis Create()
        {
            return new CognitiveImageAnalysis();
        }

        public ICognitiveImageAnalysis Create(ICognitiveSearchResult result)
        {
            var json = (result != null) ? result.ImageItemAnalysis : string.Empty;

            var obj = new JavaScriptSerializer().Deserialize<CognitiveImageAnalysis>(json);
            if(obj == null)
                return Create();

            Item i = DataService.GetItemByUri(result?.UniqueID ?? string.Empty);
            if (i == null)
                return obj;

            obj.ImageUrl = MediaManager.GetMediaUrl(i);
            return obj;
        }
    }
}