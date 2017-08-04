using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class BuildDataStatisticsResponse
    {
        public int numberOfCatalogItems { get; set; }
        public int numberOfCatalogItemsInUsage { get; set; }
        public int numberOfUsers { get; set; }
        public int numberOfUsageRecords { get; set; }
        public float catalogCoverage { get; set; }
        public int numberOfCatalogItemsInBuild { get; set; }
        public int numberOfUsersInBuild { get; set; }
        public int numberOfUsageRecordsInBuild { get; set; }
        public float catalogCoverageInBuild { get; set; }
    }
}