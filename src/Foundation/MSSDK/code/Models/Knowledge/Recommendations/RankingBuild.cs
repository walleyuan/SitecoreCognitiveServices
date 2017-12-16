using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class RankingBuild
    {
        public int NumberOfModelIterations { get; set; }
        public int NumberOfModelDimensions { get; set; }
        public int ItemCutOffLowerBound { get; set; }
        public int ItemCutOffUpperBound { get; set; }
        public int UserCutOffLowerBound { get; set; }
        public int UserCutOffUpperBound { get; set; }
    }
}