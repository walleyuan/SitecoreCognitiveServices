using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Repositories.Vision;
using Microsoft.SharedSource.CognitiveServices.Enums;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public class CognitiveIndexableImageItem : SitecoreIndexableItem
    {
        public CognitiveIndexableImageItem(Item item) : base(item)
        {
            var dataWrapper = DependencyResolver.Current.GetService<ISitecoreDataWrapper>();
            if (dataWrapper == null)
            {
                return;
            }

            if (dataWrapper.IsMediaFile(item))
            {
                SetMediaProperties(item);
            }
        }
                
        private string RemoveHtmlMarkup(string value)
        {
            return Regex.Replace(value, "<.*?>", string.Empty);
        }

        private string GetFormattedString(string value, int sizeLimit)
        {
            string plainString = RemoveHtmlMarkup(value);

            var contentSize = Encoding.Unicode.GetByteCount(plainString);
            if (contentSize < sizeLimit)
                return plainString;

            string[] sentences = plainString.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in sentences)
            {
                if (Encoding.Unicode.GetByteCount($"{sb} {s}.") > sizeLimit)
                    break;

                sb.Append(sb.Length == 0 ? $"{s}." : $" {s}");
            }

            return sb.ToString();
        }

        protected virtual void SetMediaProperties(Item item)
        {
            MediaItem m = item;
            if (!MeetsRestrictions(m))
            {
                return;
            }

            SetEmotions(m);

            SetFaceData(m);

            SetVisionData(m);
        }

        /// <summary>
        /// Contacts the Emotions repository and updates the Emotions data for the media item
        /// </summary>
        /// <param name="m"></param>
        protected virtual void SetEmotions(MediaItem m)
        {
            try
            {
                var emotionRepository = DependencyResolver.Current.GetService<IEmotionRepository>();
                if (emotionRepository != null)
                {
                    Emotions = emotionRepository.Recognize(m.GetMediaStream());
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error recognizing Emotions. Item: {m.InnerItem.ID}, Message: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Contacts the Face API and updates the Face data for the media item
        /// </summary>
        /// <param name="m"></param>
        protected virtual void SetFaceData(MediaItem m)
        {
            try
            {
                var faceRepository = DependencyResolver.Current.GetService<IFaceRepository>();
                if (faceRepository != null)
                {
                    Faces = faceRepository.Detect(m.GetMediaStream(), true, true, new List<FaceAttributeType>()
                    {
                        FaceAttributeType.Age,
                        FaceAttributeType.FacialHair,
                        FaceAttributeType.Gender,
                        FaceAttributeType.Glasses,
                        FaceAttributeType.HeadPose,
                        FaceAttributeType.Smile
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error detecting Faces. Item: {m.InnerItem.ID}, Message: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Contacts the Vision repository and collects data about the media item
        /// </summary>
        /// <param name="m"></param>
        protected virtual void SetVisionData(MediaItem m)
        {
            try
            {
                var visionRepository = DependencyResolver.Current.GetService<IVisionRepository>();
                if (visionRepository != null)
                {

                    Visions = visionRepository.AnalyzeImage(m.GetMediaStream(), new List<VisualFeature>() {
                        VisualFeature.Adult,
                        VisualFeature.Categories,
                        VisualFeature.Color,
                        VisualFeature.Description,
                        VisualFeature.Faces,
                        VisualFeature.ImageType,
                        VisualFeature.Tags
                    });

                    Text = visionRepository.RecognizeText(m.GetMediaStream(), "en", true);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error analyzing using Computer Vision API. Item: {m.InnerItem.ID}, Message: {ex.Message}", ex);
            }

        }

        /// <summary>
        /// This will get all text based content fields (as opposed to system fields) from the provided item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual IEnumerable<Field> GetTextualFields(Item item)
        {
            IEnumerable<Field> fields = item.Fields
                    .Where(f => !f.Name.StartsWith("__") && GetTextualFieldTypes().Contains(f.Type));

            return fields;
        }

        private static string[] GetTextualFieldTypes()
        {
            return Settings.GetSetting("CognitiveService.ImageSearch.TextualFieldTypes").Split('|');
        }

        private bool MeetsRestrictions(MediaItem mediaItem)
        {
            int height = Int32.Parse(mediaItem.InnerItem["Height"]);
            int width = Int32.Parse(mediaItem.InnerItem["Width"]);

            if (height <= 36 || height > 4096)
            {
                return false;
            }

            if (width <= 36 || width > 4096)
            {
                return false;
            }

            List<string> acceptableFormats = new List<string>() { "jpg", "jpeg", "png", "gif", "bmp" };
            if (!acceptableFormats.Contains(mediaItem.Extension.ToLower()))
            {
                return false;
            }

            return true;
        }

        public OcrResults Text { get; set; }

        public AnalysisResult Visions { get; set; }

        public Face[] Faces { get; set; }

        public Emotion[] Emotions { get; set; }
    }
}