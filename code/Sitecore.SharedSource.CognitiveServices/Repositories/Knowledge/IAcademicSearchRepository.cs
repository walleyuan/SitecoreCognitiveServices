using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge;
using System.Threading.Tasks;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Knowledge {
    public interface IAcademicSearchRepository
    {
        HistogramResult CalcHistogram(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0);
        Task<HistogramResult> CalcHistogramAsync(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0);
        EvaluateResponse Evaluate(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "");
        Task<EvaluateResponse> EvaluateAsync(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "");
        GraphSearchResponse GraphSearch(AcademicGraphModeOptions mode, GraphSearchRequest request);
        Task<GraphSearchResponse> GraphSearchAsync(AcademicGraphModeOptions mode, GraphSearchRequest request);
        InterpretResponse Interpret(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest);
        Task<InterpretResponse> InterpretAsync(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest);
        double Similarity(string s1, string s2);
        Task<double> SimilarityAsync(string s1, string s2);
    }
}