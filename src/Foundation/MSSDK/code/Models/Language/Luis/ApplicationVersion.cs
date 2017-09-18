using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class ApplicationVersion {
        public string Version { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public DateTime LastTrainedDateTime { get; set; }
        public DateTime LastPublishedDateTime { get; set; }
        public string EndpointUrl { get; set; }
        public SubscriptionKeySet AssignedEndpointKey { get; set; }
        public ExternalApiKeySet ExternalApiKeys { get; set; }
        public int IntentsCount { get; set; }
        public int EntitiesCount { get; set; }
        public int EndpointHitsCount { get; set; }
    }
}