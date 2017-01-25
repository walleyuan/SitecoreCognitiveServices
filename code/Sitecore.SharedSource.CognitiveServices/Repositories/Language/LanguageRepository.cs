using Microsoft.ProjectOxford.Text.Language;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class LanguageRepository : LanguageClient, ILanguageRepository
    {
        public LanguageRepository(
            IApiKeys apiKeys)
            : base(apiKeys.TextAnalytics)
        {
        }
    }
}
