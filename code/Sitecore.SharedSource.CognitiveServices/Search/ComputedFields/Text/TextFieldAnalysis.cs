extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Text
{
    public class TextFieldAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            if (!indexItem.Paths.IsContentItem)
                return false;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return false;
            
            var ctaFactory = DependencyResolver.Current.GetService<ICognitiveTextAnalysisFactory>();
            if (ctaFactory == null)
                return false;
            
            string fieldValues = indexItem.Fields
                .Where(f => !f.Name.StartsWith("__"))
                .Select(f => f.Value)
                .Aggregate((a, b) => $"{a} {b}");

            Document d = new Document();
            d.Text = fieldValues;
            d.Id = indexItem.ID.ToString();

            ICognitiveTextAnalysis cta = ctaFactory.Create();

            try {
                cta.LinkAnalysis = Task.Run(async () => await crContext.EntityLinkingRepository.LinkAsync(fieldValues)).Result;
            } catch (Exception ex) { LogError(ex, indexItem); }

            try {
                SentimentRequest sr = new SentimentRequest();
                sr.Documents.Add(d);
                cta.SentimentAnalysis = Task.Run(async () => await crContext.SentimentRepository.GetSentimentAsync(sr)).Result;
            } catch (Exception ex) { LogError(ex, indexItem); }

            try {
                LanguageRequest lr = new LanguageRequest();
                lr.Documents.Add(d);
                cta.LanguageAnalysis = Task.Run(async () => await crContext.LanguageRepository.GetLanguagesAsync(lr)).Result;
            } catch (Exception ex) { LogError(ex, indexItem); }

            var json = new JavaScriptSerializer().Serialize(cta);

            return json;
        }
    }
}