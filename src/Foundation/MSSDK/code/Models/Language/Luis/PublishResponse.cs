﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis {
    public class PublishResponse {
        public string EndpointUrl { get; set; }
        [JsonProperty(PropertyName = "subscription-key")]
        public string SubscriptionKey { get; set; }
        public string EndpointRegion { get; set; }
        public bool IsStaging { get; set; }
    }
}