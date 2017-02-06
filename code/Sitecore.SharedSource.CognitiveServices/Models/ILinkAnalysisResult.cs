
using Microsoft.ProjectOxford.EntityLinking.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public interface ILinkAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        EntityLink[] EntityAnalysis { get; set; }
        string HighlightLinks(string htmlEntity, string cssClass, double scoreThreshold);
    }
}