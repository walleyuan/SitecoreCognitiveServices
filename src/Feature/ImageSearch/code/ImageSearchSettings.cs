using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Configuration;
using Sitecore.Data;
using SitecoreCognitiveServices.Foundation.MSSDK;

namespace SitecoreCognitiveServices.Feature.ImageSearch {
    public class ImageSearchSettings : IImageSearchSettings
    {
        protected static IMicrosoftCognitiveServicesApiKeys _msApiKeys => DependencyResolver.Current.GetService<IMicrosoftCognitiveServicesApiKeys>();

        public virtual string ContentDatabase => Settings.GetSetting("CognitiveService.ImageSearch.ContentDatabase");
        public virtual string SitecoreIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.SitecoreIndexNameFormat");
        public virtual string CognitiveIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.CognitiveIndexNameFormat");
        public virtual string ImageAnalysisFolder => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisFolder");
        public virtual string ImageAnalysisTemplate => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisTemplate");
        public virtual string VisualAnalysisField => "Visual Analysis";
        public virtual string TextualAnalysisField => "Textual Analysis";
        public virtual string FacialAnalysisField => "Facial Analysis";
        public virtual string EmotionalAnalysisField => "Emotional Analysis";
        public virtual string AnalyzedImageField => "Analyzed Image";
        public virtual ID ImageAnalysisFolderId => new ID("{DCA68A11-8670-4B60-B752-F95CBBC14E97}");
        public virtual ID SampleImage => new ID("{ADD6D028-AEB2-46DE-ACA0-972DCB83422F}");
        public virtual ID ImageSearchFolderId => new ID("{8DE01E53-9B77-456E-AC39-E5A4104DA38C}");
        public virtual string AnalyzeNewImageField => "Analyze New Images";
        public virtual ID BlogFieldId => new ID("{40E50ED9-BA07-4702-992E-A912738D32DC}");
        public virtual string DictionaryDomain => "Image Search Dictionary";
        public bool MissingKeys()
        {
            if (_msApiKeys == null)
                return true;

            return HasNoValue(_msApiKeys.Emotion)
                   || HasNoValue(_msApiKeys.EmotionEndpoint)
                   || HasNoValue(_msApiKeys.Face)
                   || HasNoValue(_msApiKeys.FaceEndpoint)
                   || HasNoValue(_msApiKeys.ComputerVision)
                   || HasNoValue(_msApiKeys.ComputerVisionEndpoint);
        }
        public bool HasNoValue(string str)
        {
            return string.IsNullOrWhiteSpace(str.Trim());
        }
    }
}