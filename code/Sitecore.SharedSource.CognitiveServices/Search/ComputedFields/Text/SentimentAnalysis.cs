extern alias MicrosoftProjectOxfordCommon;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class SentimentAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return string.Empty;

            var sentimentService = DependencyResolver.Current.GetService<ISentimentService>();
            if (sentimentService == null)
                return string.Empty;
            
            SentimentRequest sr = new SentimentRequest();

            IEnumerable<Field> fields = GetTextualFields(indexItem);
            foreach (Field f in fields)
            {
                sr.Documents.Add(new Document()
                {
                    Text = GetFormattedString(f.Value, 10240),
                    Id = f.DisplayName
                });
            }
                
            var result = sentimentService.GetSentiment(sr);
            if (result == null)
                return string.Empty;
            
            var json = new JavaScriptSerializer().Serialize(result);

            return json;
        }
    }
}