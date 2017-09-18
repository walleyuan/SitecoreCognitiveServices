using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class SearchCatalogItemsResponse
    {
        public List<CatalogItem> Value { get; set; }
        [JsonProperty("@NextLink")]
        public string NextLink { get; set; }
    }
}