using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Repositories;
using Sitecore.SharedSource.CognitiveServices.Repositories.Language;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LinguisticAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return string.Empty;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
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
                try {
                    var result1 = Task.Run(async () => await crContext.LinguisticRepository.GetPOSTagsTextAnalysisAsync(tar)).Result;
                    var result2 = Task.Run(async () => await crContext.LinguisticRepository.GetConstituencyTreeTextAnalysisAsync(tar)).Result;
                    var result3 = Task.Run(async () => await crContext.LinguisticRepository.GetTokensTextAnalysisAsync(tar)).Result;

                    fieldResults.Add(new LinguisticAnalysisResult()
                    {
                        FieldName = f.DisplayName,
                        FieldValue = value,
                        POSTagsAnalysis = result1,
                        ConstituencyTreeAnalysis = result2,
                        TokensAnalysis = result3
                    });
                } catch (Exception ex) { LogError(ex, indexItem); }
            }

            var json = new JavaScriptSerializer().Serialize(fieldResults);

            return json;
        }
    }
}