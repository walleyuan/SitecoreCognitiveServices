
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Models.Analysis {
    public interface IKeyPhraseAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        SentimentDocumentResult KeyPhraseAnalysis { get; set; }
        string HighlightPhrases(string htmlEntity, string cssClass);
    }
}