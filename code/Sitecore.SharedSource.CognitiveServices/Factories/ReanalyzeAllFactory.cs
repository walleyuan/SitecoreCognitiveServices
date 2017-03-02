using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.Models.Utility;

namespace Sitecore.SharedSource.CognitiveServices.Factories
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