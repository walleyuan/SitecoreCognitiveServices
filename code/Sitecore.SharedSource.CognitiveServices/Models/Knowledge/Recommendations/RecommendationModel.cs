using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class RecommendationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDateTime { get; set; }
        public int ActiveBuildId { get; set; }
        public string CatalogDisplayName { get; set; }
    }
}