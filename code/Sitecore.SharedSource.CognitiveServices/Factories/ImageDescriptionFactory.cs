using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Utility;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class ImageDescriptionFactory : IImageDescriptionFactory
    {
        protected readonly IReflectionUtilWrapper ReflectionUtil;

        public ImageDescriptionFactory(IReflectionUtilWrapper reflectionUtil)
        {
            ReflectionUtil = reflectionUtil;
        }

        public virtual IImageDescription Create()
        {
            var obj = ReflectionUtil.CreateObjectFromSettings<IImageDescription>("CognitiveService.Types.IImageDescription");

            obj.CognitiveDescription = new Description();
            obj.AltDescription = string.Empty;
            obj.ItemId = string.Empty;
            obj.Database = string.Empty;
            obj.Language = string.Empty;

            return obj;
        }

        public virtual IImageDescription Create(Description cognitiveDescription, string altDescription, string itemId, string database, string language)
        {
            var obj = Create();

            obj.CognitiveDescription = cognitiveDescription;
            obj.AltDescription = altDescription;
            obj.ItemId = itemId;
            obj.Database = database;
            obj.Language = language;

            return obj;
        }
    }
}