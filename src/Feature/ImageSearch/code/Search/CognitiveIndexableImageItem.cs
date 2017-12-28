using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
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

            Text = JsonConvert.DeserializeObject<OcrResults>(imageAnalysisItem.Fields["Text Analysis"]?.Value ?? string.Empty);
            Visions = JsonConvert.DeserializeObject<AnalysisResult>(imageAnalysisItem.Fields["Vision Analysis"]?.Value ?? string.Empty);
            Faces = JsonConvert.DeserializeObject<Face[]>(imageAnalysisItem.Fields["Facial Analysis"]?.Value ?? string.Empty);
            Emotions = JsonConvert.DeserializeObject<Emotion[]>(imageAnalysisItem.Fields["Emotion Analysis"]?.Value ?? string.Empty);
        }
    }
}