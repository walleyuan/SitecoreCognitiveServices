using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class PublishRequest {
        public string VersionId { get; set; }
        public bool IsStaging { get; set; }
        public string EndpointRegion { get; set; }
    }
}