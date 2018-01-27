namespace SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis
{
    public class AnalysisJobResult : IAnalysisJobResult
    {
        public long Current { get; set; }
        public long Total { get; set; }
        public bool Completed { get; set; }
    }
}