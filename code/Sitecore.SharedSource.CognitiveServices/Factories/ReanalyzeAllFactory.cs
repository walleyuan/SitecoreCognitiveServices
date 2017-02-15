using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class ReanalyzeAllFactory : IReanalyzeAllFactory
    {
        protected readonly IReflectionUtilWrapper ReflectionUtil;

        public ReanalyzeAllFactory(IReflectionUtilWrapper reflectionUtil)
        {
            ReflectionUtil = reflectionUtil;
        }

        public IReanalyzeAll Create(string itemId, string db, string language, int itemCount)
        {
            var obj = ReflectionUtil.CreateObjectFromSettings<IReanalyzeAll>("CognitiveService.Types.IReanalyzeAll");

            obj.ItemId = itemId;
            obj.Database = db;
            obj.Language = language;
            obj.ItemCount = itemCount;

            return obj;
        }
    }
}