using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;
using SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Analysis
{
    public class ImageAnalysisService : IImageAnalysisService
    {
        #region Constructor

        protected readonly IImageSearchSettings _settings;
        protected readonly ISitecoreDataWrapper _dataWrapper;
        protected readonly IEmotionRepository _emotionRepository;
        protected readonly IFaceRepository _faceRepository;
        protected readonly IVisionRepository _visionRepository;
        protected readonly ICognitiveImageAnalysisFactory _imageAnalysisFactory;
        
        public ImageAnalysisService(
            IImageSearchSettings settings,
            ISitecoreDataWrapper dataWrapper,
            IEmotionRepository emotionRepository,
            IFaceRepository faceRepository,
            IVisionRepository visionRepository,
            ICognitiveImageAnalysisFactory imageAnalysisFactory)
        {
            _settings = settings;
            _dataWrapper = dataWrapper;
            _emotionRepository = emotionRepository;
            _faceRepository = faceRepository;
            _visionRepository = visionRepository;
            _imageAnalysisFactory = imageAnalysisFactory;
        }

        #endregion

        public ICognitiveImageAnalysis GetAnalysis(string id, string dbName)
        {
            
            var item = _dataWrapper.GetItemByIdValue(_settings.ImageAnalysisTemplate, dbName);
            MediaItem m = item;

            var imageAnalysis = _imageAnalysisFactory.Create(
                m,
                JsonConvert.DeserializeObject<Emotion[]>(item.Fields["Emotion Analysis"].Value),
                JsonConvert.DeserializeObject<Face[]>(item.Fields["Facial Analysis"].Value),
                JsonConvert.DeserializeObject<OcrResults>(item.Fields["Text Analysis"].Value),
                JsonConvert.DeserializeObject<AnalysisResult>(item.Fields["Vision Analysis"].Value));
            
            return imageAnalysis;
        }
        
        public ICognitiveImageAnalysis AnalyzeImage(Item imageItem)
        {
            MediaItem m = imageItem;
            var imageAnalysis = _imageAnalysisFactory.Create(
                m, 
                GetEmotionAnalysis(m), 
                GetFaceAnalysis(m),
                GetTextAnalysis(m),
                GetVisionAnalysis(m));
            
            Item parent = GetImageAnalysisFolder(imageItem.Database.Name);
            if (parent == null)
                return imageAnalysis;
            
            Item templateItem = GetImageAnalysisTemplate(imageItem.Database.Name);
            if (templateItem == null)
                return imageAnalysis;
            
            Item newItem = parent.Add(imageItem.ID.ToShortID().ToString(), (TemplateItem)templateItem);

            using (new EditContext(newItem, true, false))
            {
                newItem.Fields["Vision Analysis"].Value = JsonConvert.SerializeObject(imageAnalysis.VisionAnalysis);
                newItem.Fields["Emotion Analysis"].Value = JsonConvert.SerializeObject(imageAnalysis.EmotionAnalysis);
                newItem.Fields["Facial Analysis"].Value = JsonConvert.SerializeObject(imageAnalysis.FacialAnalysis);
                newItem.Fields["Text Analysis"].Value = JsonConvert.SerializeObject(imageAnalysis.TextAnalysis);
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

        public virtual Emotion[] GetEmotionAnalysis(MediaItem m)
        {
            try
            {
                return _emotionRepository.Recognize(m.GetMediaStream());
            }
            catch (Exception ex)
            {
                Log.Error($"Error recognizing Emotions. Item: {m.InnerItem.ID}, Message: {ex.Message}", ex);
            }

            return null;
        }
        
        public virtual Face[] GetFaceAnalysis(MediaItem m)
        {
            try
            {
                return _faceRepository.Detect(m.GetMediaStream(), true, true, new List<FaceAttributeType>()
                {
                    FaceAttributeType.Age,
                    FaceAttributeType.FacialHair,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Glasses,
                    FaceAttributeType.HeadPose,
                    FaceAttributeType.Smile
                });
            }
            catch (Exception ex)
            {
                Log.Error($"Error detecting Faces. Item: {m.InnerItem.ID}, Message: {ex.Message}", ex);
            }

            return null;
        }

        public virtual AnalysisResult GetVisionAnalysis(MediaItem m)
        {
            try
            {
                return _visionRepository.AnalyzeImage(m.GetMediaStream(), new List<VisualFeature>() {
                    VisualFeature.Adult,
                    VisualFeature.Categories,
                    VisualFeature.Color,
                    VisualFeature.Description,
                    VisualFeature.Faces,
                    VisualFeature.ImageType,
                    VisualFeature.Tags
                });
            }
            catch (Exception ex)
            {
                Log.Error($"Error analyzing using Vision API. Item: {m.InnerItem.ID}, Message: {ex.Message}", ex);
            }

            return null;
        }

        public virtual OcrResults GetTextAnalysis(MediaItem m)
        {
            try
            {
                return _visionRepository.RecognizeText(m.GetMediaStream(), "en", true);
            }
            catch (Exception ex)
            {
                Log.Error($"Error analyzing using Text API. Item: {m.InnerItem.ID}, Message: {ex.Message}", ex);
            }

            return null;
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