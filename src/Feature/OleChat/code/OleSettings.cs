using System;
using System.Web.Mvc;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public class OleSettings : IOleSettings
    {
        protected ISitecoreDataWrapper DataWrapper;

        public OleSettings(ISitecoreDataWrapper dataWrapper)
        { 
            DataWrapper = dataWrapper;
        }

        public virtual Guid OleApplicationId
        {
            get
            {
                Item folderItem = DataWrapper.GetDatabase(MasterDatabase).GetItem(OleChatSettingsId);
                if (folderItem == null)
                    return Guid.Empty;

                Field f =folderItem.Fields[OleChatAppIdField];
                if (f == null)
                    return Guid.Empty;

                Guid returnObj;
                return (Guid.TryParse(f.Value, out returnObj))
                    ? returnObj
                    : Guid.Empty;
            }
            set
            {
                var settingsItem = DataWrapper.GetDatabase(MasterDatabase).GetItem(OleChatSettingsId);
                if (settingsItem == null)
                    return;

                using (new EditContext(settingsItem, true, false))
                {
                    settingsItem.Fields.ReadAll();
                    settingsItem.Fields[OleChatAppIdField].Value = value.ToString();
                }
            }
        } 
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.OleChat.MasterDatabase");
        public virtual string DictionaryDomain => Settings.GetSetting("CognitiveService.OleChat.DictionaryDomain");
        public virtual ID OleChatSettingsId => new ID(Settings.GetSetting("CognitiveService.OleChat.OleChatSettingsId"));
        public virtual string OleChatAppIdField => Settings.GetSetting("CognitiveService.OleChat.OleChatAppIdField");
    }
}