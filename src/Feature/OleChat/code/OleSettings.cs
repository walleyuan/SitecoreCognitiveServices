using System;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public class OleSettings : IOleSettings
    {
        public virtual Guid OleApplicationId => new Guid(Settings.GetSetting("CognitiveService.OleChat.OleApplicationId"));
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.OleChat.MasterDatabase");
        public virtual string DictionaryDomain => Settings.GetSetting("CognitiveService.OleChat.DictionaryDomain");
        public virtual ID OleChatSettingsId => new ID(Settings.GetSetting("CognitiveService.OleChat.OleChatSettingsId"));
    }
}