using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Language.Luis {
    public class AddApplicationRequest {
        public string name { get; set; }
        public string description { get; set; }
        public string culture { get; set; }
        public string usageScenario { get; set; }
        public string domain { get; set; }
        public string initialVersionId { get; set; }
    }
}