using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class PrecisionSet
    {
        public List<PrecisionMetric> PrecisionMetrics { get; set; }
        public string Error { get; set; }
    }
}