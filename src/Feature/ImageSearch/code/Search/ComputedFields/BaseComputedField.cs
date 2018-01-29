using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.ContentSearch.Diagnostics;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields
{
    public abstract class BaseComputedField : IComputedIndexField
    {
        public virtual string FieldName { get; set; }
        public virtual string ReturnType { get; set; }
        public OcrResults Text { get; set; }
        public AnalysisResult Visions { get; set; }
        public Face[] Faces { get; set; }
        public Emotion[] Emotions { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, "indexable");

            Item indexItem = indexable as SitecoreIndexableItem;
            if (indexItem == null)
                return null;

            if (indexItem?.Database?.Name == "core")
                return null;
            
            var settings = DependencyResolver.Current.GetService<IImageSearchSettings>();
            if (settings == null)
                return null;

            var searchService = DependencyResolver.Current.GetService<IImageSearchService>();
            var analysisItem = searchService?.GetImageAnalysisItem(indexItem.ID.ToShortID().ToString(), indexItem.Language.Name, indexItem.Database.Name);
            if (analysisItem == null)
                return null;

            Visions = JsonConvert.DeserializeObject<AnalysisResult>(analysisItem.Fields[settings.VisualAnalysisField]?.Value ?? string.Empty);
            Text = JsonConvert.DeserializeObject<OcrResults>(analysisItem.Fields[settings.TextualAnalysisField]?.Value ?? string.Empty);
            Faces = JsonConvert.DeserializeObject<Face[]>(analysisItem.Fields[settings.FacialAnalysisField]?.Value ?? string.Empty);
            Emotions = JsonConvert.DeserializeObject<Emotion[]>(analysisItem.Fields[settings.EmotionalAnalysisField]?.Value ?? string.Empty);

            return GetFieldValue(indexItem);
        }

        protected virtual object GetFieldValue(Item indexItem)
        {
            return null;
        }
    }
}