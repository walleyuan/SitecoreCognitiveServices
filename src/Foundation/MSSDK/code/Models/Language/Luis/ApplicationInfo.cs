using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class ApplicationInfo {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Culture { get; set; }
        public string UsageScenario { get; set; }
        public string Domain { get; set; }
        public int VersionsCount { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public ApplicationEndpoints Endpoints { get; set; }
        public int EndpointHitsCount { get; set; }
    }
}