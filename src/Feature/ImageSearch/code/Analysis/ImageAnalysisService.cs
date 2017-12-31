using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Analysis
{
    public class ImageAnalysisService : IImageAnalysisService
    {
        #region Constructor

        protected readonly IImageSearchSettings _settings;
        protected readonly IImageSearchService _searchService;
        protected readonly ISitecoreDataWrapper _dataWrapper;
        protected readonly IEmotionService _emotionService;
        protected readonly IFaceService _faceService;
        protected readonly IVisionService _visionService;
        protected readonly ICognitiveImageAnalysisFactory _imageAnalysisFactory;
        
        public ImageAnalysisService(
            IImageSearchSettings settings,
            IImageSearchService searchService,
            ISitecoreDataWrapper dataWrapper,
            IEmotionService emotionService,
            IFaceService faceService,
            IVisionService visionService,
            ICognitiveImageAnalysisFactory imageAnalysisFactory)
        {
            _settings = settings;
            _searchService = searchService;
            _dataWrapper = dataWrapper;
            _emotionService = emotionService;
            _faceService = faceService;
            _visionService = visionService;
            _imageAnalysisFactory = imageAnalysisFactory;
        }

        #endregion
        
        public ICognitiveImageAnalysis AnalyzeImage(Item imageItem)
        {
            MediaItem m = imageItem;
            var imageAnalysis = _imageAnalysisFactory.Create(
                m, 
                GetEmotionalAnalysis(m), 
                GetFacialAnalysis(m),
                GetTextualAnalysis(m),
                GetVisualAnalysis(m));
            
            Item parent = GetImageAnalysisFolder(imageItem.Database.Name);
            if (parent == null)
                return imageAnalysis;
            
            Item templateItem = GetImageAnalysisTemplate(imageItem.Database.Name);
            if (templateItem == null)
                return imageAnalysis;
            
            Item newItem = parent.Add(imageItem.ID.ToShortID().ToString(), (TemplateItem)templateItem);

            using (new EditContext(newItem, true, false))
            {
                newItem.Fields[_settings.VisualAnalysisField].Value = JsonConvert.SerializeObject(imageAnalysis.VisionAnalysis);
                newItem.Fields[_settings.TextualAnalysisField].Value = JsonConvert.SerializeObject(imageAnalysis.TextAnalysis);
                newItem.Fields[_settings.FacialAnalysisField].Value = JsonConvert.SerializeObject(imageAnalysis.FacialAnalysis);
                newItem.Fields[_settings.EmotionalAnalysisField].Value = JsonConvert.SerializeObject(imageAnalysis.EmotionAnalysis);
                newItem.Fields[_settings.AnalyzedImageField].Value = newItem.ID.ToString();
            }

            return imageAnalysis;
        }

        public virtual int AnalyzeImagesRecursively(Item item, string db)
        {
            var list = item.Axes.GetDescendants()
                .Where(a => !a.TemplateID.Guid.Equals(Sitecore.TemplateIDs.MediaFolder.Guid))
                .ToList();

            list.ForEach(b => AnalyzeImage(b));

            return list.Count;
        }

        #region API Calls

        public virtual Emotion[] GetEmotionalAnalysis(MediaItem m)
        {
            return _emotionService.Recognize(m.GetMediaStream());
        }
        
        public virtual Face[] GetFacialAnalysis(MediaItem m)
        {
            return _faceService.Detect(m.GetMediaStream(), true, true, new List<FaceAttributeType>()
            {
                FaceAttributeType.Age,
                FaceAttributeType.FacialHair,
                FaceAttributeType.Gender,
                FaceAttributeType.Glasses,
                FaceAttributeType.HeadPose,
                FaceAttributeType.Smile
            });
        }

        public virtual AnalysisResult GetVisualAnalysis(MediaItem m)
        {
            return _visionService.AnalyzeImage(m.GetMediaStream(), new List<VisualFeature>() {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.Description,
                VisualFeature.Faces,
                VisualFeature.ImageType,
                VisualFeature.Tags
            });
        }

        public virtual OcrResults GetTextualAnalysis(MediaItem m)
        {
            return _visionService.RecognizeText(m.GetMediaStream(), "en", true);
        }

        #endregion

        #region Helpers

        public Item GetImageAnalysisFolder(string dbName)
        {
            return _dataWrapper.GetItemByIdValue(_settings.ImageAnalysisFolder, dbName);
        }

        public Item GetImageAnalysisTemplate(string dbName)
        {
            return _dataWrapper.GetItemByIdValue(_settings.ImageAnalysisTemplate, dbName);
        }

        #endregion
    }
}