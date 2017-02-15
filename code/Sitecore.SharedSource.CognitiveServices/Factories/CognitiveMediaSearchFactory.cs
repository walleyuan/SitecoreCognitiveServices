using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveMediaSearchFactory : ICognitiveMediaSearchFactory
    {
        protected readonly IReflectionUtilWrapper ReflectionUtil;

        public CognitiveMediaSearchFactory(IReflectionUtilWrapper reflectionUtil)
        {
            ReflectionUtil = reflectionUtil;
        }

        public ICognitiveMediaSearch Create()
        {
            return ReflectionUtil.CreateObjectFromSettings<ICognitiveMediaSearch>("CognitiveService.Types.ICognitiveMediaSearch");
        }

        public ICognitiveMediaSearch Create(string db, string language)
        {
            var r = Create();
            r.Database = db;
            r.Language = language;

            return r;
        }
    }
}