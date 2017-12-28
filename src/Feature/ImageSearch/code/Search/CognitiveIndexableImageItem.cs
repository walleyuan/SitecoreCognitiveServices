using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search
{
    public class CognitiveIndexableImageItem : SitecoreIndexableItem
    {
        public OcrResults Text { get; set; }

        public AnalysisResult Visions { get; set; }

        public Face[] Faces { get; set; }

        public Emotion[] Emotions { get; set; }

        public CognitiveIndexableImageItem(Item item) : base(item)
        {
            var dataWrapper = DependencyResolver.Current.GetService<ISitecoreDataWrapper>();
            if (!(dataWrapper?.IsMediaFile(item) ?? false))
                return;

            var searchService = DependencyResolver.Current.GetService<IImageSearchService>();
            var imageAnalysisItem = searchService?.GetImageAnalysisItem(item.ID.ToShortID().ToString(), item.Language.Name, item.Database.Name);
            if (imageAnalysisItem == null)
                return;

            var settings = DependencyResolver.Current.GetService<IImageSearchSettings>();
            if (settings == null)
                return;

            Visions = JsonConvert.DeserializeObject<AnalysisResult>(imageAnalysisItem.Fields[settings.VisualAnalysisField]?.Value ?? string.Empty);
            Text = JsonConvert.DeserializeObject<OcrResults>(imageAnalysisItem.Fields[settings.TextualAnalysisField]?.Value ?? string.Empty);
            Faces = JsonConvert.DeserializeObject<Face[]>(imageAnalysisItem.Fields[settings.FacialAnalysisField]?.Value ?? string.Empty);
            Emotions = JsonConvert.DeserializeObject<Emotion[]>(imageAnalysisItem.Fields[settings.EmotionalAnalysisField]?.Value ?? string.Empty);
        }
    }
}