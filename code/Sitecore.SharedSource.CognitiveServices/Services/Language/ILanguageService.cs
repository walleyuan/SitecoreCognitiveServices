
using Microsoft.ProjectOxford.Text.Language;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public interface ILanguageService
    {
        LanguageResponse GetLanguages(LanguageRequest request);
    }
}