
using System.Collections.Generic;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Sitecore.SharedSource.CognitiveServices.Repositories.Language;

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