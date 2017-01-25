using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Language;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
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
