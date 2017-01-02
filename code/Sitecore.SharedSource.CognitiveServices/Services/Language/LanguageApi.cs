using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Language;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public class LanguageApi : LanguageClient, ILanguageApi
    {
        public LanguageApi(
            IApiKeys apiKeys)
            : base(apiKeys.LinguisticAnalysis)
        {
        }
    }
}
