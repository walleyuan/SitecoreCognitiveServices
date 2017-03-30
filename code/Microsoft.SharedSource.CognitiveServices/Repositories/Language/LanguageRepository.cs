using Microsoft.ProjectOxford.Text.Language;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language
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
