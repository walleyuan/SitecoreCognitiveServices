using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class KeyPhraseAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return string.Empty;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return string.Empty;
            
            try {
                SentimentRequest sr = new SentimentRequest();

                Dictionary<string, Field> fields = GetTextualFields(indexItem).ToDictionary(a => a.DisplayName);
                foreach (var f in fields)
                {
                    sr.Documents.Add(new Document()
                    {
                        Text = GetFormattedString(f.Value.Value, 10240),
                        Id = f.Value.DisplayName
                    });
                }

                var result = Task.Run(async () => await crContext.SentimentRepository.GetKeyPhrasesAsync(sr)).Result;

                List<KeyPhraseAnalysisResult> fieldResults = result
                    .Documents
                    .Select(d => new KeyPhraseAnalysisResult()
                    {
                        FieldName = d.Id,
                        FieldValue = fields[d.Id].Value,
                        KeyPhraseAnalysis = d
                    })
                    .ToList();

                var json = new JavaScriptSerializer().Serialize(fieldResults);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return string.Empty;
        }
    }
}