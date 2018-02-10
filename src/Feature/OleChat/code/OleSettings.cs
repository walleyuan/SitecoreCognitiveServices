using System;
using Sitecore.Configuration;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public class OleSettings : IOleSettings
    {
        public virtual Guid OleApplicationId => new Guid(Settings.GetSetting("CognitiveService.OleChat.OleApplicationId"));
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.OleChat.MasterDatabase");
        public virtual string DictionaryDomain => Settings.GetSetting("CognitiveService.OleChat.DictionaryDomain");
    }
}