extern alias MicrosoftProjectOxfordCommon;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Language;
using Sitecore.SharedSource.CognitiveServices.Services.Knowledge;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LinkAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return string.Empty;

            var entityLinkingService = DependencyResolver.Current.GetService<IEntityLinkingService>();
            if (entityLinkingService == null)
                return string.Empty;

            List<LinkAnalysisResult> fieldResults = new List<LinkAnalysisResult>();
            IEnumerable<Field> fields = GetTextualFields(indexItem);

            foreach (Field f in fields)
            {
                string value = Regex.Replace(f.Value, "<.*?>", string.Empty);
                var result = entityLinkingService.Link(value) ?? new EntityLink[0];

                fieldResults.Add(
                    new LinkAnalysisResult()
                    {
                        EntityAnalysis = result,
                        FieldName = f.DisplayName,
                        FieldValue = value
                    });
            }
                
            var json = new JavaScriptSerializer().Serialize(fieldResults);

            return json;
        }
    }
}