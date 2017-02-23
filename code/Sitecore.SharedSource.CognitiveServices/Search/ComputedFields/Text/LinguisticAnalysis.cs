using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Language;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LinguisticAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return string.Empty;

            var linguisticService = DependencyResolver.Current.GetService<ILinguisticService>();
            if (linguisticService == null)
                return string.Empty;
            
            List<LinguisticAnalysisResult> fieldResults = new List<LinguisticAnalysisResult>();
            IEnumerable<Field> fields = GetTextualFields(indexItem);
            foreach (Field f in fields)
            {
                string value = RemoveHtmlMarkup(f.Value);
                TextAnalysisRequest tar = new TextAnalysisRequest()
                {
                    Language = indexItem.Language.Name,
                    Text = value
                };
                
                var result1 = linguisticService.GetPOSTagsTextAnalysis(tar) ?? new POSTagsTextAnalysisResponse();
                var result2 = linguisticService.GetConstituencyTreeTextAnalysis(tar) ?? new ConstituencyTreeTextAnalysisResponse();
                //var result3 = linguisticService.GetTokensTextAnalysis(tar) ?? new TokensTextAnalysisResponse();
                
                fieldResults.Add(new LinguisticAnalysisResult()
                {
                    FieldName = f.DisplayName,
                    FieldValue = value,
                    POSTagsAnalysis = result1,
                    ConstituencyTreeAnalysis = result2,
                    TokensAnalysis = null
                });
            }

            var json = new JavaScriptSerializer().Serialize(fieldResults);

            return json;
        }
    }
}