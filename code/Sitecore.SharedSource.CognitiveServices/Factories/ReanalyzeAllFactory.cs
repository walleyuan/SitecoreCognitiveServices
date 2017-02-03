using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class ReanalyzeAllFactory : IReanalyzeAllFactory
    {
        public IReanalyzeAll Create()
        {
            return new ReanalyzeAll()
            {
                ItemCount = 0
            };
        }

        public IReanalyzeAll Create(int itemCount, string db, string language, string itemId)
        {
            return new ReanalyzeAll()
            {
                ItemCount = itemCount
            };
        }
    }
}