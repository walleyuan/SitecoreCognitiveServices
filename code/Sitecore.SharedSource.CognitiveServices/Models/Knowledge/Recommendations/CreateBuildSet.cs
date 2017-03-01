using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class CreateBuildSet
    {
        public RankingBuild Ranking { get; set; }
        public RecommendationBuild Recommendation { get; set; }
        public FrequentlyBoughtTogetherBuild FBT { get; set; }
    }
}