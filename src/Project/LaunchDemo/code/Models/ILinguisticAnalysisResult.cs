
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models {
    public interface ILinguisticAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        POSTagsTextAnalysisResponse POSTagsAnalysis { get; set; }
        ConstituencyTreeTextAnalysisResponse ConstituencyTreeAnalysis { get; set; }
        TokensTextAnalysisResponse TokensAnalysis { get; set; }
        string HighlightPOSTags(string htmlEntity, string cssClass);
        string HighlightConstituencyTree(string htmlEntity, string cssClass);
        string HighlightTokens(string htmlEntity, string cssClass);
    }
}