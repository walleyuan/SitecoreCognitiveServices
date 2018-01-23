using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis
{
    public class AnalysisJobResult : IAnalysisJobResult
    {
        public long Current { get; set; }
        public long Total { get; set; }
        public bool Completed { get; set; }
    }
}