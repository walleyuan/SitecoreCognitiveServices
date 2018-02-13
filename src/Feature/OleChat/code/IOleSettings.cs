using System;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public interface IOleSettings {
        Guid OleApplicationId { get; set; }
        string MasterDatabase { get; }
        string WebDatabase { get; }
        string DictionaryDomain { get; }
        ID OleSettingsFolderId { get; }
        ID OleTemplatesFolderId { get; }
        ID SCSDKTemplatesFolderId { get; }
        ID SCSModulesFolderId { get; }
        string OleAppIdField { get; }
    }
}