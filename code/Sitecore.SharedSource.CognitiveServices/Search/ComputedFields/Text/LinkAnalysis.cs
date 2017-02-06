extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.Data.Items;
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
            
            string fieldValues = Regex.Replace(
                indexItem.Fields
                    .Where(f => !f.Name.StartsWith("__") && TextualFieldTypes.Contains(f.Type))
                    .Select(f => f.Value)
                    .Aggregate((a, b) => $"{a} {b}")
                , "<.*?>"
                , string.Empty);
            
            try {
                var result = Task.Run(async () => await crContext.EntityLinkingRepository.LinkAsync(fieldValues)).Result;
                var json = new JavaScriptSerializer().Serialize(result);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return false;
        }
    }
}