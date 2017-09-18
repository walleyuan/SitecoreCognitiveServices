using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class BuildMetricsResponse
    {
        public PrecisionSet PrecisionItemsRecommend { get; set; }
        public PrecisionSet PrecisionUserRecommend { get; set; }
        public PrecisionSet PrecisionPopularItemRecommend { get; set; }
        public DiversitySet DiversityItemRecommend { get; set; }
        public DiversitySet DiversityUserRecommend { get; set; }
    }
}