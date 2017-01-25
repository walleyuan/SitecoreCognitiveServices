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
            
            List<string> fieldTypes = new List<string>() { "Rich Text", "Single-Line Text", "Multi-Line Text", "html", "text", "memo" };
            
            string fieldValues = Regex.Replace(
                indexItem.Fields
                    .Where(f => !f.Name.StartsWith("__") && fieldTypes.Contains(f.Type))
                    .Select(f => f.Value)
                    .Aggregate((a, b) => $"{a} {b}")
                , "<.*?>"
                , string.Empty);

            Document d = new Document();
            d.Text = fieldValues;
            d.Id = indexItem.ID.ToString();
            
            try {
                SentimentRequest sr = new SentimentRequest();
                sr.Documents.Add(d);
                var result = Task.Run(async () => await crContext.SentimentRepository.GetSentimentAsync(sr)).Result;
                var json = new JavaScriptSerializer().Serialize(result);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return false;
        }
    }
}