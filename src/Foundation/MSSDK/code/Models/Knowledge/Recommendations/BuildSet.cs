using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class BuildSet
    {
        public RankingBuild Ranking { get; set; }
        public RecommendationBuild Recommendation { get; set; }
        public FrequentlyBoughtTogetherBuild FBT { get; set; }
    }
}