using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class PublishRequest {
        public string VersionId { get; set; }
        public string IsStaging { get; set; }
    }
}