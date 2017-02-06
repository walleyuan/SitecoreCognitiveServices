extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LanguageAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return false;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return false;

            IEnumerable<Field> fields = indexItem.Fields
                .Where(f => !f.Name.StartsWith("__") && TextualFieldTypes.Contains(f.Type));
            
            try {
                LanguageRequest lr = new LanguageRequest();

                foreach (Field f in fields)
                {
                    Document d = new Document();
                    d.Text = Regex.Replace(f.Value, "<.*?>", string.Empty);
                    d.Id = f.DisplayName;
                    lr.Documents.Add(d);
                }

                var result = Task.Run(async () => await crContext.LanguageRepository.GetLanguagesAsync(lr)).Result;
                var json = new JavaScriptSerializer().Serialize(result);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return false;
        }
    }
}