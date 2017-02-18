
namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface IKeyPhraseAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        SentimentDocumentResult KeyPhraseAnalysis { get; set; }
        string HighlightPhrases(string htmlEntity, string cssClass);
    }
}