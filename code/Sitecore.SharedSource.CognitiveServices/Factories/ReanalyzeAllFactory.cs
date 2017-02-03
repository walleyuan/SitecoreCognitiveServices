using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class ReanalyzeAllFactory : IReanalyzeAllFactory
    {
        public IReanalyzeAll Create(string itemId, string db, string language, int itemCount)
        {
            return new ReanalyzeAll()
            {
                ItemId = itemId,
                Database = db,
                Language = language,
                ItemCount = itemCount
            };
        }
    }
}