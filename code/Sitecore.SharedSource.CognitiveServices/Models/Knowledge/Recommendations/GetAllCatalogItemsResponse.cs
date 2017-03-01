using Newtonsoft.Json;
using Sitecore.Mvc.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class GetAllCatalogItemsResponse
    {
        public List<string> Value { get; set; }
        [JsonProperty("@NextLink")]
        public string NextLink { get; set; }
    }
}