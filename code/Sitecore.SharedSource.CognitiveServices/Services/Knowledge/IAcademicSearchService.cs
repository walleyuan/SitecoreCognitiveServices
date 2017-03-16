using Sitecore.SharedSource.CognitiveServices.Enums;
using Sitecore.SharedSource.CognitiveServices.Models.Knowledge;

namespace Sitecore.SharedSource.CognitiveServices.Services.Knowledge
{
    public interface IAcademicSearchService
    {
        CalcHistogramResponse CalcHistogram(string expression, AcademicModelOptions model, string attributes = "", int count = 10, int offset = 0);
        EvaluateResponse Evaluate(string expression, AcademicModelOptions model, int count = 10, int offset = 0, string attributes = "", string orderby = "");
        GraphSearchResponse GraphSearch(GraphSearchRequest request);
        InterpretResponse Interpret(string query, bool complete = false, int count = 10, int offset = 0, int timeout = 0, AcademicModelOptions model = AcademicModelOptions.latest);
        double Similarity(string s1, string s2);
    }
}