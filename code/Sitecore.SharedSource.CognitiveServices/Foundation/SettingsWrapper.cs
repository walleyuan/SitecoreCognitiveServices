using Sitecore.Configuration;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class SettingsWrapper : ISettingsWrapper
    {
        public virtual string GetSetting(string settingsKey)
        {
            return Settings.GetSetting(settingsKey);
        }
    }
}