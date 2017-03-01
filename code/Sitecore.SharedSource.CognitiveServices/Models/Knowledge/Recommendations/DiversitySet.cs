using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class DiversitySet
    {
        public List<DiversityMetric> PercentileBuckets { get; set; }
        public int TotalItemsRecommended { get; set; }
        public int UniqueItemsRecommended { get; set; }
        public int UniqueItemsInTrainSet { get; set; }
        public string Error { get; set; }
    }
}