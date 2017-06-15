using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class GetAllCatalogItemsResponse
    {
        public List<string> Value { get; set; }
        [JsonProperty("@NextLink")]
        public string NextLink { get; set; }
    }
}