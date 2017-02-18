extern alias MicrosoftProjectOxfordCommon;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class LanguageAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return string.Empty;

            var languageService = DependencyResolver.Current.GetService<ILanguageService>();
            if (languageService == null)
                return string.Empty;
            
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

            var result = languageService.GetLanguages(lr);
            if (result == null)
                return string.Empty;
            
            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }
    }
}