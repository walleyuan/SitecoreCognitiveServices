using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Models;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Face = Microsoft.ProjectOxford.Face.Contract.Face;

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
            
            try {
                var eJson = (result != null) ? result.EmotionAnalysis : string.Empty;
                analysis.EmotionAnalysis = jsd.Deserialize<Emotion[]>(eJson);
            } catch { }

            try {
                var fJson = (result != null) ? result.FacialAnalysis : string.Empty;
                analysis.FacialAnalysis = jsd.Deserialize<Face[]>(fJson);
            } catch { }

            try {
                var tJson = (result != null) ? result.TextAnalysis : string.Empty;
                analysis.TextAnalysis = jsd.Deserialize<OcrResults>(tJson);
            } catch { }

            try {
                var vJson = (result != null) ? result.VisionAnalysis : string.Empty;
                analysis.VisionAnalysis = jsd.Deserialize<AnalysisResult>(vJson);
            } catch { }
            
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