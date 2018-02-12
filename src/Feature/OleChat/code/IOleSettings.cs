using System;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public interface IOleSettings {
        Guid OleApplicationId { get; set; }
        string MasterDatabase { get; }
        string DictionaryDomain { get; }
        ID OleChatSettingsId { get; }
    }
}