using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public interface IAnalysisJobResultFactory
    {
        IAnalysisJobResult Create(long current, long total, bool completed);
    }
}