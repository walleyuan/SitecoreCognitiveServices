using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.Recommendations
{
    public class SearchCatalogItemsResponse
    {
        public List<CatalogItem> Value { get; set; }
        [JsonProperty("@NextLink")]
        public string NextLink { get; set; }
    }
}