extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LinkAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return false;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return false;

            List<LinkAnalysisResult> fieldResults = new List<LinkAnalysisResult>();
            IEnumerable<Field> fields = GetTextualFields(indexItem);

            foreach (Field f in fields)
            {
                try
                {
                    string value = Regex.Replace(f.Value, "<.*?>", string.Empty);
                    var result = Task.Run(async () => await crContext.EntityLinkingRepository.LinkAsync(value)).Result;
                    fieldResults.Add(
                        new LinkAnalysisResult()
                        {
                            EntityAnalysis = result,
                            FieldName = f.DisplayName,
                            FieldValue = value
                        });
                }
                catch (Exception ex) { LogError(ex, indexItem); }
            }
                
            var json = new JavaScriptSerializer().Serialize(fieldResults);

            return json;
        }
    }
}