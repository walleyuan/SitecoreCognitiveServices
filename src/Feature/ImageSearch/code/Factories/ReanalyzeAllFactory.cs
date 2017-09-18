using System;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public class ReanalyzeAllFactory : IReanalyzeAllFactory
    {
        protected readonly IServiceProvider Provider;

        public ReanalyzeAllFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual IReanalyzeAll Create(string itemId, string db, string language, int itemCount)
        {
            var obj = Provider.GetService<IReanalyzeAll>();

            obj.ItemId = itemId;
            obj.Database = db;
            obj.Language = language;
            obj.ItemCount = itemCount;

            return obj;
        }
    }
}