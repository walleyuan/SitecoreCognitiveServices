using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis
{
    public interface IAnalysisJobResult
    {
        long Current { get; set; }
        long Total { get; set; }
        bool Completed { get; set; }
    }
}