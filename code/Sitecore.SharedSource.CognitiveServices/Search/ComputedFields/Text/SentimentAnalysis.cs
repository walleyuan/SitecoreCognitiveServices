extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class SentimentAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return false;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return false;
            
            try {
                SentimentRequest sr = new SentimentRequest();

                IEnumerable<Field> fields = GetTextualFields(indexItem);
                foreach (Field f in fields)
                {
                    Document d = new Document();
                    d.Text = Regex.Replace(f.Value, "<.*?>", string.Empty);
                    d.Id = f.DisplayName;
                    sr.Documents.Add(d);
                }
                
                var result = Task.Run(async () => await crContext.SentimentRepository.GetSentimentAsync(sr)).Result;
                var json = new JavaScriptSerializer().Serialize(result);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return false;
        }
    }
}