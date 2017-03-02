using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Analysis;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveImageAnalysisFactory : ICognitiveImageAnalysisFactory
    {
        protected readonly ISitecoreDataService DataService;
        protected readonly IServiceProvider Provider;


        public CognitiveImageAnalysisFactory(
            ISitecoreDataService dataService,
            IServiceProvider provider)
        {
            DataService = dataService;
            Provider = provider;
        }

        public virtual ICognitiveImageAnalysis Create()
        {
            return Provider.GetService<ICognitiveImageAnalysis>();
        }

        public virtual ICognitiveImageAnalysis Create(ICognitiveSearchResult result)
        {
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
            analysis.ImageUrl = $"/sitecore/shell/Applications/-/media/{i.ID.Guid:N}.ashx";

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