
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Text;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models {
    public interface IKeyPhraseAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        SentimentDocumentResult KeyPhraseAnalysis { get; set; }
        string HighlightPhrases(string htmlEntity, string cssClass);
    }
}