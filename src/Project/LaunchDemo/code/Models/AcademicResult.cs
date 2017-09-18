
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Knowledge.AcademicSearch;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
{
    public class AcademicResult
    {
        public CalcHistogramResponse Histogram { get; set; }
        public EvaluateResponse Evaluate { get; set; }
        public GraphSearchResponse GraphSearch { get; set; }
        public InterpretResponse Interpret { get; set; }
        public double Similarity { get; set; }
        public object SimilarityRun { get; set; }
    }
}