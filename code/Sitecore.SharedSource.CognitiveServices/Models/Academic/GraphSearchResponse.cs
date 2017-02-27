using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Pipelines.GetAboutInformation;

namespace Sitecore.SharedSource.CognitiveServices.Models.Academic {
    public class GraphSearchResponse
    {
        public List<List<GraphSearchResult>> Results { get; set; }
    }
}