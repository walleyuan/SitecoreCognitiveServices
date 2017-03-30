using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class BuildUsageStatisticsResponse
    {
        public string Interval { get; set; }
        public int BuildId { get; set; }
        public List<UsageEventStatistic> Statistics { get; set; }
    }
}