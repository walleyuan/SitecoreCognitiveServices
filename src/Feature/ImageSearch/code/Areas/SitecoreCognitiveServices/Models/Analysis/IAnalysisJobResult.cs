namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis
{
    public interface IAnalysisJobResult
    {
        long Current { get; set; }
        long Total { get; set; }
        bool Completed { get; set; }
    }
}