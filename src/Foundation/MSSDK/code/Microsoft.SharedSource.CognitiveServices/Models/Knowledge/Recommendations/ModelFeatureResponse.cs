using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class ModelFeatureResponse
    {
        public int RankBuildId { get; set; }
        public string RankBuildDate { get; set; }
        public List<ModelFeature> Features { get; set; }
    }
}