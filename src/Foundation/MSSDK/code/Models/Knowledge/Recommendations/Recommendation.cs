using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class Recommendation
    {
        public List<RecommendationItem> Items { get; set; }
        public int Rating { get; set; }
        public List<string> Reasoning { get; set; }
    }
}