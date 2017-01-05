using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
