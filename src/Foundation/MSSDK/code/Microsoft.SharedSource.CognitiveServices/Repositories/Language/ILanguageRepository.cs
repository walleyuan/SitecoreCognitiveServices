
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Language;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language
{
    public interface ILanguageRepository
    {
        #region Client Methods
        /// <summary>
        /// Stubs out the internal interface that Microsoft.ProjectOxford.Text.Language.LanguageClient implements
        /// </summary>
        LanguageResponse GetLanguages(LanguageRequest request);
        Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request);
        #endregion Client Methods
    }
}
