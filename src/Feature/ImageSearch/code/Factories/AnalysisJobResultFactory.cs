using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public class AnalysisJobResultFactory : IAnalysisJobResultFactory
    {
        protected readonly IServiceProvider Provider;

        public AnalysisJobResultFactory(IServiceProvider provider)
        {
            Provider = provider;
        }
        
        public virtual IAnalysisJobResult Create(long current, long total, bool completed)
        {
            var obj = Provider.GetService<IAnalysisJobResult>();

            obj.Current = current;
            obj.Total = total;
            obj.Completed = completed;

            return obj;
        }
    }
}