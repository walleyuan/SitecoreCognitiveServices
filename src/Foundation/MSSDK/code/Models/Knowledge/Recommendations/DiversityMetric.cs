using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class DiversityMetric
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public float Percentage { get; set; }
    }
}