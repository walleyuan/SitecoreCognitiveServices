using System;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public class OleSettings : IOleSettings
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        
        public OleSettings(ISitecoreDataWrapper dataWrapper)
        {
            DataWrapper = dataWrapper;
        }

        #endregion

        public virtual Guid OleApplicationId
        {
            get
            {
                var appId = GetStringValue("Application Id");
                return (string.IsNullOrEmpty(appId))
                    ? Guid.Empty
                    : new Guid(appId);
            }
            set
            {
                SetValue("Application Id", value);
            }
        }
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.OleChat.MasterDatabase");
        public virtual string DictionaryDomain => Settings.GetSetting("CognitiveService.OleChat.DictionaryDomain");
        public virtual ID OleChatSettingsId => new ID(Settings.GetSetting("CognitiveService.OleChat.OleChatSettingsId"));

        public string GetStringValue(string fieldName)
        {
            Item i = DataWrapper?
                .ContentDatabase?
                .GetItem(OleChatSettingsId);
            if (i == null)
                return string.Empty;

            Field f = i.Fields[fieldName];
            if (f == null)
                return string.Empty;

            return f.Value;
        }

        public void SetValue(string fieldName, object value)
        {
            var settingsItem = DataWrapper.ContentDatabase.GetItem(OleChatSettingsId);

            using (new EditContext(settingsItem, true, false))
            {
                settingsItem.Fields[fieldName].Value = value.ToString();
            }
        }
    }
}