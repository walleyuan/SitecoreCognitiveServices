using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class ItemRecommendationResponse
    {
        public List<Recommendation> RecommendedItems { get; set; }
    }
}