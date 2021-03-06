﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Feature.ImageSearch {
    public interface IImageSearchSettings {
        string WebDatabase { get; }
        string MasterDatabase { get; }
        string CoreDatabase { get; }
        string SitecoreIndexNameFormat { get; }
        string CognitiveIndexNameFormat { get; }
        string VisualAnalysisField { get; }
        string TextualAnalysisField { get; }
        string FacialAnalysisField { get; }
        string AnalyzedImageField { get; }
        string AnalyzeNewImageField { get; }
        string ImageAnalysisFolder { get; }
        string ImageAnalysisTemplate { get; }
        ID ImageAnalysisFolderId { get; }
        ID SampleImageId { get; }
        ID ImageSearchFolderId { get; }
        ID BlogFieldId { get; }
        ID ImageSearchFieldFolderId { get; }
        ID SCSDKTemplatesFolderId { get; }
        ID ImageSearchTemplatesFolderId { get; }
        ID SCSModulesFolderId { get; }
        string DictionaryDomain { get; }
        bool MissingKeys();
        bool HasNoValue(string str);
    }
}
