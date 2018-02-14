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
                Item folderItem = DataWrapper.GetDatabase(MasterDatabase).GetItem(OleSettingsFolderId);
                if (folderItem == null)
                    return Guid.Empty;

                Field f =folderItem.Fields[OleAppIdField];
                if (f == null)
                    return Guid.Empty;

                Guid returnObj;
                return (Guid.TryParse(f.Value, out returnObj))
                    ? returnObj
                    : Guid.Empty;
            }
            set
            {
                var settingsItem = DataWrapper.GetDatabase(MasterDatabase).GetItem(OleSettingsFolderId);
                if (settingsItem == null)
                    return;

                using (new EditContext(settingsItem, true, false))
                {
                    settingsItem.Fields.ReadAll();
                    settingsItem.Fields[OleAppIdField].Value = value.ToString();
                }
            }
        }
        public virtual string CoreDatabase => Settings.GetSetting("CognitiveService.CoreDatabase");
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.MasterDatabase");
        public virtual string WebDatabase => Settings.GetSetting("CognitiveService.WebDatabase");
        public virtual string DictionaryDomain => Settings.GetSetting("CognitiveService.OleChat.DictionaryDomain");
        public virtual ID OleSettingsFolderId => new ID(Settings.GetSetting("CognitiveService.OleChat.OleSettingsFolder"));
        public virtual ID OleTemplatesFolderId => new ID(Settings.GetSetting("CognitiveService.OleChat.OleTemplatesFolder"));
        public virtual ID SCSDKTemplatesFolderId => new ID(Settings.GetSetting("CognitiveService.OleChat.SCSDKTemplatesFolder"));
        public virtual ID SCSModulesFolderId => new ID(Settings.GetSetting("CognitiveService.OleChat.SCSModulesFolder"));
        public virtual string OleAppIdField => Settings.GetSetting("CognitiveService.OleChat.OleAppIdField");
        public virtual string TestMessage => Settings.GetSetting("CognitiveService.OleChat.TestMessage");
        public virtual string LuisPublishResource => Settings.GetSetting("CognitiveService.OleChat.LuisPublishResource");
    }
}