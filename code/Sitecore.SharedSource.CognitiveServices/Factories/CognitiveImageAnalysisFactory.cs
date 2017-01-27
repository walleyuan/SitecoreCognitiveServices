using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;
using Sitecore.Data.Items;
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
            var jsd = new JavaScriptSerializer();

            var analysis = Create();
            analysis.EmotionAnalysis = result.EmotionAnalysis;
            analysis.FacialAnalysis = result.FacialAnalysis;
            analysis.TextAnalysis = result.TextAnalysis;
            analysis.VisionAnalysis = result.VisionAnalysis;
            
            Item i = DataService.GetItemByUri(result?.UniqueId ?? string.Empty);
            if (i == null)
                return analysis;

            analysis.ImageHeight = GetNumber(i, "height", 0);
            analysis.ImageWidth = GetNumber(i, "width", 0);
            analysis.ImageUrl = $"/sitecore/shell/Applications/-/media/{i.ID.Guid:N}.ashx?db=master";

            return analysis;
        }

        private int GetNumber(Item i, string field, int fallback)
        {
            if (i.Fields[field] == null) 
                return fallback;

            int value = 0;
            return (!int.TryParse(i[field], out value))
                ? fallback
                : value;
        }
    }
}