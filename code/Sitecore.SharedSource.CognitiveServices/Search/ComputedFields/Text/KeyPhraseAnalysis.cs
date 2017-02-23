using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Language;
using Sitecore.SharedSource.CognitiveServices.Services.Language;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class KeyPhraseAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return string.Empty;

            var sentimentService = DependencyResolver.Current.GetService<ISentimentService>();
            if (sentimentService == null)
                return string.Empty;
            
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

            var result = sentimentService.GetKeyPhrases(sr);
            if (result == null)
                return string.Empty;
            
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
        }
    }
}