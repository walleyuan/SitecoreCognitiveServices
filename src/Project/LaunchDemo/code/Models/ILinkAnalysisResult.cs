

using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.EntityLinking;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models {
    public interface ILinkAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        EntityLink[] EntityAnalysis { get; set; }
        string HighlightLinks(string htmlEntity, string cssClass, double scoreThreshold);
    }
}