using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Language;

namespace Sitecore.SharedSource.CognitiveServices.Api.Language
{
    /// <summary>
    /// Stubs out the internal interface that Microsoft.ProjectOxford.Text.Language.LanguageClient implements
    /// </summary>
    public interface ILanguageClient
    {
        LanguageResponse GetLanguages(LanguageRequest request);
        Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request);
    }
}
