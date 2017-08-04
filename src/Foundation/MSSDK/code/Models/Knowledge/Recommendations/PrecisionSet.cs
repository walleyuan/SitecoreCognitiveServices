using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class PrecisionSet
    {
        public List<PrecisionMetric> PrecisionMetrics { get; set; }
        public string Error { get; set; }
    }
}