using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Utility;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class SetAltTagsAllFactory : ISetAltTagsAllFactory
    {
        protected readonly IReflectionUtilWrapper ReflectionUtil;

        public SetAltTagsAllFactory(IReflectionUtilWrapper reflectionUtil)
        {
            ReflectionUtil = reflectionUtil;
        }

        public virtual ISetAltTagsAll Create(string itemId, string db, string language, int itemCount, int itemsModified, int threshold, bool overwrite)
        {
            var obj = ReflectionUtil.CreateObjectFromSettings<ISetAltTagsAll>("CognitiveService.Types.ISetAltTagsAll");

            obj.ItemId = itemId;
            obj.Database = db;
            obj.Language = language;
            obj.ItemCount = itemCount;
            obj.ItemsModified = itemsModified;
            obj.Threshold = threshold;
            obj.Overwrite = overwrite;

            return obj;
        }
    }
}