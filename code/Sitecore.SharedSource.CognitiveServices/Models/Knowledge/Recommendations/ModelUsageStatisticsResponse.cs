using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class ModelUsageStatisticsResponse
    {
        public string Interval { get; set; }
        public List<UsageEventStatistic> Statistics { get; set; }
    }
}