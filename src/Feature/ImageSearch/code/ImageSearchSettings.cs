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

        public virtual string WebDatabase => Settings.GetSetting("CognitiveService.WebDatabase");
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.MasterDatabase");
        public virtual string CoreDatabase => Settings.GetSetting("CognitiveService.CoreDatabase");
        public virtual string SitecoreIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.SitecoreIndexNameFormat");
        public virtual string CognitiveIndexNameFormat => Settings.GetSetting("CognitiveService.ImageSearch.CognitiveIndexNameFormat");
        public virtual string VisualAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.VisualAnalysisField");
        public virtual string TextualAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.TextualAnalysisField");
        public virtual string FacialAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.FacialAnalysisField");
        public virtual string EmotionalAnalysisField => Settings.GetSetting("CognitiveService.ImageSearch.EmotionalAnalysisField");
        public virtual string AnalyzedImageField => Settings.GetSetting("CognitiveService.ImageSearch.AnalyzedImageField");
        public virtual string AnalyzeNewImageField => Settings.GetSetting("CognitiveService.ImageSearch.AnalyzeNewImageField");
        public virtual string ImageAnalysisFolder => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisFolder");
        public virtual string ImageAnalysisTemplate => Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisTemplate");
        public virtual ID ImageAnalysisFolderId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.ImageAnalysisFolder"));
        public virtual ID SampleImageId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.SampleImage"));
        public virtual ID ImageSearchFolderId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.ImageSearchFolder"));
        public virtual ID BlogFieldId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.BlogField"));
        public virtual ID ImageSearchFieldFolderId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.ImageSearchFieldFolder"));
        public virtual ID SCSDKTemplatesFolderId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.SCSDKTemplatesFolder"));
        public virtual ID ImageSearchTemplatesFolderId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.ImageSearchTemplatesFolder"));
        public virtual ID SCSModulesFolderId => new ID(Settings.GetSetting("CognitiveService.ImageSearch.SCSModulesFolder"));
        public virtual string DictionaryDomain => Settings.GetSetting("CognitiveService.ImageSearch.DictionaryDomain");
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