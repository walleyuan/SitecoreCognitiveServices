using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Bing
{
    public class ImageInsightResponse
    {
        public string _type { get; set; }
        public SearchInstrumentation Instrumentation { get; set; }
        public BestRepresentativeQuery BestRepresentativeQuery { get; set; }
        public List<ImageSearchResult> PagesIncluding { get; set; }
        public List<ImageSearchQuickResult> RelatedSearches { get; set; }
        public List<ImageSearchResult> VisuallySimilarImages { get; set; }
        public string ImageInsightsToken { get; set; }
        public CategoryClassification CategoryClassification { get; set; }
    }
}