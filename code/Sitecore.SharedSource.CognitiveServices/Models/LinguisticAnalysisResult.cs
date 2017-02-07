using System.Collections.Generic;
using System.Linq;
using Sitecore.SharedSource.CognitiveServices.Repositories.Language;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class LinguisticAnalysisResult : ILinguisticAnalysisResult
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public POSTagsTextAnalysisResponse POSTagsAnalysis { get; set; }
        public ConstituencyTreeTextAnalysisResponse ConstituencyTreeAnalysis { get; set; }
        public TokensTextAnalysisResponse TokensAnalysis { get; set; }
        public string HighlightTextParts(string htmlEntity, string cssClass)
        {
            string s = FieldValue;
            //foreach (TextAnalysisResponse l in LinguisticAnalysis)
            //{
            //    foreach (Match m in l.Matches)
            //    {
            //        s = s.Replace(m.Text, $"<{htmlEntity} class=\"{cssClass}\">{m.Text}</{htmlEntity}>");
            //    }
            //}

            return s;
        }
    }
}