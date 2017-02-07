extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return string.Empty;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return string.Empty;
            
            try {
                LanguageRequest lr = new LanguageRequest();

                IEnumerable<Field> fields = GetTextualFields(indexItem);
                foreach (Field f in fields)
                {
                    lr.Documents.Add(new Document()
                    {
                        Text = GetFormattedString(f.Value, 10240),
                        Id = f.DisplayName
                    });
                }

                var result = Task.Run(async () => await crContext.LanguageRepository.GetLanguagesAsync(lr)).Result;
                var json = new JavaScriptSerializer().Serialize(result);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return string.Empty;
        }
    }
}