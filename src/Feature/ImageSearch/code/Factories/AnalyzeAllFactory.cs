using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public class AnalyzeAllFactory : IAnalyzeAllFactory
    {
        protected readonly IServiceProvider Provider;

        public AnalyzeAllFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IAnalyzeAll Create(string itemId, string db, string language, string handleName)
        {
            var obj = Provider.GetService<IAnalyzeAll>();

            obj.ItemId = itemId;
            obj.Database = db;
            obj.Language = language;
            obj.HandleName = handleName;

            return obj;
        }
    }
}