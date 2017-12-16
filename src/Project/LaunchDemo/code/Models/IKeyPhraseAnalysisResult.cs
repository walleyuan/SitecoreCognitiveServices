
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Text;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models {
    public interface IKeyPhraseAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        KeyPhraseDocumentResult KeyPhraseAnalysis { get; set; }
        string HighlightPhrases(string htmlEntity, string cssClass);
    }
}